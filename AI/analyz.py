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
import pickle
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


#Naivy Bayes
#Собиров Собир
def naivy_bayes():
    filename = 'model_nb.sav'
    nb = pickle.load(open(filename, 'rb'))
    return nb

#Logistic Regression
#Машарипов
def logistic_reg():
    filename = 'model_log.sav'
    logreg = pickle.load(open(filename, 'rb'))
    return logreg


#SGD Classifier
#Яхёев Беҳзод
def sgd_class():
    filename = 'model_sgd.sav'
    sgd = pickle.load(open(filename, 'rb'))
    return sgd


#Decision Tree
#Самадова Мафтуна
def decision_tree():
    filename = 'model_dtc.sav'
    dtc = pickle.load(open(filename, 'rb'))
    return dtc

#KNN
#KNN - ЧША
def k_neighbors():
    filename = 'model_knn.sav'
    knn = pickle.load(open(filename, 'rb'))
    return knn



#Random Forest
#Шофозилов
def random_forest():
    filename = 'model_rfc.sav'
    rfc = pickle.load(open(filename, 'rb'))
    return rfc



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