-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               10.4.11-MariaDB - mariadb.org binary distribution
-- Операционная система:         Win64
-- HeidiSQL Версия:              10.3.0.5771
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Дамп структуры базы данных prokat_avto
CREATE DATABASE IF NOT EXISTS `prokat_avto` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `prokat_avto`;

-- Дамп структуры для таблица prokat_avto.acts
CREATE TABLE IF NOT EXISTS `acts` (
  `ID_Act` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '' COMMENT 'Наименование акта',
  `Date` date NOT NULL COMMENT 'Дата документа',
  `ID_Dogovora` int(11) NOT NULL COMMENT 'ID Договора',
  `ID_Sotrudnika` int(11) NOT NULL COMMENT 'ID Сотрудника',
  `ID_Avto` int(11) NOT NULL COMMENT 'ID Автомобиля',
  `Comments` mediumtext NOT NULL COMMENT 'Комментарий',
  PRIMARY KEY (`ID_Act`),
  UNIQUE KEY `Name` (`Name`,`ID_Dogovora`),
  KEY `ID_Avto` (`ID_Avto`),
  KEY `ID_Sotrudnika` (`ID_Sotrudnika`),
  KEY `ID_Dogovora` (`ID_Dogovora`),
  CONSTRAINT `acts_ibfk_1` FOREIGN KEY (`ID_Sotrudnika`) REFERENCES `sotrudniki` (`ID_Sotrudnika`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `acts_ibfk_2` FOREIGN KEY (`ID_Avto`) REFERENCES `avtopark` (`ID_Avto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `acts_ibfk_3` FOREIGN KEY (`ID_Dogovora`) REFERENCES `dogovory` (`ID_Dogovora`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COMMENT='Акты приемки и сдачи авто';

-- Дамп данных таблицы prokat_avto.acts: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `acts` DISABLE KEYS */;
INSERT IGNORE INTO `acts` (`ID_Act`, `Name`, `Date`, `ID_Dogovora`, `ID_Sotrudnika`, `ID_Avto`, `Comments`) VALUES
	(13, 'Акт осмотра автомобиля при сдаче в аренду', '2020-03-20', 18, 1, 8, 'Выявлена небольшая вмятина около арки левого переднего крыла.'),
	(14, 'Акт осмотра автомобиля при сдаче в аренду', '2020-03-20', 19, 1, 3, 'Дефекты не выявлены');
/*!40000 ALTER TABLE `acts` ENABLE KEYS */;

-- Дамп структуры для таблица prokat_avto.avtopark
CREATE TABLE IF NOT EXISTS `avtopark` (
  `ID_Avto` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID Автомобиля',
  `Marka` varchar(30) NOT NULL COMMENT 'Марка',
  `Model` varchar(30) NOT NULL COMMENT 'Модель',
  `Categoria_Avto` varchar(30) NOT NULL COMMENT 'Категория авто',
  `ID_Price` int(11) NOT NULL COMMENT 'Тип авто',
  `Gos_Znak` varchar(30) NOT NULL COMMENT 'Гос. знак',
  `VIN_Nomer` varchar(17) NOT NULL DEFAULT '' COMMENT 'VIN номер',
  `Stoimost` decimal(10,2) NOT NULL DEFAULT 0.00 COMMENT 'Балансовая стоимость авто',
  `Identify` varchar(9) NOT NULL DEFAULT 'Свободна' COMMENT 'Идентификатор занятости',
  PRIMARY KEY (`ID_Avto`),
  KEY `ID_Type` (`ID_Price`),
  CONSTRAINT `avtopark_ibfk_1` FOREIGN KEY (`ID_Price`) REFERENCES `price` (`ID_Price`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='Справочник автомобилей';

-- Дамп данных таблицы prokat_avto.avtopark: ~6 rows (приблизительно)
/*!40000 ALTER TABLE `avtopark` DISABLE KEYS */;
INSERT IGNORE INTO `avtopark` (`ID_Avto`, `Marka`, `Model`, `Categoria_Avto`, `ID_Price`, `Gos_Znak`, `VIN_Nomer`, `Stoimost`, `Identify`) VALUES
	(3, 'BMW', '525xi', 'B', 2, '0475TH-3', 'FESDFH8RFVB165312', 7350.00, 'Занята'),
	(5, 'Scania', '720 TopLine', 'C', 2, 'HT8645-1', 'EFRVSR5BFDV653153', 65000.00, 'Свободна'),
	(8, 'Nissan', 'Sunny Y10 2,0dLX', 'B', 1, '0537AT-3', 'WDWEVF5DSCC132132', 1350.00, 'Занята'),
	(9, 'Hors-Motors', 'Alpha 50c', 'AM', 1, '6564АУ-3', 'FEDSVS5FEFD645123', 400.00, 'Свободна'),
	(10, 'BMW', 'S1000RR', 'A', 2, '1000MM-3', 'FEDSCZ1QWRG231456', 5750.00, 'Свободна'),
	(11, 'Minsk', 'D4 125', 'A1', 1, '1459TK-3', 'EDSVWA3DWGN214630', 1000.00, 'Свободна');
/*!40000 ALTER TABLE `avtopark` ENABLE KEYS */;

-- Дамп структуры для таблица prokat_avto.clienty
CREATE TABLE IF NOT EXISTS `clienty` (
  `ID_Clienta` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID Клиента',
  `Familiya` varchar(30) NOT NULL COMMENT 'Фамилия',
  `Imya` varchar(30) NOT NULL COMMENT 'Имя',
  `Otchestvo` varchar(30) NOT NULL COMMENT 'Отчество',
  `Telephone` varchar(17) NOT NULL COMMENT 'Контактный телефон',
  `Email` varchar(30) NOT NULL COMMENT 'Email',
  `Nom_Pass` varchar(9) NOT NULL COMMENT 'Номер паспорта',
  `Ident_Nom` varchar(14) NOT NULL COMMENT 'Идентификационный номер',
  PRIMARY KEY (`ID_Clienta`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='Данные о клиентах';

-- Дамп данных таблицы prokat_avto.clienty: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `clienty` DISABLE KEYS */;
INSERT IGNORE INTO `clienty` (`ID_Clienta`, `Familiya`, `Imya`, `Otchestvo`, `Telephone`, `Email`, `Nom_Pass`, `Ident_Nom`) VALUES
	(3, 'Юрченко', 'Анжелика', 'Николаевна', '+375(25)651-88-64', 'urchenko123@mail.ru', 'HB6412316', '8645153H864PB2'),
	(6, 'Ситько', 'Дарья', 'Васильевна', '+375(29)137-66-41', 'sitko@rambler.ru', 'HB8651232', '5413122H684PB2'),
	(7, 'Цыбранкова', 'Виктория', 'Александровна', '+375(44)542-31-42', 'vika@gmail.com', 'HB1243653', '4532132H876PB3');
/*!40000 ALTER TABLE `clienty` ENABLE KEYS */;

-- Дамп структуры для таблица prokat_avto.dogovory
CREATE TABLE IF NOT EXISTS `dogovory` (
  `ID_Dogovora` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID Договора',
  `Date` date NOT NULL,
  `ID_Sotrudnika` int(11) NOT NULL COMMENT 'ID Сотрудника',
  `ID_Clienta` int(11) NOT NULL COMMENT 'ID Клиента',
  `N_Arendy` date NOT NULL COMMENT 'Начало аренды',
  `K_Arendy` date NOT NULL COMMENT 'Конец аренды',
  `Summa` decimal(10,2) NOT NULL COMMENT 'Сумма',
  `ID_Avto` int(11) NOT NULL COMMENT 'ID Автомобиля',
  `Identify` varchar(17) NOT NULL DEFAULT 'Действительный',
  PRIMARY KEY (`ID_Dogovora`),
  KEY `ID_Sotrudnika` (`ID_Sotrudnika`),
  KEY `ID_Clienta` (`ID_Clienta`),
  KEY `ID_Avto` (`ID_Avto`),
  CONSTRAINT `dogovory_ibfk_1` FOREIGN KEY (`ID_Sotrudnika`) REFERENCES `sotrudniki` (`ID_Sotrudnika`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dogovory_ibfk_2` FOREIGN KEY (`ID_Clienta`) REFERENCES `clienty` (`ID_Clienta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dogovory_ibfk_3` FOREIGN KEY (`ID_Avto`) REFERENCES `avtopark` (`ID_Avto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COMMENT='Заключенные договоры';

-- Дамп данных таблицы prokat_avto.dogovory: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `dogovory` DISABLE KEYS */;
INSERT IGNORE INTO `dogovory` (`ID_Dogovora`, `Date`, `ID_Sotrudnika`, `ID_Clienta`, `N_Arendy`, `K_Arendy`, `Summa`, `ID_Avto`, `Identify`) VALUES
	(18, '2020-03-20', 1, 3, '2020-03-20', '2020-03-21', 69.85, 8, 'Действительный'),
	(19, '2020-03-20', 1, 3, '2020-03-20', '2020-03-22', 240.00, 3, 'Действительный');
/*!40000 ALTER TABLE `dogovory` ENABLE KEYS */;

-- Дамп структуры для таблица prokat_avto.doljnosti
CREATE TABLE IF NOT EXISTS `doljnosti` (
  `ID_Doljnosti` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID Должности',
  `Name` varchar(30) NOT NULL COMMENT 'Наименование',
  PRIMARY KEY (`ID_Doljnosti`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник должностей';

-- Дамп данных таблицы prokat_avto.doljnosti: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `doljnosti` DISABLE KEYS */;
INSERT IGNORE INTO `doljnosti` (`ID_Doljnosti`, `Name`) VALUES
	(1, 'Директор'),
	(2, 'Главный бухгалтер'),
	(3, 'Заместитель директора');
/*!40000 ALTER TABLE `doljnosti` ENABLE KEYS */;

-- Дамп структуры для таблица prokat_avto.prava
CREATE TABLE IF NOT EXISTS `prava` (
  `ID_Prav` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID ВУ',
  `ID_Clienta` int(11) NOT NULL COMMENT 'ID вод. прав',
  `Nom_VodPrav` varchar(9) NOT NULL DEFAULT '' COMMENT 'Номер вод. прав',
  `Otkr_Categorii` varchar(50) NOT NULL,
  PRIMARY KEY (`ID_Prav`),
  UNIQUE KEY `ID_Clienta1` (`ID_Clienta`),
  KEY `ID_Clienta` (`ID_Clienta`),
  CONSTRAINT `prava_ibfk_1` FOREIGN KEY (`ID_Clienta`) REFERENCES `clienty` (`ID_Clienta`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COMMENT='Права клиентов';

-- Дамп данных таблицы prokat_avto.prava: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `prava` DISABLE KEYS */;
INSERT IGNORE INTO `prava` (`ID_Prav`, `ID_Clienta`, `Nom_VodPrav`, `Otkr_Categorii`) VALUES
	(17, 3, 'ЗАА654132', 'AM A1 B'),
	(18, 6, 'ЗАА512416', 'AM B'),
	(20, 7, 'ЗАА645135', 'AM A1 A B C D');
/*!40000 ALTER TABLE `prava` ENABLE KEYS */;

-- Дамп структуры для таблица prokat_avto.price
CREATE TABLE IF NOT EXISTS `price` (
  `ID_Price` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID прайса',
  `Name` varchar(30) NOT NULL COMMENT 'Наименование',
  `Stoimost` decimal(10,2) NOT NULL COMMENT 'Стоимость',
  `Skidka` varchar(4) NOT NULL DEFAULT '0%' COMMENT 'Скидка',
  PRIMARY KEY (`ID_Price`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='Справочник ';

-- Дамп данных таблицы prokat_avto.price: ~5 rows (приблизительно)
/*!40000 ALTER TABLE `price` DISABLE KEYS */;
INSERT IGNORE INTO `price` (`ID_Price`, `Name`, `Stoimost`, `Skidka`) VALUES
	(1, 'Бюджетный класс', 70.00, '15%'),
	(2, 'Средний класс', 120.00, '0%'),
	(3, 'нва', 999.00, '50%'),
	(4, 'Премиум-класс', 180.00, '0%');
/*!40000 ALTER TABLE `price` ENABLE KEYS */;

-- Дамп структуры для таблица prokat_avto.sotrudniki
CREATE TABLE IF NOT EXISTS `sotrudniki` (
  `ID_Sotrudnika` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID Сотрудника',
  `Familiya` varchar(30) NOT NULL COMMENT 'Фамилия',
  `Imya` varchar(30) NOT NULL COMMENT 'Имя',
  `Otchestvo` varchar(30) NOT NULL COMMENT 'Отчество',
  `ID_Doljnosti` int(11) NOT NULL COMMENT 'ID Должности',
  `Telephone` varchar(17) NOT NULL COMMENT 'Контактный телефон',
  PRIMARY KEY (`ID_Sotrudnika`),
  KEY `ID_Doljnosti` (`ID_Doljnosti`),
  CONSTRAINT `sotrudniki_ibfk_1` FOREIGN KEY (`ID_Doljnosti`) REFERENCES `doljnosti` (`ID_Doljnosti`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='Справочник сотрудников';

-- Дамп данных таблицы prokat_avto.sotrudniki: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `sotrudniki` DISABLE KEYS */;
INSERT IGNORE INTO `sotrudniki` (`ID_Sotrudnika`, `Familiya`, `Imya`, `Otchestvo`, `ID_Doljnosti`, `Telephone`) VALUES
	(1, 'Шишков', 'Андрей', 'Алексеевич', 1, '+375(44)736-68-56'),
	(5, 'Синенок', 'Ангелина', 'Олеговна', 3, '+375(44)575-85-78');
/*!40000 ALTER TABLE `sotrudniki` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
