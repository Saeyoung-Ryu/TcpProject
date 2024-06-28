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

 Date: 28/06/2024 17:26:29
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
  `startDate` datetime DEFAULT NULL,
  `endDate` datetime DEFAULT NULL,
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
-- Table structure for tblDashBoard
-- ----------------------------
DROP TABLE IF EXISTS `tblDashBoard`;
CREATE TABLE `tblDashBoard` (
  `dashBoardSeq` int NOT NULL AUTO_INCREMENT,
  `name` varchar(32) COLLATE utf8mb4_general_ci NOT NULL,
  `createTime` datetime NOT NULL,
  PRIMARY KEY (`dashBoardSeq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblDashBoardManager
-- ----------------------------
DROP TABLE IF EXISTS `tblDashBoardManager`;
CREATE TABLE `tblDashBoardManager` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `suid` bigint NOT NULL,
  `dashBoardSeq` int NOT NULL,
  `position` int NOT NULL,
  `enable` tinyint(1) NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxSuidDashBoardSeq` (`suid`,`dashBoardSeq`),
  KEY `idxSuid` (`suid`),
  KEY `idxDashBoardSeq` (`dashBoardSeq`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblDashBoardMember
-- ----------------------------
DROP TABLE IF EXISTS `tblDashBoardMember`;
CREATE TABLE `tblDashBoardMember` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `dashBoardSeq` int NOT NULL,
  `puuid` varchar(60) COLLATE utf8mb4_general_ci NOT NULL,
  `name` varchar(12) COLLATE utf8mb4_general_ci NOT NULL,
  `enable` tinyint(1) NOT NULL,
  `supWinCount` int NOT NULL,
  `supLoseCount` int NOT NULL,
  `adcWinCount` int NOT NULL,
  `adcLoseCount` int NOT NULL,
  `midWinCount` int NOT NULL,
  `midLoseCount` int NOT NULL,
  `jgWinCount` int NOT NULL,
  `jgLoseCount` int NOT NULL,
  `topWinCount` int NOT NULL,
  `topLoseCount` int NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxDashBoardSeqPuuid` (`dashBoardSeq`,`puuid`)
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
-- Table structure for tblPlayerAttendance
-- ----------------------------
DROP TABLE IF EXISTS `tblPlayerAttendance`;
CREATE TABLE `tblPlayerAttendance` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `suid` bigint NOT NULL,
  `attendanceBasicId` int NOT NULL,
  `day` int NOT NULL,
  `updateTime` datetime NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `IdxSuid` (`suid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
-- Procedure structure for spGetDashBoardManagerWithDashBoardSeq
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetDashBoardManagerWithDashBoardSeq`;
delimiter ;;
CREATE PROCEDURE `spGetDashBoardManagerWithDashBoardSeq`(IN _dashBoardSeq int)
BEGIN
    select * from tblDashBoardManager where dashBoardSeq = _dashBoardSeq;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetDashBoardManagerWithSuid
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetDashBoardManagerWithSuid`;
delimiter ;;
CREATE PROCEDURE `spGetDashBoardManagerWithSuid`(IN _suid bigint)
BEGIN
    select * from tblDashBoardManager where suid = _suid;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetDashBoardMembers
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetDashBoardMembers`;
delimiter ;;
CREATE PROCEDURE `spGetDashBoardMembers`(IN _dashBoardSeq int)
BEGIN
    select * from tblDashBoardMember where dashBoardSeq = _dashBoardSeq;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetDashBoardWithName
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetDashBoardWithName`;
delimiter ;;
CREATE PROCEDURE `spGetDashBoardWithName`(IN _name varchar(32))
BEGIN
    SELECT *
    FROM tblDashBoard
    WHERE name = _name limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetDashBoardWithSeq
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetDashBoardWithSeq`;
delimiter ;;
CREATE PROCEDURE `spGetDashBoardWithSeq`(IN _seq int)
BEGIN
    SELECT *
    FROM tblDashBoard
    WHERE dashBoardSeq = _seq limit 1;
END
;;
delimiter ;

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
-- Procedure structure for spGetPlayerAttendance
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetPlayerAttendance`;
delimiter ;;
CREATE PROCEDURE `spGetPlayerAttendance`(IN _suid bigint)
BEGIN
    SELECT *
    FROM tblPlayerAttendance
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
-- Procedure structure for spSetDashBoard
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetDashBoard`;
delimiter ;;
CREATE PROCEDURE `spSetDashBoard`(IN _name varchar(32))
BEGIN
    INSERT INTO tblDashBoard (name, createTime)
    VALUES (_name, now())
    on duplicate key update
                         `name` = _name;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetDashBoardManager
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetDashBoardManager`;
delimiter ;;
CREATE PROCEDURE `spSetDashBoardManager`(IN _suid bigint, IN _dashBoardSeq int, IN _position int,
                                                             IN _enable tinyint(1))
BEGIN
    INSERT INTO tblDashBoardManager (suid, dashBoardSeq, position, enable)
    VALUES (_suid, _dashBoardSeq, _position, _enable)
    on duplicate key update
                         `position` = _position,
                         `enable` = _enable;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetDashBoardMember
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetDashBoardMember`;
delimiter ;;
CREATE PROCEDURE `spSetDashBoardMember`(IN _dashBoardSeq int, IN _puuid varchar(60),
                                                            IN _name varchar(12), IN _enable tinyint(1),
                                                            IN _supWinCount int, IN _supLoseCount int,
                                                            IN _adcWinCount int, IN _adcLoseCount int,
                                                            IN _midWinCount int, IN _midLoseCount int,
                                                            IN _jgWinCount int, IN _jgLoseCount int,
                                                            IN _topWinCount int, IN _topLoseCount int)
BEGIN
    INSERT INTO tblDashBoardMember (dashBoardSeq, puuid, name, enable, supWinCount, supLoseCount, adcWinCount, adcLoseCount, midWinCount, midLoseCount, jgWinCount, jgLoseCount, topWinCount, topLoseCount)
    VALUES (_dashBoardSeq, _puuid, _name, _enable, _supWinCount, _supLoseCount, _adcWinCount, _adcLoseCount, _midWinCount, _midLoseCount, _jgWinCount, _jgLoseCount, _topWinCount, _topLoseCount)
    on duplicate key update
        `name` = _name,
        `enable` = _enable,
        `supWinCount` = _supWinCount,
        `supLoseCount` = _supLoseCount,
        `adcWinCount` = _adcWinCount,
        `adcLoseCount` = _adcLoseCount,
        `midWinCount` = _midWinCount,
        `midLoseCount` = _midLoseCount,
        `jgWinCount` = _jgWinCount,
        `jgLoseCount` = _jgLoseCount,
        `topWinCount` = _topWinCount,
        `topLoseCount` = _topLoseCount;
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
-- Procedure structure for spSetPlayerAttendance
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetPlayerAttendance`;
delimiter ;;
CREATE PROCEDURE `spSetPlayerAttendance`(IN _suid bigint, IN _attendanceBasicId int, IN _day int, IN _updateTime datetime)
BEGIN
    INSERT INTO tblPlayerAttendance (suid, attendanceBasicId, day, updateTime)
    VALUES (_suid, _attendanceBasicId, _day, _updateTime)
    on duplicate key update
        `attendanceBasicId` = _attendanceBasicId,
        `day` = _day,
        `updateTime` = _updateTime;
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
