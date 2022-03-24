
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
);

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
);
