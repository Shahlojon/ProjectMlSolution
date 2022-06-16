from statistics import mode
from unicodedata import name
import pandas as pd
import numpy as np
from tqdm.auto import tqdm, trange
from nltk.stem import *
from nltk.corpus import stopwords
from pymystem3 import Mystem
from string import punctuation
import nltk
from nltk.corpus import stopwords
from nltk import word_tokenize
from fuzzywuzzy import fuzz
from nltk.stem.snowball import SnowballStemmer 
stemmer = SnowballStemmer("russian") 
from sklearn.metrics import accuracy_score
from sklearn.naive_bayes import MultinomialNB
from sklearn.pipeline import Pipeline
from sklearn.feature_extraction.text import TfidfTransformer
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.linear_model import SGDClassifier
from sklearn.tree import DecisionTreeClassifier
from sklearn.neighbors import KNeighborsClassifier 
from sklearn.ensemble import RandomForestClassifier


df = pd.read_csv('esseyExcel.csv',delimiter=';', skiprows=0, low_memory=False)


category = df['essay_theme'].unique()
text = df['essay_text'].unique()


category_list =category
news_in_cat_count = 3516
df_res = pd.DataFrame()
for topic in tqdm(category_list):
    df_topic = df[df['essay_theme'] == topic][:news_in_cat_count]
    df_res = df_res.append(df_topic, ignore_index=True) 
    
    
import string
def remove_punctuation(text):
    return "".join([ch if ch not in string.punctuation else ' ' for ch in text])

def remove_numbers(text):
    return ''.join([i if not i.isdigit() else ' ' for i in text])

import re
def remove_multiple_spaces(text):
	return re.sub(r'\s+', ' ', text, flags=re.I)

mystem = Mystem() 

english_stopwords = stopwords.words("tajik")
english_stopwords.extend(['…', '«', '»', '...'])
def lemmatize_text(text):
    tokens = mystem.lemmatize(text.lower())
    tokens = [token for token in tokens if token not in english_stopwords and token != " "]
    text = " ".join(tokens)
    return text

def remove_stop_words(text):
    tokens = word_tokenize(text) 
    tokens = [token for token in tokens if token not in english_stopwords and token != ' ']
    return " ".join(tokens)

preproccessing = lambda text: (remove_multiple_spaces(remove_numbers(remove_punctuation(text))))

df_res['essay_text'] = df_res['essay_text']

prep_text = [remove_multiple_spaces(remove_numbers(remove_punctuation(text.lower()))) for text in tqdm(df_res['essay_text'])]

#len(prep_text)

df_res['text_prep'] = prep_text

stemmed_texts_list = []
for text in tqdm(df_res['text_prep']):
    tokens = word_tokenize(text)    
    stemmed_tokens = [stemmer.stem(token) for token in tokens if token not in english_stopwords]
    
    text = " ".join(stemmed_tokens)
    stemmed_texts_list.append(text)

df_res['text_stem'] = stemmed_texts_list




sw_texts_list = []
for text in tqdm(df_res['text_prep']):
    tokens = word_tokenize(text)    
    tokens = [token for token in tokens if token not in english_stopwords and token != ' ']
    text = " ".join(tokens)
    sw_texts_list.append(text)

df_res['text_sw'] = sw_texts_list

df_res.to_csv('essay_stemmed.csv')

df_res['text_stem'][0]

X = df_res['text_sw']
y = df_res['essay_theme']


X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.05, random_state = 42)

my_tags = df_res['essay_theme'].unique()

#Naivy Bayes
#Собиров Собир
def naivy_bayes():
    nb = Pipeline([('vect', CountVectorizer()),
                ('tfidf', TfidfTransformer()),
                ('clf', MultinomialNB()),
                ])

    nb.fit(X_train, y_train)

    y_pred = nb.predict(X_test)
    accuracy_score(y_pred, y_test)
    return nb
# print('accuracy %s' % accuracy_score(y_pred, y_test))

#Logistic Regression
#Машарипов
def logistic_reg():
    logreg = Pipeline([('vect', CountVectorizer()),
                    ('tfidf', TfidfTransformer()),
                    ('clf', LogisticRegression(n_jobs=1, C=1e5)),
                ])

    logreg.fit(X_train, y_train)

    y_pred = logreg.predict(X_test)
    return logreg


#SGD Classifier
#Яхёев Беҳзод
def sgd_class():
    sgd = Pipeline([('vect', CountVectorizer()),
                    ('tfidf', TfidfTransformer()),
                    ('clf', SGDClassifier(loss='hinge', penalty='l2',alpha=1e-3, random_state=42, max_iter=5, tol=None)),
                ])

    sgd.fit(X_train, y_train)
    y_pred = sgd.predict(X_test)
    return sgd


#Decision Tree
#Самадова Мафтуна
def decision_tree():
    dtc = Pipeline([('vect', CountVectorizer()),
                    ('tfidf', TfidfTransformer()),
                    ('clf', DecisionTreeClassifier()),
                ])

    dtc.fit(X_train, y_train)
    y_pred = dtc.predict(X_test)
    return dtc

#KNN
#KNN - ЧША
def k_neighbors():
    kNN = Pipeline([('vect', CountVectorizer()),
                    ('tfidf', TfidfTransformer()),
                    ('clf', KNeighborsClassifier(n_neighbors=36)),
                ])

    kNN.fit(X_train, y_train)

    y_pred = kNN.predict(X_test)
    
    return kNN



#Random Forest
#Шофозилов
def random_forest():
    clf = Pipeline([('vect', CountVectorizer()),
                    ('tfidf', TfidfTransformer()),
                    ('clf', RandomForestClassifier(n_estimators=100)),
                ])

    clf.fit(X_train, y_train)

    y_pred = clf.predict(X_test)
    
    return clf



def get_ratio(text, theme):
    name = text
    name1 = theme
    return fuzz.token_set_ratio(name, name1)

def get_theme(econ_text, algorithm='sgd'):
    econ_text = remove_multiple_spaces(remove_numbers(remove_punctuation(econ_text.lower())))
    econ_text = remove_stop_words(econ_text)
    econ_text = lemmatize_text(econ_text)
    if algorithm == 'random':
        model = random_forest()
    elif algorithm =='sgd':
        model = sgd_class()
    elif algorithm =='logistic':
        model = logistic_reg()
    elif algorithm =='nb':
        model = naivy_bayes()
    elif algorithm =='decision':
        model = decision_tree()
    elif algorithm =='knn':
        model = k_neighbors()
    ect_pred = model.predict([econ_text])
     
    return ect_pred[0]


# econ_text = '''
# Экологияи иҷтимоӣ яке аз соҳаҳои иҷтимоии давлат ба ҳисоб рафта мақсад ва вазифаҳояш аз он иборат аст, ҳифзи муҳити зист, ҳифзи ҳайвоноту наботот, растанӣ, ҷангал ва ғайраро дарбар мегирад. Аз назари экологияи иҷтимоӣ мо бояд муҳити зист диққати аввалиндараҷа дода бошем.
# '''

# procent = get_ratio('Экологияи иҷтимоӣ ва вазифаҳои он',get_theme(econ_text))

# print(procent, get_theme(econ_text))