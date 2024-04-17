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

 Date: 12/04/2024 18:53:56
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

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
-- Records of tblMatchHistory
-- ----------------------------
BEGIN;
INSERT INTO `tblMatchHistory` VALUES (6, 1, '[{\"Win\":\"amy\",\"Lose\":\"samy\"},{\"Win\":\"amy2\",\"Lose\":\"samy\"},{\"Win\":\"amy4\",\"Lose\":\"samy\"},{\"Win\":\"NoNo\",\"Lose\":\"Sy1234\"},{\"Win\":\"NoNo\",\"Lose\":\"Sy1234\"},{\"Win\":\"Amy123\",\"Lose\":\"Sy1234\"}]');
INSERT INTO `tblMatchHistory` VALUES (7, 2, '[{\"Win\":\"NoNo\",\"Lose\":\"Sy1234\"},{\"Win\":\"NoNo\",\"Lose\":\"Sy1234\"}]');
INSERT INTO `tblMatchHistory` VALUES (11, 5, '[{\"Win\":\"SAMY\",\"Lose\":\"Amy123\"}]');
INSERT INTO `tblMatchHistory` VALUES (12, 4, '[{\"Win\":\"SAMY\",\"Lose\":\"Amy123\"},{\"Win\":\"Test12\",\"Lose\":\"Amy123\"},{\"Win\":\"Amy123\",\"Lose\":\"Sy1234\"}]');
INSERT INTO `tblMatchHistory` VALUES (13, 9, '[{\"Win\":\"Test12\",\"Lose\":\"Test\"},{\"Win\":\"Test12\",\"Lose\":\"Amy123\"}]');
INSERT INTO `tblMatchHistory` VALUES (14, 8, '[{\"Win\":\"Test12\",\"Lose\":\"Test\"}]');
INSERT INTO `tblMatchHistory` VALUES (17, 11, '[{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"}]');
INSERT INTO `tblMatchHistory` VALUES (18, 12, '[{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"},{\"Win\":\"Test1111\",\"Lose\":\"Test2222\"}]');
INSERT INTO `tblMatchHistory` VALUES (31, 7184487515594686481, '[{\"Win\":\"TestUser2\",\"Lose\":\"TestUser1\"}]');
INSERT INTO `tblMatchHistory` VALUES (32, 7184487329157873680, '[{\"Win\":\"TestUser2\",\"Lose\":\"TestUser1\"}]');
COMMIT;

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
  `createTime` datetime NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxSuid` (`suid`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of tblPlayer
-- ----------------------------
BEGIN;
INSERT INTO `tblPlayer` VALUES (19, 7184488619447418898, '', 1, 'RRRRR', '2024-04-12 09:52:48');
INSERT INTO `tblPlayer` VALUES (20, 7184488634827931667, '103886615978569164912', 2, 'usaeyoung9514', '2024-04-12 09:52:52');
COMMIT;

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
-- Records of tblRank
-- ----------------------------
BEGIN;
INSERT INTO `tblRank` VALUES (6, 2, 2, 0, 110);
INSERT INTO `tblRank` VALUES (7, 1, 4, 3, 108);
INSERT INTO `tblRank` VALUES (10, 5, 1, 0, 105);
INSERT INTO `tblRank` VALUES (11, 4, 1, 2, 97);
INSERT INTO `tblRank` VALUES (12, 9, 2, 0, 110);
INSERT INTO `tblRank` VALUES (13, 8, 0, 1, 96);
INSERT INTO `tblRank` VALUES (17, 11, 6, 0, 130);
INSERT INTO `tblRank` VALUES (18, 12, 0, 6, 76);
INSERT INTO `tblRank` VALUES (31, 7184487515594686481, 1, 0, 105);
INSERT INTO `tblRank` VALUES (32, 7184487329157873680, 0, 1, 96);
COMMIT;

-- ----------------------------
-- Table structure for tblServerVariable
-- ----------------------------
DROP TABLE IF EXISTS `tblServerVariable`;
CREATE TABLE `tblServerVariable` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of tblServerVariable
-- ----------------------------
BEGIN;
INSERT INTO `tblServerVariable` VALUES (1, 'Life', '5');
INSERT INTO `tblServerVariable` VALUES (2, 'MinSumValue', '10');
INSERT INTO `tblServerVariable` VALUES (3, 'MaxSumValue', '30');
INSERT INTO `tblServerVariable` VALUES (4, 'RankServerURL', 'http://localhost:8000');
INSERT INTO `tblServerVariable` VALUES (4, 'RedisServerURL', '');
COMMIT;

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
                                                   IN _nickname varchar(255), IN _createTime datetime)
BEGIN
    INSERT INTO tblPlayer (suid, accountId, loginType, nickName, createTime)
    VALUES (_suid, _accountId, _loginType, _nickname, _createTime)
    on duplicate key update
                         `suid` = _suid,
                         `accountId` = _accountId,
                         `loginType` = _loginType,
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
