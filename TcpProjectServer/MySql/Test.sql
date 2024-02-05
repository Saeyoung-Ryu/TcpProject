SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tblUser
-- ----------------------------
DROP TABLE IF EXISTS `tblUser`;
CREATE TABLE `tblUser` (
                           `seq` bigint(20) NOT NULL AUTO_INCREMENT,
                           `suid` bigint(20) NOT NULL,
                           `loginId` varchar(255) NOT NULL,
                           `loginPassword` varchar(255) NOT NULL,
                            `nickName` varchar(255) NOT NULL,
                           `createTime` datetime NOT NULL,
                           PRIMARY KEY (`seq`),
                           UNIQUE KEY `idxSuid` (`suid`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;