CREATE DATABASE  IF NOT EXISTS `gestaoanimal` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `gestaoanimal`;
-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: gestaoanimal
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `agendamedicamento`
--

DROP TABLE IF EXISTS `agendamedicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agendamedicamento` (
  `idAgendamento` int NOT NULL AUTO_INCREMENT,
  `frequencia` int DEFAULT NULL,
  `dataInicio` date DEFAULT NULL,
  `dataTermino` date DEFAULT NULL,
  `intervalo` int DEFAULT NULL,
  `idPessoa` int NOT NULL,
  `idAnimal` int NOT NULL,
  `idMedicamento` int NOT NULL,
  `idConsulta` int NOT NULL,
  `dosagem` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idAgendamento`),
  KEY `fk_TB_AGENDA_MEDICAMENTO_TB_PESSOA1_idx` (`idPessoa`),
  KEY `fk_TB_AGENDA_MEDICAMENTO_TB_ANIMAL1_idx` (`idAnimal`),
  KEY `fk_AgendaMedicamento_Medicamento1_idx` (`idMedicamento`),
  KEY `fk_AgendaMedicamento_Consulta1_idx` (`idConsulta`),
  CONSTRAINT `fk_AgendaMedicamento_Consulta1` FOREIGN KEY (`idConsulta`) REFERENCES `consulta` (`idConsulta`),
  CONSTRAINT `fk_AgendaMedicamento_Medicamento1` FOREIGN KEY (`idMedicamento`) REFERENCES `medicamento` (`idMedicamento`),
  CONSTRAINT `fk_TB_AGENDA_MEDICAMENTO_TB_ANIMAL1` FOREIGN KEY (`idAnimal`) REFERENCES `animal` (`idAnimal`),
  CONSTRAINT `fk_TB_AGENDA_MEDICAMENTO_TB_PESSOA1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendamedicamento`
--

LOCK TABLES `agendamedicamento` WRITE;
/*!40000 ALTER TABLE `agendamedicamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `agendamedicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `animal`
--

DROP TABLE IF EXISTS `animal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animal` (
  `idAnimal` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `raca` varchar(45) DEFAULT NULL,
  `dataNascimento` date DEFAULT NULL,
  `sexo` char(1) DEFAULT NULL,
  `peso` float DEFAULT NULL,
  `foto` blob,
  `status` char(1) DEFAULT NULL,
  `castrado` tinyint DEFAULT NULL,
  `falecido` tinyint DEFAULT NULL,
  `idPessoa` int NOT NULL,
  `idOrganizacao` int NOT NULL,
  `idEspecieAnimal` int NOT NULL,
  `idLote` int NOT NULL,
  PRIMARY KEY (`idAnimal`),
  KEY `fk_TB_ANIMAL_TB_PESSOA_idx` (`idPessoa`),
  KEY `fk_TB_ANIMAL_TB_ORGANIZACAO1_idx` (`idOrganizacao`),
  KEY `fk_Animal_EspecieAnimal1_idx` (`idEspecieAnimal`),
  KEY `fk_Animal_Lote1_idx` (`idLote`),
  CONSTRAINT `fk_Animal_EspecieAnimal1` FOREIGN KEY (`idEspecieAnimal`) REFERENCES `especieanimal` (`idEspecieAnimal`),
  CONSTRAINT `fk_Animal_Lote1` FOREIGN KEY (`idLote`) REFERENCES `lote` (`idLote`),
  CONSTRAINT `fk_TB_ANIMAL_TB_ORGANIZACAO1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`),
  CONSTRAINT `fk_TB_ANIMAL_TB_PESSOA` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animal`
--

LOCK TABLES `animal` WRITE;
/*!40000 ALTER TABLE `animal` DISABLE KEYS */;
INSERT INTO `animal` VALUES (1,'Francisco','RND','2018-06-06','m',7,NULL,NULL,0,0,1,1,1,1),(7,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(8,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(9,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(10,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(11,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(12,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(13,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(14,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(15,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(16,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(17,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(18,'Bob','coelho','2020-08-03','M',3,'',NULL,0,0,1,1,2,1),(21,'Pedro','Peluda','2021-06-27','M',5,'','1',0,0,3,1,3,1);
/*!40000 ALTER TABLE `animal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aplicamedicamento`
--

DROP TABLE IF EXISTS `aplicamedicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aplicamedicamento` (
  `idAplicaMedicamento` int NOT NULL AUTO_INCREMENT,
  `dosagem` varchar(45) NOT NULL,
  `dataAplicacao` date NOT NULL,
  `horario` time NOT NULL,
  `idPessoa` int NOT NULL,
  `idAnimal` int NOT NULL,
  `idMedicamento` int NOT NULL,
  `observacoes` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`idAplicaMedicamento`),
  KEY `fk_TB_APLICAMEDICAMENTO_TB_PESSOA1_idx` (`idPessoa`),
  KEY `fk_AplicaMedicamento_Animal1_idx` (`idAnimal`),
  KEY `fk_AplicaMedicamento_Medicamento1_idx` (`idMedicamento`),
  CONSTRAINT `fk_AplicaMedicamento_Animal1` FOREIGN KEY (`idAnimal`) REFERENCES `animal` (`idAnimal`),
  CONSTRAINT `fk_AplicaMedicamento_Medicamento1` FOREIGN KEY (`idMedicamento`) REFERENCES `medicamento` (`idMedicamento`),
  CONSTRAINT `fk_TB_APLICAMEDICAMENTO_TB_PESSOA1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aplicamedicamento`
--

LOCK TABLES `aplicamedicamento` WRITE;
/*!40000 ALTER TABLE `aplicamedicamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `aplicamedicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consulta`
--

DROP TABLE IF EXISTS `consulta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consulta` (
  `idConsulta` int NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) DEFAULT NULL,
  `horario` time NOT NULL,
  `data` datetime NOT NULL,
  `preco` double NOT NULL,
  `idAnimal` int NOT NULL,
  `idPessoa` int NOT NULL,
  PRIMARY KEY (`idConsulta`),
  KEY `fk_TB_CONSULTA_TB_ANIMAL1_idx` (`idAnimal`),
  KEY `fk_Consulta_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_Consulta_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`),
  CONSTRAINT `fk_TB_CONSULTA_TB_ANIMAL1` FOREIGN KEY (`idAnimal`) REFERENCES `animal` (`idAnimal`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consulta`
--

LOCK TABLES `consulta` WRITE;
/*!40000 ALTER TABLE `consulta` DISABLE KEYS */;
INSERT INTO `consulta` VALUES (6,'Ultrasson','15:44:00','2020-05-08 00:00:00',100,1,3);
/*!40000 ALTER TABLE `consulta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especieanimal`
--

DROP TABLE IF EXISTS `especieanimal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `especieanimal` (
  `idEspecieAnimal` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  PRIMARY KEY (`idEspecieAnimal`),
  UNIQUE KEY `nome_UNIQUE` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especieanimal`
--

LOCK TABLES `especieanimal` WRITE;
/*!40000 ALTER TABLE `especieanimal` DISABLE KEYS */;
INSERT INTO `especieanimal` VALUES (2,'Cachorro'),(3,'Coelho'),(1,'Gato'),(4,'Tartaruga');
/*!40000 ALTER TABLE `especieanimal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exame`
--

DROP TABLE IF EXISTS `exame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exame` (
  `idExame` int NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) NOT NULL,
  `data` datetime NOT NULL,
  `observacoes` varchar(100) NOT NULL,
  `idConsulta` int NOT NULL,
  `idAnimal` int NOT NULL,
  `idTipoExame` int NOT NULL,
  PRIMARY KEY (`idExame`),
  KEY `fk_TB_EXAME_TB_CONSULTA1_idx` (`idConsulta`),
  KEY `fk_TB_EXAME_TB_ANIMAL1_idx` (`idAnimal`),
  KEY `fk_Exame_TipoExame1_idx` (`idTipoExame`),
  CONSTRAINT `fk_Exame_TipoExame1` FOREIGN KEY (`idTipoExame`) REFERENCES `tipoexame` (`idTipoExame`),
  CONSTRAINT `fk_TB_EXAME_TB_ANIMAL1` FOREIGN KEY (`idAnimal`) REFERENCES `animal` (`idAnimal`),
  CONSTRAINT `fk_TB_EXAME_TB_CONSULTA1` FOREIGN KEY (`idConsulta`) REFERENCES `consulta` (`idConsulta`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exame`
--

LOCK TABLES `exame` WRITE;
/*!40000 ALTER TABLE `exame` DISABLE KEYS */;
/*!40000 ALTER TABLE `exame` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lote`
--

DROP TABLE IF EXISTS `lote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lote` (
  `idLote` int NOT NULL AUTO_INCREMENT,
  `numeracao` varchar(45) NOT NULL,
  PRIMARY KEY (`idLote`),
  UNIQUE KEY `numeracao_UNIQUE` (`numeracao`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lote`
--

LOCK TABLES `lote` WRITE;
/*!40000 ALTER TABLE `lote` DISABLE KEYS */;
INSERT INTO `lote` VALUES (1,'345');
/*!40000 ALTER TABLE `lote` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicamento`
--

DROP TABLE IF EXISTS `medicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicamento` (
  `idMedicamento` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `isVacina` tinyint NOT NULL,
  `idEspecieAnimal` int NOT NULL,
  PRIMARY KEY (`idMedicamento`),
  KEY `fk_Medicamento_EspecieAnimal2_idx` (`idEspecieAnimal`),
  CONSTRAINT `fk_Medicamento_EspecieAnimal2` FOREIGN KEY (`idEspecieAnimal`) REFERENCES `especieanimal` (`idEspecieAnimal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicamento`
--

LOCK TABLES `medicamento` WRITE;
/*!40000 ALTER TABLE `medicamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizacao`
--

DROP TABLE IF EXISTS `organizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizacao` (
  `idOrganizacao` int NOT NULL AUTO_INCREMENT,
  `cnpj` varchar(14) NOT NULL,
  `dataAbertura` date DEFAULT NULL,
  `ativo` tinyint DEFAULT NULL,
  `nome` varchar(100) NOT NULL,
  `telefone` varchar(40) DEFAULT NULL,
  `endereco` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizacao`
--

LOCK TABLES `organizacao` WRITE;
/*!40000 ALTER TABLE `organizacao` DISABLE KEYS */;
INSERT INTO `organizacao` VALUES (1,'1231',NULL,NULL,'Anjos de Patas',NULL,NULL,NULL),(2,'1241',NULL,NULL,'Bichos e etc',NULL,'Rua João Paulo','bichoseetc@gmail'),(8,'8621','2021-06-30',NULL,'Gatos e Cachorros','88888-7765','Rua José Carlos Marchado, 123','gatosecachorros@outlook.com'),(9,'8621','2021-06-30',NULL,'Gatos e Cachorros','88888-7765','Rua José Carlos Marchado, 123','gatosecachorros@outlook.com');
/*!40000 ALTER TABLE `organizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `idPessoa` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `senha` varchar(100) DEFAULT NULL,
  `endereco` varchar(100) DEFAULT NULL,
  `telefone` varchar(40) DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `dataNascimento` date DEFAULT NULL,
  `sexo` char(1) DEFAULT NULL,
  `ativo` tinyint DEFAULT NULL,
  `tipoPessoa` enum('A','R','O','V') DEFAULT NULL,
  `cnpj` varchar(20) DEFAULT NULL,
  `crmv` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'Lys','flordelys@gmail','2654','São José','999988776','11100099977',NULL,'F',NULL,NULL,NULL,NULL),(3,'Isabela','isa.bela@gmail.com','1234','Rua B, 405','123456789','04400077820',NULL,'F',1,NULL,NULL,NULL),(6,'José Miguel','miguelanjo@gmail','12345','Rua Carlos Augusto, 1392','99831-1938','1234567',NULL,'M',NULL,'A',NULL,NULL);
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoaorganizacao`
--

DROP TABLE IF EXISTS `pessoaorganizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoaorganizacao` (
  `idPessoa` int NOT NULL,
  `idOrganizacao` int NOT NULL,
  PRIMARY KEY (`idPessoa`,`idOrganizacao`),
  KEY `fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_ORGANIZACAO1_idx` (`idOrganizacao`),
  KEY `fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_PESSOA1_idx` (`idPessoa`),
  CONSTRAINT `fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_ORGANIZACAO1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`),
  CONSTRAINT `fk_TB_PESSOA_has_TB_ORGANIZACAO_TB_PESSOA1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoaorganizacao`
--

LOCK TABLES `pessoaorganizacao` WRITE;
/*!40000 ALTER TABLE `pessoaorganizacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `pessoaorganizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoexame`
--

DROP TABLE IF EXISTS `tipoexame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipoexame` (
  `idTipoExame` int NOT NULL AUTO_INCREMENT,
  `tipo` varchar(50) NOT NULL,
  PRIMARY KEY (`idTipoExame`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoexame`
--

LOCK TABLES `tipoexame` WRITE;
/*!40000 ALTER TABLE `tipoexame` DISABLE KEYS */;
INSERT INTO `tipoexame` VALUES (1,'Hemograma');
/*!40000 ALTER TABLE `tipoexame` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'gestaoanimal'
--

--
-- Dumping routines for database 'gestaoanimal'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-09 16:07:46
