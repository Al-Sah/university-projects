CREATE DATABASE  IF NOT EXISTS `itech_labs`;
USE `itech_labs`;
-- MySQL dump 
--
-- Host: 127.0.0.1    Database: itech_labs
-- ------------------------------------------------------

--
-- Table structure for table `client`
--
DROP TABLE IF EXISTS `client`;
CREATE TABLE `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `login` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `ip` varchar(45) NOT NULL,
  `balance` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `login_UNIQUE` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
INSERT INTO `client` VALUES (1,'Simran Hibbert','AnarKiss','password','231.42.91.176',16000),(2,'Abby Burch','AstroBoy','password','231.42.91.173',2000),(3,'Katrin East','SlitherTuft','password','231.42.91.123',16500),(4,'Rhia Turner','LateNever','password','231.42.91.174',-9000),(5,'Abbey Ramos','AstraGirl','password','231.42.92.200',0),(6,'Kairon Corona','DriveTime','password','231.42.92.153',22200),(7,'Alivia Gregory','Oxonomy','password','231.42.91.201',-3000),(8,'Kya Howell','SmokePlumes','password','231.42.91.202',-500),(9,'Mia Williams','MutantFate','password','231.42.91.203',-1000),(10,'Isabella Thomas','Maggotta','password','231.42.93.167',8000),(11,'Sophie Smith','MuttonChops','password','231.42.93.134',4500),(12,'Tyson Lister','Fusecrush','password','231.42.93.117',0),(13,'Asmaa Tierney','Outriggr','password','231.42.93.178',450),(14,'Filip Wynn','Belizard','password','231.42.93.134',800),(15,'Montague Kline','BrutalGenie','password','231.42.93.186',15000),(16,'Rochelle Rowley','Klaxxon','password','231.42.94.176',-8750),(17,'Leela Clarkson','CitarNosis','password','231.42.95.176',4800),(18,'Bodhi Bowler','BeardDemon','password','231.42.95.255',0);
UNLOCK TABLES;

--
-- Table structure for table `seanse`
--

DROP TABLE IF EXISTS `seanse`;
CREATE TABLE `seanse` (
  `id` int NOT NULL AUTO_INCREMENT,
  `start` datetime NOT NULL,
  `stop` datetime DEFAULT NULL,
  `in_traffic` float NOT NULL,
  `out_traffic` float NOT NULL,
  `client_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_seanse_idx` (`client_id`),
  CONSTRAINT `fk_seanse` FOREIGN KEY (`client_id`) REFERENCES `client` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=114 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `seanse`
--

LOCK TABLES `seanse` WRITE;
INSERT INTO `seanse` VALUES (1,'2022-03-15 14:00:45','2015-04-03 14:25:23',12345,1024,1),(86,'2022-03-15 16:13:54','2022-03-15 17:00:12',2048,26234,1),(87,'2022-03-15 20:42:45','2022-03-15 21:08:13',1054,3245,1),(88,'2022-03-15 21:13:13','2022-03-15 22:56:59',456,22044,1),(89,'2022-03-15 21:25:24','2022-03-15 21:26:24',5302,14478,1),(90,'2022-03-15 20:42:45','2022-03-15 21:08:13',1054,3246,1),(91,'2022-03-09 11:24:37','2022-03-09 12:05:24',2048,14512,2),(92,'2022-03-09 16:25:57','2022-03-09 18:45:12',22484,16200,2),(93,'2022-03-10 09:15:05','2022-03-10 15:00:00',30246,94560,2),(94,'2022-03-11 23:45:23','2022-03-12 00:34:22',2048,2048,2),(95,'2022-03-02 09:54:02','2022-03-02 19:30:16',53268,64332,3),(96,'2022-03-24 18:24:53','2022-03-24 06:00:30',4218,35682,4),(97,'2022-03-22 16:13:54','2022-03-22 17:00:00',2048,26234,4),(98,'2022-03-06 10:00:00','2022-03-03 17:00:00',32768,32768,4),(99,'2022-02-24 05:00:00','2022-02-24 23:00:00',65536,1024,5),(100,'2022-03-24 06:00:30','2022-03-24 10:00:30',1024,65536,5),(101,'2022-03-16 10:15:24','2022-03-16 18:55:55',5325,63478,7),(102,'2022-03-17 02:00:52','2022-03-17 12:53:35',27285,64684,7),(103,'2022-03-17 12:54:35','2022-03-17 23:34:14',53566,13542,7),(104,'2022-03-20 16:00:00','2022-03-20 17:00:00',2048,2048,7),(105,'2022-03-20 18:00:00','2022-03-20 19:00:00',2048,2048,7),(106,'2022-03-20 20:00:00','2022-03-20 21:00:00',2048,2048,7),(107,'2022-03-26 16:13:54','2022-03-26 22:22:12',2248,2222,8),(108,'2022-03-27 07:04:45','2022-03-27 19:14:36',65536,26434,8),(109,'2022-03-28 09:20:13','2022-03-28 18:07:30',74536,2574,8),(110,'2022-03-10 13:21:52','2022-03-10 13:22:12',1024,64,9),(111,'2022-03-05 12:00:00','2022-03-06 12:00:00',65536,65536,10),(112,'2022-03-15 12:15:24','2022-03-15 13:23:47',2042,15646,11),(113,'2022-03-15 16:33:34','2022-03-15 18:08:42',634,12600,11);
UNLOCK TABLES;
