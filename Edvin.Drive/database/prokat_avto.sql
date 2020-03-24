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

-- Экспортируемые данные не выделены.

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

-- Экспортируемые данные не выделены.

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

-- Экспортируемые данные не выделены.

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

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица prokat_avto.doljnosti
CREATE TABLE IF NOT EXISTS `doljnosti` (
  `ID_Doljnosti` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID Должности',
  `Name` varchar(30) NOT NULL COMMENT 'Наименование',
  PRIMARY KEY (`ID_Doljnosti`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник должностей';

-- Экспортируемые данные не выделены.

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

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица prokat_avto.price
CREATE TABLE IF NOT EXISTS `price` (
  `ID_Price` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID прайса',
  `Name` varchar(30) NOT NULL COMMENT 'Наименование',
  `Stoimost` decimal(10,2) NOT NULL COMMENT 'Стоимость',
  `Skidka` varchar(4) NOT NULL DEFAULT '0%' COMMENT 'Скидка',
  PRIMARY KEY (`ID_Price`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='Справочник ';

-- Экспортируемые данные не выделены.

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

-- Экспортируемые данные не выделены.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
