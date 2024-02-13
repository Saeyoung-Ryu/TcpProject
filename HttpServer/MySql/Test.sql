/*
 Navicat MySQL Data Transfer

 Source Server         : local
 Source Server Type    : MySQL
 Source Server Version : 80033
 Source Host           : localhost:3306
 Source Schema         : Test

 Target Server Type    : MySQL
 Target Server Version : 80033
 File Encoding         : 65001

 Date: 13/02/2024 16:51:21
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for dumpLog
-- ----------------------------
DROP TABLE IF EXISTS `dumpLog`;
CREATE TABLE `dumpLog` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `connectionString` varchar(255) NOT NULL,
  `tableName` varchar(60) NOT NULL,
  `time` datetime NOT NULL,
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=868 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Table structure for major
-- ----------------------------
DROP TABLE IF EXISTS `major`;
CREATE TABLE `major` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `championBasicId` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `nameKR` varchar(255) DEFAULT NULL,
  `line` varchar(255) NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `ChampBaiscId` (`championBasicId`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=172 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Table structure for tblLogMatchHistory
-- ----------------------------
DROP TABLE IF EXISTS `tblLogMatchHistory`;
CREATE TABLE `tblLogMatchHistory` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `team1Data` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `team2Data` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `time` datetime NOT NULL,
  `team1Win` int NOT NULL DEFAULT '-1',
  `team2WIn` int NOT NULL DEFAULT '-1',
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblPenaltyRoulette
-- ----------------------------
DROP TABLE IF EXISTS `tblPenaltyRoulette`;
CREATE TABLE `tblPenaltyRoulette` (
  `basicId` int NOT NULL,
  `contentName_KR` varchar(255) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblPlayer
-- ----------------------------
DROP TABLE IF EXISTS `tblPlayer`;
CREATE TABLE `tblPlayer` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `nickName` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `createTime` datetime NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxNickname` (`nickName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblPlayerRPS
-- ----------------------------
DROP TABLE IF EXISTS `tblPlayerRPS`;
CREATE TABLE `tblPlayerRPS` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `playerId` bigint NOT NULL,
  `winCount` int NOT NULL,
  PRIMARY KEY (`seq`) USING BTREE,
  UNIQUE KEY `idxPlayerId` (`playerId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblRankHistory
-- ----------------------------
DROP TABLE IF EXISTS `tblRankHistory`;
CREATE TABLE `tblRankHistory` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `userSeq` int NOT NULL,
  `time` datetime NOT NULL,
  `ranking` int NOT NULL,
  `winRate` decimal(11,2) NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `userNameTimeIdx` (`userSeq`,`time`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=197 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblServerVariable
-- ----------------------------
DROP TABLE IF EXISTS `tblServerVariable`;
CREATE TABLE `tblServerVariable` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `value` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblUser
-- ----------------------------
DROP TABLE IF EXISTS `tblUser`;
CREATE TABLE `tblUser` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `suid` bigint NOT NULL,
  `loginId` varchar(255) NOT NULL,
  `loginPassword` varchar(255) NOT NULL,
  `nickName` varchar(255) NOT NULL,
  `createTime` datetime NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxSuid` (`suid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Table structure for tblUserInfo
-- ----------------------------
DROP TABLE IF EXISTS `tblUserInfo`;
CREATE TABLE `tblUserInfo` (
  `seq` int NOT NULL AUTO_INCREMENT,
  `userName` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `createTime` datetime NOT NULL,
  `linkedMail` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=96 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Table structure for tblUserWinnrateHistory
-- ----------------------------
DROP TABLE IF EXISTS `tblUserWinnrateHistory`;
CREATE TABLE `tblUserWinnrateHistory` (
  `userSeq` int NOT NULL,
  `lineType` int NOT NULL,
  `winCount` int NOT NULL,
  `loseCount` int NOT NULL,
  UNIQUE KEY `IdxUserSeqLineTypeClubSeq` (`userSeq`,`lineType`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Procedure structure for spGetLogMatchHistoryList
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetLogMatchHistoryList`;
delimiter ;;
CREATE PROCEDURE `spGetLogMatchHistoryList`()
BEGIN
    SELECT * FROM tblLogMatchHistory ORDER BY seq DESC LIMIT 100;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetPlayer
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetPlayer`;
delimiter ;;
CREATE PROCEDURE `spGetPlayer`(IN _nickname VARCHAR(255))
BEGIN
    SELECT *
    FROM tblPlayer
    WHERE nickName = _nickname limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetUserInfo
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetUserInfo`;
delimiter ;;
CREATE PROCEDURE `spGetUserInfo`(IN _userName varchar(255))
BEGIN
    SELECT * FROM tblUserInfo 
    WHERE userName = _userName;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetUserInfoApproximate
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetUserInfoApproximate`;
delimiter ;;
CREATE PROCEDURE `spGetUserInfoApproximate`(IN _userName varchar(255))
BEGIN
    SELECT * FROM tblUserInfo
    WHERE userName LIKE CONCAT(_userName, '%')
    ORDER BY LENGTH(userName), userName
    LIMIT 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetUserInfoWithMail
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetUserInfoWithMail`;
delimiter ;;
CREATE PROCEDURE `spGetUserInfoWithMail`(IN _userMail varchar(255))
BEGIN
    SELECT * FROM tblUserInfo
    WHERE linkedMail = _userMail
    LIMIT 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spGetUserWinRateHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetUserWinRateHistory`;
delimiter ;;
CREATE PROCEDURE `spGetUserWinRateHistory`(_userSeq int)
BEGIN
    select * from tblUserWinnrateHistory where userSeq = _userSeq;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spInsertLogMatchHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spInsertLogMatchHistory`;
delimiter ;;
CREATE PROCEDURE `spInsertLogMatchHistory`(_team1Data varchar(255), _team2Data varchar(255), _team1Win int, _team2Win int)
BEGIN
    INSERT INTO tblLogMatchHistory (team1Data, team2Data, time, team1Win, team2Win)
    VALUES (_team1Data, _team2Data, NOW(), _team1Win, _team2Win);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spInsertUserInfo
-- ----------------------------
DROP PROCEDURE IF EXISTS `spInsertUserInfo`;
delimiter ;;
CREATE PROCEDURE `spInsertUserInfo`(IN _userName varchar(255), IN _linkedMail varchar(255))
BEGIN
    INSERT INTO tblUserInfo (userName, linkedMail, createTime)
    VALUES (_userName, _linkedMail, NOW());
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spInsertUserWinnrateHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spInsertUserWinnrateHistory`;
delimiter ;;
CREATE PROCEDURE `spInsertUserWinnrateHistory`(IN _userSeq int, IN _lineType int, IN _winCount int, IN _loseCount int)
BEGIN
    INSERT INTO tblUserWinnrateHistory (userSeq, lineType, winCount, loseCount)
    VALUES (_userSeq, _lineType, _winCount, _loseCount)
		on duplicate key update
		`winCount` = _winCount,
		`loseCount` = _loseCount;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spPlayerRpsGet
-- ----------------------------
DROP PROCEDURE IF EXISTS `spPlayerRpsGet`;
delimiter ;;
CREATE PROCEDURE `spPlayerRpsGet`(IN _playerId BIGINT)
BEGIN
    SELECT * FROM tblPlayerRPS
    WHERE playerId = _playerId limit 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spPlayerRpsSet
-- ----------------------------
DROP PROCEDURE IF EXISTS `spPlayerRpsSet`;
delimiter ;;
CREATE PROCEDURE `spPlayerRpsSet`(IN _playerId bigint, IN _winCount int)
BEGIN
    -- Attempt to insert the new data
    INSERT INTO tblPlayerRPS (playerId, winCount)
    VALUES (_playerId, _winCount)
    ON DUPLICATE KEY UPDATE
        winCount = _winCount;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spResetRank
-- ----------------------------
DROP PROCEDURE IF EXISTS `spResetRank`;
delimiter ;;
CREATE PROCEDURE `spResetRank`()
BEGIN
    truncate tblLogMatchHistory;
    update tblUserWinnrateHistory set winCount = 0, loseCount = 0 where winCount > 0 or loseCount > 0;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetLogMatchHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetLogMatchHistory`;
delimiter ;;
CREATE PROCEDURE `spSetLogMatchHistory`(IN _time datetime, IN _team1Win int, IN _team2Win int, IN _seq int)
BEGIN
    UPDATE `tblLogMatchHistory` SET `team1Win` = `_team1Win`, `team2Win` = `_team2Win` WHERE `time` = `_time` and `seq` = `_seq`;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetPlayer
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetPlayer`;
delimiter ;;
CREATE PROCEDURE `spSetPlayer`(IN _nickname VARCHAR(255),
    IN _createTime DATETIME)
BEGIN
INSERT INTO tblPlayer(nickName, createTime)
VALUES (_nickname, _createTime);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spSetRankHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spSetRankHistory`;
delimiter ;;
CREATE PROCEDURE `spSetRankHistory`(IN _userSeq int, IN _time datetime, IN _ranking int, IN _winRate decimal(11,2))
BEGIN
    INSERT INTO tblRankHistory (userSeq, time, ranking, winRate) VALUES (_userSeq, _time, _ranking, _winRate);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for spUpdateUserInfo
-- ----------------------------
DROP PROCEDURE IF EXISTS `spUpdateUserInfo`;
delimiter ;;
CREATE PROCEDURE `spUpdateUserInfo`(_userName VARCHAR(255), _userSeq int)
BEGIN
    UPDATE `tblUserInfo` SET userName = _userName WHERE `seq` = _userSeq;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
