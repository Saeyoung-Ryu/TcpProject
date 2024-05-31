/*
 Navicat MySQL Data Transfer

 Source Server         : local
 Source Server Type    : MySQL
 Source Server Version : 80033
 Source Host           : localhost:3306
 Source Schema         : ProjectDB

 Target Server Type    : MySQL
 Target Server Version : 80033
 File Encoding         : 65001

 Date: 31/05/2024 18:57:21
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tblAttendanceBasic
-- ----------------------------
DROP TABLE IF EXISTS `tblAttendanceBasic`;
CREATE TABLE `tblAttendanceBasic` (
  `basicId` int NOT NULL,
  `days` int NOT NULL,
  `rewardId` int DEFAULT NULL,
  PRIMARY KEY (`basicId`,`days`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblAttendanceEventSchedule
-- ----------------------------
DROP TABLE IF EXISTS `tblAttendanceEventSchedule`;
CREATE TABLE `tblAttendanceEventSchedule` (
  `attendanceBasicId` int DEFAULT NULL,
  `startDate` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `endDate` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `enable` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblAttendanceReward
-- ----------------------------
DROP TABLE IF EXISTS `tblAttendanceReward`;
CREATE TABLE `tblAttendanceReward` (
  `attendanceRewardId` int NOT NULL,
  `itemId` int DEFAULT NULL,
  `count` int DEFAULT NULL,
  PRIMARY KEY (`attendanceRewardId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblImportToMySql
-- ----------------------------
DROP TABLE IF EXISTS `tblImportToMySql`;
CREATE TABLE `tblImportToMySql` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `ipAddress` varchar(45) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `tableName` text COLLATE utf8mb4_general_ci,
  `host` varchar(45) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `time` datetime DEFAULT NULL,
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblMatchHistory
-- ----------------------------
DROP TABLE IF EXISTS `tblMatchHistory`;
CREATE TABLE `tblMatchHistory` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `suid` bigint NOT NULL,
  `data` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxPlayerSuid` (`suid`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblPlayer
-- ----------------------------
DROP TABLE IF EXISTS `tblPlayer`;
CREATE TABLE `tblPlayer` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `suid` bigint NOT NULL,
  `accountId` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `loginType` int NOT NULL,
  `nickName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `email` varchar(60) COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(60) COLLATE utf8mb4_general_ci NOT NULL,
  `passwordSalt` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `createTime` datetime NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxSuid` (`suid`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblPlayerProfile
-- ----------------------------
DROP TABLE IF EXISTS `tblPlayerProfile`;
CREATE TABLE `tblPlayerProfile` (
  `suid` bigint NOT NULL,
  `cash` bigint NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblRank
-- ----------------------------
DROP TABLE IF EXISTS `tblRank`;
CREATE TABLE `tblRank` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `suid` bigint NOT NULL,
  `winCount` int NOT NULL,
  `loseCount` int NOT NULL,
  `point` int NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxPlayerSuid` (`suid`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblServerVariable
-- ----------------------------
DROP TABLE IF EXISTS `tblServerVariable`;
CREATE TABLE `tblServerVariable` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Procedure structure for spGetMatchHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetMatchHistory`;
delimiter ;;
CREATE PROCEDURE `spGetMatchHistory`(IN _suid bigint)
BEGIN
    SELECT *
    FROM tblMatchHistory
    WHERE suid = _suid limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetPlayerWithAccountId
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetPlayerWithAccountId`;
delimiter ;;
CREATE PROCEDURE `spGetPlayerWithAccountId`(IN _accountId varchar(255), IN _loginType int)
BEGIN
    SELECT *
    FROM tblPlayer
    WHERE `accountId` = _accountId and `loginType` = _loginType limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetPlayerWithEmail
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetPlayerWithEmail`;
delimiter ;;
CREATE PROCEDURE `spGetPlayerWithEmail`(IN _email varchar(255))
BEGIN
    SELECT *
    FROM tblPlayer
    WHERE `email` = _email limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetPlayerWithNickname
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetPlayerWithNickname`;
delimiter ;;
CREATE PROCEDURE `spGetPlayerWithNickname`(IN _nickname varchar(255))
BEGIN
    SELECT *
    FROM tblPlayer
    WHERE nickName = _nickname limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetPlayerWithSeq
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetPlayerWithSeq`;
delimiter ;;
CREATE PROCEDURE `spGetPlayerWithSeq`(IN _seq bigint)
BEGIN
    SELECT *
    FROM tblPlayer
    WHERE seq = _seq limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetPlayerWithSuid
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetPlayerWithSuid`;
delimiter ;;
CREATE PROCEDURE `spGetPlayerWithSuid`(IN _suid bigint)
BEGIN
    SELECT *
    FROM tblPlayer
    WHERE suid = _suid limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetRank
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetRank`;
delimiter ;;
CREATE PROCEDURE `spGetRank`(IN _suid bigint)
BEGIN
    SELECT *
    FROM tblRank
    WHERE suid = _suid limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetRankList
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetRankList`;
delimiter ;;
CREATE PROCEDURE `spGetRankList`()
BEGIN
    SELECT *
    FROM tblRank;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spInsertPlayer
-- ----------------------------
DROP PROCEDURE IF EXISTS `spInsertPlayer`;
delimiter ;;
CREATE PROCEDURE `spInsertPlayer`(IN _nickname varchar(255), IN _createTime datetime)
BEGIN
    INSERT INTO tblPlayer(nickName, createTime)
    VALUES (_nickname, _createTime);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetMatchHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetMatchHistory`;
delimiter ;;
CREATE PROCEDURE `spSetMatchHistory`(IN _suid bigint, IN _data varchar(255))
BEGIN
    INSERT INTO tblMatchHistory (suid, data)
    VALUES (_suid, _data)
    on duplicate key update
        `data` = _data;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetPlayer
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetPlayer`;
delimiter ;;
CREATE PROCEDURE `spSetPlayer`(IN _suid bigint, IN _accountId varchar(255), IN _loginType int,
                                                   IN _nickname varchar(255), IN _email varchar(60),
                                                   IN _password varchar(60), IN _passwordSalt varchar(20),
                                                   IN _createTime datetime)
BEGIN
    INSERT INTO tblPlayer (suid, accountId, loginType, nickName, email, password, passwordSalt, createTime)
    VALUES (_suid, _accountId, _loginType, _nickname, _email, _password, _passwordSalt, _createTime)
    on duplicate key update
                         `suid` = _suid,
                         `accountId` = _accountId,
                         `loginType` = _loginType,
                         `email` = _email,
                         `password` = _password,
                         `passwordSalt` = _passwordSalt,
                         `nickName` = _nickname,
                         `createTime` = _createTime;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetRank
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetRank`;
delimiter ;;
CREATE PROCEDURE `spSetRank`(IN _suid bigint, IN _winCount int, IN _loseCount int, IN _point int)
BEGIN
    INSERT INTO tblRank (suid, winCount, loseCount, point)
    VALUES (_suid, _winCount, _loseCount, _point)
    on duplicate key update
                         `winCount` = _winCount,
                         `loseCount` = _loseCount,
                         `point` = _point;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
