-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 31 2022 г., 07:17
-- Версия сервера: 10.3.13-MariaDB
-- Версия PHP: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `exam_essay`
--

-- --------------------------------------------------------

--
-- Структура таблицы `algorithms`
--

CREATE TABLE `algorithms` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `NameTj` varchar(255) NOT NULL,
  `Key` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `algorithms`
--

INSERT INTO `algorithms` (`Id`, `Name`, `NameTj`, `Key`) VALUES
(1, 'Decision tree', 'Дарахти хулоса', 'decision'),
(2, 'Random forest', 'Ҷангали тасодуфӣ', 'random'),
(3, 'SGDClassifier', 'метод опорных векторов', 'sgd'),
(4, 'KNeighborsClassifier', 'K-ҳамсояҳои наздиктарин', 'knn'),
(5, 'Naivy Bayes', 'Наивный Байесовский Алгоритм', 'nb'),
(6, 'Logistic Regression', 'Алгоритми регрессияи логистикӣ', 'logistic');

-- --------------------------------------------------------

--
-- Структура таблицы `contentessays`
--

CREATE TABLE `contentessays` (
  `Id` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `PredmetId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Структура таблицы `cources`
--

CREATE TABLE `cources` (
  `Id` int(11) NOT NULL,
  `Key` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `cources`
--

INSERT INTO `cources` (`Id`, `Key`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);

-- --------------------------------------------------------

--
-- Структура таблицы `examresults`
--

CREATE TABLE `examresults` (
  `Id` int(11) NOT NULL,
  `Grade` int(11) NOT NULL,
  `TopicId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `examresults`
--

INSERT INTO `examresults` (`Id`, `Grade`, `TopicId`) VALUES
(1, 10, 16),
(2, 10, 17),
(3, 0, 18),
(4, 10, 19),
(5, 3, 20),
(6, 3, 21),
(7, 0, 22),
(8, 10, 25),
(9, 10, 26),
(10, 0, 27),
(11, 10, 30),
(12, 0, 31);

-- --------------------------------------------------------

--
-- Структура таблицы `exams`
--

CREATE TABLE `exams` (
  `Id` int(11) NOT NULL,
  `Date` datetime(6) NOT NULL,
  `TimeStamp` datetime(6) NOT NULL,
  `GroupId` int(11) DEFAULT NULL,
  `SubjectId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `exams`
--

INSERT INTO `exams` (`Id`, `Date`, `TimeStamp`, `GroupId`, `SubjectId`) VALUES
(1, '2022-05-19 00:00:00.000000', '2022-05-19 00:00:00.000000', 1, 9),
(2, '2022-05-21 15:12:00.000000', '2022-05-22 15:12:00.000000', 2, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `groups`
--

CREATE TABLE `groups` (
  `Id` int(11) NOT NULL,
  `ProfessionId` int(11) DEFAULT NULL,
  `CourceId` int(11) DEFAULT NULL,
  `Key` longtext DEFAULT NULL,
  `date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `groups`
--

INSERT INTO `groups` (`Id`, `ProfessionId`, `CourceId`, `Key`, `date`) VALUES
(1, 1, 4, 'ра', '2022-05-19 00:00:00.000000'),
(2, 1, 4, 'та', '2022-05-21 00:00:00.000000'),
(3, 1, 3, '1', '2022-05-27 15:21:00.000000'),
(4, 1, 4, '1', '2022-05-27 15:22:00.000000'),
(5, 1, 2, 'ра', '2022-05-27 15:38:00.000000');

-- --------------------------------------------------------

--
-- Структура таблицы `lessons`
--

CREATE TABLE `lessons` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `SubjectId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `lessons`
--

INSERT INTO `lessons` (`Id`, `Name`, `SubjectId`) VALUES
(2, 'Экологияи иҷтимоӣ ва вазифаҳои он', 9),
(3, 'Экологияи иҷтимоӣ', 9),
(4, 'Экология ҳамчун фан', 9),
(5, 'Экология ҳамчун илм ва аҳамияти омӯзиши он', 9),
(6, 'Экологияи иҷтимоӣ ва вазифаҳои он, Инсон ва мавқеи он дар муҳитти зист', 9),
(7, 'Эрозия ва шуршавии замин', 9),
(8, 'Эрозия ва шӯршавии Замин. Таъсири фаъолияти инсон ба табиат', 9),
(9, 'Шартнома ва намудҳои он', 6),
(10, 'Шаклҳои пайдоиши давлат', 6),
(11, 'Шаклҳои идоракунии давлат', 6),
(12, 'Ҳолатҳои вазнинкунандаи ҷазо', 6),
(13, 'Ҳолатҳои сабуккунандаи ҷазо', 6),
(14, 'Субъектҳои ҳуқуқи байналхалқӣ', 6),
(15, 'Сохти идоракунӣ ва режими сиёсии давлат', 6),
(16, 'Сотсиолоия ҳамчун илм', 5),
(17, 'Сотсиологияи шахс', 5),
(18, 'Сотсиологияи муосири Ғарб', 5),
(19, 'Cотсиологияи меҳнат', 5),
(20, 'Сотсиологияи марксисти', 5),
(21, 'Сотсиологияи иқтисодиёт', 5),
(22, 'Сотсиологияи воситаҳои ахбори омма', 5),
(23, 'Сотсиологияи ВАО ва иртибот', 5),
(24, 'Сотсиологияи ВАО', 5),
(25, 'Сотсиология ҳамчун илми эмпирикӣ (Социология как эмпирическая наука)', 5),
(26, 'Сиёсат ҳамчун санъати идораи корҳои давлатӣ', 2),
(27, 'Сиёсат ҳамчун падидаи ҷамъиятӣ', 2),
(28, 'Сиёсат ва воситаҳои ахбори омма', 2),
(29, 'Ҷахонишавӣ ва назарияи геополитикии олам', 2),
(30, 'Фаъолияти ҳизбҳои сиёсӣ дар Тоҷикистон', 2),
(31, 'Точикистон давлати демократи', 2),
(32, 'Терроризми байналхалки ва гурухои ифротӣ хамчун тахдид ба амнияти миллӣ', 2),
(33, 'Асосҳои назаривии ноҳиябандии иқтисодӣ', 8),
(34, 'Аҳолӣ ва захираҳои меҳнатӣ', 8),
(50, 'Экологияи иҷтимоӣ ва вазифаҳои он', 9),
(51, 'Сотсиологияи ВАО', 5),
(52, 'Экологияи иҷтимоӣ', 9),
(53, 'Экологияи иҷтимоӣ ва вазифаҳои он', 9),
(54, '10. Ташаккулёбии муносибатҳои феодалӣ дар Осиёи  Марказӣ. Шоҳаншоҳии Сосониён дар Эрон.', 1),
(55, '«Китоби сурхи Ҷумҳурии Тоҷикистон» ва аҳамияти он', 1),
(56, '10.Дини ислом дар Мовароуннаҳру Хуросон', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `predmets`
--

CREATE TABLE `predmets` (
  `Id` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Структура таблицы `professions`
--

CREATE TABLE `professions` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Key` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `professions`
--

INSERT INTO `professions` (`Id`, `Name`, `Key`) VALUES
(1, 'Технология в низомхои иттилооти дар иктисодиет', '400102');

-- --------------------------------------------------------

--
-- Структура таблицы `subjects`
--

CREATE TABLE `subjects` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `subjects`
--

INSERT INTO `subjects` (`Id`, `Name`) VALUES
(1, 'Таърихи халқи тоҷик'),
(2, 'Сиёсатшиносӣ'),
(3, 'Фарҳангшиносӣ'),
(4, 'Этика ва эстетика'),
(5, 'Сотсиология'),
(6, 'Ҳуқуқ'),
(7, 'Мудофиаи шаҳрвандӣ'),
(8, 'Географияи иқтисодии Тоҷикистон ва асосҳои демографии он'),
(9, 'Экология'),
(10, 'Мантиқ');

-- --------------------------------------------------------

--
-- Структура таблицы `topicalgorithms`
--

CREATE TABLE `topicalgorithms` (
  `Id` int(11) NOT NULL,
  `Grade` int(11) NOT NULL,
  `Percent` int(11) DEFAULT NULL,
  `AlgorithmId` int(11) DEFAULT NULL,
  `TopicId` int(11) DEFAULT NULL,
  `NewTheme` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `topicalgorithms`
--

INSERT INTO `topicalgorithms` (`Id`, `Grade`, `Percent`, `AlgorithmId`, `TopicId`, `NewTheme`) VALUES
(1, 10, 100, 2, 16, 'Экологияи иҷтимоӣ ва вазифаҳои он'),
(2, 10, 100, 2, 17, 'Сотсиологияи ВАО'),
(3, 0, 6, 1, 18, 'Мавзуи 7-1. Афзоиши табиӣ ва бозтавлиди аҳолӣ. Вазъи демографӣ имрӯза дар қаламрави ҶТ.'),
(4, 10, 100, 3, 19, 'Экологияи иҷтимоӣ ва вазифаҳои он'),
(5, 3, 32, 1, 20, '16. Ҷамъият ва табиат.'),
(6, 3, 32, 4, 21, 'Захираи обҳои маъданӣ ва аҳамияти рекреатсионии онҳо.'),
(7, 0, 29, 1, 22, 'Экологияи иҷтимоӣ ва вазифаҳои он. Инсон ва мавқеи он дар муҳитти зист'),
(8, 10, 100, 3, 25, '«Китоби сурхи Ҷумҳурии Тоҷикистон» ва аҳамияти он'),
(9, 10, 100, 2, 26, '«Китоби сурхи Ҷумҳурии Тоҷикистон» ва аҳамияти он'),
(10, 0, 23, 5, 27, 'Сабабҳои имконпазири кандашавии кули Сарез'),
(11, 10, 100, 3, 30, '10.Дини ислом дар Мовароуннаҳру Хуросон'),
(12, 0, 16, 2, 31, 'Ахлоқи касбӣ');

-- --------------------------------------------------------

--
-- Структура таблицы `topics`
--

CREATE TABLE `topics` (
  `Id` int(11) NOT NULL,
  `Description` longtext DEFAULT NULL,
  `TimeStamp` datetime(6) NOT NULL,
  `ExamId` int(11) DEFAULT NULL,
  `StudentId` int(11) DEFAULT NULL,
  `LessonId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `topics`
--

INSERT INTO `topics` (`Id`, `Description`, `TimeStamp`, `ExamId`, `StudentId`, `LessonId`) VALUES
(16, 'Экология ҳамчун фан мебошад. Дат табиат ҳар як намуди микроорганизм, растаниҳо ва ҳайвоноту наботот мавқеи муайян медарояд. Ба омӯзиши тахсири растаниҳо ҳайвонот фардҳои ҷудогона аъзоёни популятсия системаҳои экологӣ таъсири мутаносибаи онҳо ба муҳити зист илми экология машғул мебошад.&nbsp; &nbsp; Истилоҳи экология аз ду калимаи юнони иборат мебошад, ки \"ойкос\"-ҳайт2, манзил, ҷойи зист ва \"логос\"-илм, фан ё таълим гирифтан мебошад.&nbsp; &nbsp;Экология ҳамчун фан барои инкишорфёфтаи соҳаҳои гуногуни хоҷагии халқ аҳамияти хеле калон дорад.', '2022-05-20 00:00:00.000000', 1, 1, 50),
(17, 'Воситаҳои ахбори ин барои ҳар як шахс ва ҳар як давлат лозим мебошад. ВАО ба инсон аҳбори берун ва дохили кишварро хабардор мекунанд. Воситаҳои ахбории як чанд ҳел шуда мерасонанд. Мисол сиёси оҳбор дар барои илми , иҷтимоӣ, табиӣва ғайраҳо мебошад.&nbsp; &nbsp;Васитаҳои ахбори оммаи фақри ин чунин ахбор мебошанд , ки аз ҳодисаи шударо ҳабардор мекунанд.&nbsp; &nbsp;Восиаҳои ахбори оммаи сиёси бошад байни додугирифти ду давлат ё воҳурии ду Президентҳои ду кишварро ҳабардор&nbsp; мекунанд.', '2022-05-21 00:00:00.000000', 1, 1, 51),
(18, 'Ооаокшоа лооалуолалу', '2022-05-21 00:00:00.000000', 1, 1, 52),
(19, 'Экология ҳамчун фан мебошад. Дат табиат ҳар як намуди микроорганизм, растаниҳо ва ҳайвоноту наботот мавқеи муайян медарояд. Ба омӯзиши тахсири растаниҳо ҳайвонот фардҳои ҷудогона аъзоёни популятсия системаҳои экологӣ таъсири мутаносибаи онҳо ба муҳити зист илми экология машғул мебошад.&nbsp; &nbsp; Истилоҳи экология аз ду калимаи юнони иборат мебошад, ки \"ойкос\"-ҳайт2, манзил, ҷойи зист ва \"логос\"-илм, фан ё таълим гирифтан мебошад.&nbsp; &nbsp;Экология ҳамчун фан барои инкишорфёфтаи соҳаҳои гуногуни хоҷагии халқ аҳамияти хеле калон дорад.', '2022-05-21 00:00:00.000000', 1, 1, 53),
(20, 'Эрозияи замин Ин шуршави ва вайрон мова атмосфераро мефахмонад Дар замони хозира илми мо бисер аз чисхои фарсуда мебошад Бояд мо иклимро тоза нигох дорем. Президенти кишварамон бехуда нагуфтанд ки хамачоро тозаву озода нигох дорем. Тозагии кишварамон хам ба худ ва хам ба атрофиени мо фоидаи зиед дорад.&nbsp;&nbsp;', '2022-05-23 00:00:00.000000', 1, 1, 7),
(21, 'Эрозия шусташавии Замин мебошад. Эроҳияи умумдории Замин нест мешавад ин табии ва мебошад: табии ойатҳои твбии шамол, об хези, сел ва барф ва ғайра мебошад.&nbsp; &nbsp; Шӯршавии замин нест кардан ба якчанд корҳо иҷро карда мешавад: заминба об монда шӯр шавии заминро нест карда мешавад ё дигар рохоки ҳам нест карда мешавад: хлк партофта омехта карда мешавад, ӯғитҳои менирали, ӯғитҳои хоҷагии қишлоқ чорво поруҳам партофта омехта карда мешавад.', '2022-05-23 00:00:00.000000', 1, 1, 7),
(22, 'Экология ин фаннест ки барои хифзи мухит зист,табиат, хайвонот, рустаниҳо ва тамоми чизҳои,ки дар табиат маълум аст меомӯзад ва Барои,хифзи он роҳ мекушояд.Асосгузории илмии Экология олими Немис \"Гекел\"буда,ба экология соли 1866 асос гузоштааст.Экология илмест,ки барои хифзи мухит зисти хайвонот,ҳифзи муҳити табиат ва ҳифзи кабатии озонй хизмат мекунад.', '2022-05-23 00:00:00.000000', 1, 1, 4),
(23, '<p><font color=\"#000000\"><span style=\"font-size: 17.6px;\">Китоби сурхи Ҷумҳурии Тоҷикистон ҳуҷҷати расмии давлатӣ буда дар он маълумот оид ба намудҳои нодири набототу ҳайвоноти Ҷумҳурии Тоҷикистонки ба муҳофизат ниёз доранд оварда шудааст.Вазифи&nbsp; асосии Китоби Сурхи Тоҷикистон дар асоси меъёру категорияҳои муқарраргардидаи Иттиҳоди байналмилалии ҳифзи табиат арзёби намудани ҳолати ҳифзи намуду зернамудҳои олами набототу&nbsp; ҳайвонот мебошад,ки дар дунё кам мондаанду шумораашон кам шудаанд.</span></font><br></p>', '2022-05-23 00:00:00.000000', 1, 1, 55),
(24, '<p><font color=\"#000000\"><span style=\"font-size: 17.6px;\">Китоби сурхи Ҷумҳурии Тоҷикистон ҳуҷҷати расмии давлатӣ буда дар он маълумот оид ба намудҳои нодири набототу ҳайвоноти Ҷумҳурии Тоҷикистонки ба муҳофизат ниёз доранд оварда шудааст.Вазифи&nbsp; асосии Китоби Сурхи Тоҷикистон дар асоси меъёру категорияҳои муқарраргардидаи Иттиҳоди байналмилалии ҳифзи табиат арзёби намудани ҳолати ҳифзи намуду зернамудҳои олами набототу&nbsp; ҳайвонот мебошад,ки дар дунё кам мондаанду шумораашон кам шудаанд.</span></font><br></p>', '2022-05-23 00:00:00.000000', 1, 1, 55),
(25, 'Китоби сурхи Ҷумҳурии Тоҷикистон ҳуҷҷати расмии давлатӣ буда дар он маълумот оид ба намудҳои нодири набототу ҳайвоноти Ҷумҳурии Тоҷикистонки ба муҳофизат ниёз доранд оварда шудааст.Вазифи&nbsp; асосии Китоби Сурхи Тоҷикистон дар асоси меъёру категорияҳои муқарраргардидаи Иттиҳоди байналмилалии ҳифзи табиат арзёби намудани ҳолати ҳифзи намуду зернамудҳои олами набототу&nbsp; ҳайвонот мебошад,ки дар дунё кам мондаанду шумораашон кам шудаанд.', '2022-05-23 00:00:00.000000', 1, 1, 55),
(26, 'Китоби сурхи Ҷумҳурии Тоҷикистон ҳуҷҷати расмии давлатӣ буда дар он маълумот оид ба намудҳои нодири набототу ҳайвоноти Ҷумҳурии Тоҷикистонки ба муҳофизат ниёз доранд оварда шудааст.Вазифи&nbsp; асосии Китоби Сурхи Тоҷикистон дар асоси меъёру категорияҳои муқарраргардидаи Иттиҳоди байналмилалии ҳифзи табиат арзёби намудани ҳолати ҳифзи намуду зернамудҳои олами набототу&nbsp; ҳайвонот мебошад,ки дар дунё кам мондаанду шумораашон кам шудаанд.', '2022-05-23 00:00:00.000000', 1, 7, 55),
(27, 'Таърих фаннест, ки гузаштагони Аҷдоди моро мефҳмонад.&nbsp; Баъд аз барҳамхӯрдани давлати Сарбадорони Амир Ҳусайн Хони тамоми Мовароуннаҳр гардид ӯ баъд зулму ситам овард ӯ давлати Сарбадоронро бо ин гуна ҷазоҳо гирифтор кард.&nbsp; Амир Ҳусайн қарор баровард, ки марду зан, духтарон, кӯдаконро, қир карда онҳоро ҷазоҳои хеле вазнин медод.&nbsp; Вай ҳатто гуфта буд, ки онҳоро дар мобайни деворҳо монда дар болои онҳо оҳанҳои вазнин ва реш монда деворҳои баланд месохтанд. Чунин бераҳми Амир Ҳусайн дар таърих бо ҳарфи сиёҳ менависанд ӯ ҳатто ба кӯдакон раҳм надошт ӯ то он дараҷа бераҳм буд, ки ҳатто занҳои ҳомиладорро бераҳмона ба ҳалокат мерасонд.&nbsp; Хулоса: Амир Ҳусайн давлати Сарбадоронро хеле азобҳои гуногун дода онҳоро ба як бераҳми бузург ба ҳалокат расонд.', '2022-05-23 00:00:00.000000', 1, 7, 54),
(28, '<p><font color=\"#000000\"><span style=\"font-size: 17.6px;\">&nbsp;Дини ислом дар Мовароуннаҳру Хуросон хеле пеш рафта буд. Дини ислом дар давраи Сосониён пайдо шудааст. Соли 632 Муҳаммад пайғамбар ба Макка ва Мадина сафар карда мардумро бо розигии худ ба дини ислом даъват мекунанд.&nbsp; Мардум дини исломро қабул мекунанд. Китоби дини ислом ин китоби муқаддаси \"Қуръон\" мебошад. Маънои калимаи \"Қуръон\" аз калимаи арабӣ гифта шуда маънояш қироат кардан мебошад. Дар дини ислом 5 фарз мавҷуд аст: 1.Занот додан; 2.Рӯза доштан; 3.Таъфи Каъба; 4.Намоз хондан; 5.Садақаҳои ҷорӣ;</span></font><br></p>', '2022-05-23 00:00:00.000000', 1, 7, 56),
(29, '<p><font color=\"#000000\"><span style=\"font-size: 17.6px;\">&nbsp;Дини ислом дар Мовароуннаҳру Хуросон хеле пеш рафта буд. Дини ислом дар давраи Сосониён пайдо шудааст. Соли 632 Муҳаммад пайғамбар ба Макка ва Мадина сафар карда мардумро бо розигии худ ба дини ислом даъват мекунанд.&nbsp; Мардум дини исломро қабул мекунанд. Китоби дини ислом ин китоби муқаддаси \"Қуръон\" мебошад. Маънои калимаи \"Қуръон\" аз калимаи арабӣ гифта шуда маънояш қироат кардан мебошад. Дар дини ислом 5 фарз мавҷуд аст: 1.Занот додан; 2.Рӯза доштан; 3.Таъфи Каъба; 4.Намоз хондан; 5.Садақаҳои ҷорӣ;</span></font><br></p>', '2022-05-23 00:00:00.000000', 1, 8, 56),
(30, '<p><font color=\"#000000\"><span style=\"font-size: 17.6px;\">&nbsp;Дини ислом дар Мовароуннаҳру Хуросон хеле пеш рафта буд. Дини ислом дар давраи Сосониён пайдо шудааст. Соли 632 Муҳаммад пайғамбар ба Макка ва Мадина сафар карда мардумро бо розигии худ ба дини ислом даъват мекунанд.&nbsp; Мардум дини исломро қабул мекунанд. Китоби дини ислом ин китоби муқаддаси \"Қуръон\" мебошад. Маънои калимаи \"Қуръон\" аз калимаи арабӣ гифта шуда маънояш қироат кардан мебошад. Дар дини ислом 5 фарз мавҷуд аст: 1.Занот додан; 2.Рӯза доштан; 3.Таъфи Каъба; 4.Намоз хондан; 5.Садақаҳои ҷорӣ;</span></font><br></p>', '2022-05-23 00:00:00.000000', 1, 8, 56),
(31, '<p><font color=\"#000000\"><span style=\"font-size: 17.6px;\">Дини ислом дар Мовароуннаҳру Хуросон хеле тараққӣ карда буд. Пеш аз инро фаҳмонидан ман давлати Саффориëнро ба шумо мефаҳмонам. Он дар асри 9-10 оғоз ëфта Яъқуб ибни Лайс ва Амир ду бародарон буданд. Пеш аз давлатдорӣ онҳо касби саффрочӣ(мисгар) буданд, падари онҳо низ мисгар буд. Аз ҳамин сабаб давлатро Саффориëн мегӯянд.&nbsp; Яъқуб хеле лашкаркаши бокувват буд, онҳо хеле давлатҳои зиëде забткарданд. Соли 879 Яъқуб ибни Лайс вафот мекунад ва ба тахт бародаиаш Амир мешинад. Амирхон мисли бародараш хеле лашкаркашӣ бокувват буд.</span></font><br></p>', '2022-05-31 00:00:00.000000', 1, 6, 56);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `FIO` longtext DEFAULT NULL,
  `Login` longtext DEFAULT NULL,
  `Password` longtext DEFAULT NULL,
  `Role` longtext NOT NULL,
  `GroupId` int(11) DEFAULT NULL,
  `UserName` longtext DEFAULT NULL,
  `NormalizedUserName` longtext DEFAULT NULL,
  `Email` longtext DEFAULT NULL,
  `NormalizedEmail` longtext DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`Id`, `FIO`, `Login`, `Password`, `Role`, `GroupId`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
(1, 'Jaborova Shahlo Abduraufovna', NULL, NULL, 'Admin', 1, 'Shahlo', NULL, 'jaborova.shahlo@mail.ru', NULL, 0, NULL, NULL, 'a9fc6f35-f1f1-4b82-af03-62e534c59410', NULL, 0, 0, NULL, 0, 0),
(5, 'test', 'test', 'a999999', 'Student', NULL, 'Test', NULL, 'test@gmail.com', NULL, 1, NULL, NULL, '43569011-762c-4832-b25f-1399a47a5011', NULL, 1, 1, NULL, 1, 0),
(6, 'Kumushhon Rustamova Askarjonovna', NULL, 'A8b7c6dsh', 'Student', 2, 'Kumush', NULL, 'kumushhon.rustamova@gmail.com', NULL, 0, NULL, NULL, '57fea426-0041-431e-88d4-70ffed7aba10', NULL, 0, 0, NULL, 0, 0),
(7, 'Шофозилов  Иброҳим  Савруллоевич', NULL, 'A8b7c6dsh', 'Student', 2, 'Ibrohim', NULL, 'shofozilov.ibrohim@mail.ru', NULL, 0, NULL, NULL, 'e491b499-5aa0-435a-b9f8-19284398bed9', NULL, 0, 0, NULL, 0, 0),
(8, 'Машарифов  Ахлиддин  Баҳориддинович', NULL, 'A8b7c6dsh', 'Student', 2, 'Ахлиддин', NULL, 'masharipov.ahliddin@mail.ru', NULL, 0, NULL, NULL, '090640ed-a537-4d4c-b9ad-0888bdec784e', NULL, 0, 0, NULL, 0, 0);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `algorithms`
--
ALTER TABLE `algorithms`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `contentessays`
--
ALTER TABLE `contentessays`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ContentEssays_PredmetId` (`PredmetId`);

--
-- Индексы таблицы `cources`
--
ALTER TABLE `cources`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `examresults`
--
ALTER TABLE `examresults`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ExamResults_TopicId` (`TopicId`);

--
-- Индексы таблицы `exams`
--
ALTER TABLE `exams`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Exams_GroupId` (`GroupId`),
  ADD KEY `IX_Exams_SubjectId` (`SubjectId`);

--
-- Индексы таблицы `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Groups_CourceId` (`CourceId`),
  ADD KEY `IX_Groups_ProfessionId` (`ProfessionId`);

--
-- Индексы таблицы `lessons`
--
ALTER TABLE `lessons`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Lessons_SubjectId` (`SubjectId`);

--
-- Индексы таблицы `predmets`
--
ALTER TABLE `predmets`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `professions`
--
ALTER TABLE `professions`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `subjects`
--
ALTER TABLE `subjects`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `topicalgorithms`
--
ALTER TABLE `topicalgorithms`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_TopicAlgorithms_AlgorithmId` (`AlgorithmId`),
  ADD KEY `IX_TopicAlgorithms_TopicId` (`TopicId`);

--
-- Индексы таблицы `topics`
--
ALTER TABLE `topics`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Topics_ExamId` (`ExamId`),
  ADD KEY `IX_Topics_LessonId` (`LessonId`),
  ADD KEY `IX_Topics_StudentId` (`StudentId`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Users_GroupId` (`GroupId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `algorithms`
--
ALTER TABLE `algorithms`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `contentessays`
--
ALTER TABLE `contentessays`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `cources`
--
ALTER TABLE `cources`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `examresults`
--
ALTER TABLE `examresults`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT для таблицы `exams`
--
ALTER TABLE `exams`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `groups`
--
ALTER TABLE `groups`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `lessons`
--
ALTER TABLE `lessons`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- AUTO_INCREMENT для таблицы `predmets`
--
ALTER TABLE `predmets`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `professions`
--
ALTER TABLE `professions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `subjects`
--
ALTER TABLE `subjects`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `topicalgorithms`
--
ALTER TABLE `topicalgorithms`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT для таблицы `topics`
--
ALTER TABLE `topics`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `contentessays`
--
ALTER TABLE `contentessays`
  ADD CONSTRAINT `FK_ContentEssays_Predmets_PredmetId` FOREIGN KEY (`PredmetId`) REFERENCES `predmets` (`Id`);

--
-- Ограничения внешнего ключа таблицы `examresults`
--
ALTER TABLE `examresults`
  ADD CONSTRAINT `FK_ExamResults_Topics_TopicId` FOREIGN KEY (`TopicId`) REFERENCES `topics` (`Id`);

--
-- Ограничения внешнего ключа таблицы `exams`
--
ALTER TABLE `exams`
  ADD CONSTRAINT `FK_Exams_Groups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `groups` (`Id`),
  ADD CONSTRAINT `FK_Exams_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `subjects` (`Id`);

--
-- Ограничения внешнего ключа таблицы `groups`
--
ALTER TABLE `groups`
  ADD CONSTRAINT `FK_Groups_Cources_CourceId` FOREIGN KEY (`CourceId`) REFERENCES `cources` (`Id`),
  ADD CONSTRAINT `FK_Groups_Professions_ProfessionId` FOREIGN KEY (`ProfessionId`) REFERENCES `professions` (`Id`);

--
-- Ограничения внешнего ключа таблицы `lessons`
--
ALTER TABLE `lessons`
  ADD CONSTRAINT `FK_Lessons_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `subjects` (`Id`);

--
-- Ограничения внешнего ключа таблицы `topicalgorithms`
--
ALTER TABLE `topicalgorithms`
  ADD CONSTRAINT `FK_TopicAlgorithms_Algorithms_AlgorithmId` FOREIGN KEY (`AlgorithmId`) REFERENCES `algorithms` (`Id`),
  ADD CONSTRAINT `FK_TopicAlgorithms_Topics_TopicId` FOREIGN KEY (`TopicId`) REFERENCES `topics` (`Id`);

--
-- Ограничения внешнего ключа таблицы `topics`
--
ALTER TABLE `topics`
  ADD CONSTRAINT `FK_Topics_Exams_ExamId` FOREIGN KEY (`ExamId`) REFERENCES `exams` (`Id`),
  ADD CONSTRAINT `FK_Topics_Lessons_LessonId` FOREIGN KEY (`LessonId`) REFERENCES `lessons` (`Id`),
  ADD CONSTRAINT `FK_Topics_Users_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `users` (`Id`);

--
-- Ограничения внешнего ключа таблицы `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `FK_Users_Groups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `groups` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
