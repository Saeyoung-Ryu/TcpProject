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

 Date: 16/02/2024 18:43:43
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tblMatchHistory
-- ----------------------------
DROP TABLE IF EXISTS `tblMatchHistory`;
CREATE TABLE `tblMatchHistory` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `playerSeq` bigint NOT NULL,
  `data` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxPlayerSeq` (`playerSeq`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of tblMatchHistory
-- ----------------------------
BEGIN;
INSERT INTO `tblMatchHistory` VALUES (6, 1, '{\"1\":{\"1\":\"amy\",\"2\":\"samy\"},\"2\":{\"1\":\"amy2\",\"2\":\"samy\"},\"3\":{\"1\":\"amy4\",\"2\":\"samy\"}}');
COMMIT;

-- ----------------------------
-- Table structure for tblPlayer
-- ----------------------------
DROP TABLE IF EXISTS `tblPlayer`;
CREATE TABLE `tblPlayer` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `nickName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `createTime` datetime NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxSeq` (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of tblPlayer
-- ----------------------------
BEGIN;
INSERT INTO `tblPlayer` VALUES (1, 'Sy1234', '2024-02-13 05:40:41');
INSERT INTO `tblPlayer` VALUES (2, 'Amy', '2024-02-13 06:56:33');
INSERT INTO `tblPlayer` VALUES (3, 'Sy12345', '2024-02-13 06:56:38');
INSERT INTO `tblPlayer` VALUES (4, 'Amy123', '2024-02-13 06:56:33');
INSERT INTO `tblPlayer` VALUES (5, 'SAMY', '2024-02-16 07:39:51');
INSERT INTO `tblPlayer` VALUES (6, 'SAMY123', '2024-02-16 07:44:33');
INSERT INTO `tblPlayer` VALUES (7, 'SAMY1234', '2024-02-16 07:52:53');
COMMIT;

-- ----------------------------
-- Table structure for tblRank
-- ----------------------------
DROP TABLE IF EXISTS `tblRank`;
CREATE TABLE `tblRank` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `playerSeq` bigint NOT NULL,
  `winCount` int NOT NULL,
  `loseCount` int NOT NULL,
  `point` int NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxPlayerSeq` (`playerSeq`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of tblRank
-- ----------------------------
BEGIN;
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
COMMIT;

-- ----------------------------
-- Procedure structure for spGetMatchHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetMatchHistory`;
delimiter ;;
CREATE PROCEDURE `spGetMatchHistory`(IN _playerSeq bigint)
BEGIN
    SELECT *
    FROM tblMatchHistory
    WHERE playerSeq = _playerSeq limit 1;
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
-- Procedure structure for spGetRank
-- ----------------------------
DROP PROCEDURE IF EXISTS `spGetRank`;
delimiter ;;
CREATE PROCEDURE `spGetRank`(IN _playerSeq bigint)
BEGIN
    SELECT *
    FROM tblRank
    WHERE playerSeq = _playerSeq limit 1;
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
CREATE PROCEDURE `spSetMatchHistory`(IN _playerSeq bigint, IN _data varchar(255))
BEGIN
    INSERT INTO tblMatchHistory (playerSeq, data)
    VALUES (_playerSeq, _data)
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
CREATE PROCEDURE `spSetPlayer`(IN _seq bigint, IN _nickname varchar(255), IN _createTime datetime)
BEGIN
    INSERT INTO tblPlayer (seq, nickName, createTime)
    VALUES (_seq, _nickname, _createTime)
    on duplicate key update
                         `seq` = _seq,
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
CREATE PROCEDURE `spSetRank`(IN _playerSeq bigint, IN _winCount int, IN _loseCount int, IN _point int)
BEGIN
    INSERT INTO tblRank (playerSeq, winCount, loseCount, point)
    VALUES (_playerSeq, _winCount, _loseCount, _point)
    on duplicate key update
                         `winCount` = _winCount,
                         `loseCount` = _loseCount,
                         `point` = _point;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
