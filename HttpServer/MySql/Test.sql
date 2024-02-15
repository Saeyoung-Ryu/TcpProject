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

 Date: 15/02/2024 18:24:57
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
) ENGINE=InnoDB AUTO_INCREMENT=872 DEFAULT CHARSET=utf8mb3;

-- ----------------------------
-- Records of dumpLog
-- ----------------------------
BEGIN;
INSERT INTO `dumpLog` VALUES (629, 'server=10.0.3.33', 'tblArtifactLevel', '2023-11-01 14:03:20');
INSERT INTO `dumpLog` VALUES (630, 'server=10.0.3.33', 'tblPackageSchedule', '2023-11-02 12:21:44');
INSERT INTO `dumpLog` VALUES (631, 'server=10.0.3.33', 'tblNotification', '2023-11-02 12:21:44');
INSERT INTO `dumpLog` VALUES (632, 'server=10.0.3.33', 'tblPackageBasic', '2023-11-08 12:37:02');
INSERT INTO `dumpLog` VALUES (633, 'server=10.0.3.33', 'tblPackageSchedule', '2023-11-08 12:37:02');
INSERT INTO `dumpLog` VALUES (634, 'server=10.0.3.33', 'tblTournamentParticipateBatter', '2023-11-08 17:49:35');
INSERT INTO `dumpLog` VALUES (635, 'server=10.0.3.33', 'tblTournamentBasic', '2023-11-08 17:49:35');
INSERT INTO `dumpLog` VALUES (636, 'server=10.0.3.33', 'tblTournament', '2023-11-08 17:49:35');
INSERT INTO `dumpLog` VALUES (637, 'server=10.0.3.33', 'tblTournamentStarReward', '2023-11-08 17:49:35');
INSERT INTO `dumpLog` VALUES (638, 'server=10.0.3.33', 'tblRockPaperScissorsBasic', '2023-11-09 11:36:12');
INSERT INTO `dumpLog` VALUES (639, 'server=10.0.3.33', 'tblNotification', '2023-11-10 19:05:18');
INSERT INTO `dumpLog` VALUES (640, 'server=10.0.3.33', 'tblCardReward', '2023-11-13 11:01:26');
INSERT INTO `dumpLog` VALUES (641, 'server=10.0.3.33', 'tblCardRewardClassGrade', '2023-11-13 11:01:26');
INSERT INTO `dumpLog` VALUES (642, 'server=10.0.3.33', 'tblCardRewardStadiumGrade', '2023-11-13 11:01:26');
INSERT INTO `dumpLog` VALUES (643, 'server=10.0.3.33', 'tblHomerunEventSchedule', '2023-11-14 11:48:07');
INSERT INTO `dumpLog` VALUES (644, 'server=10.0.3.33', 'tblNotification', '2023-11-15 17:24:46');
INSERT INTO `dumpLog` VALUES (645, 'server=10.0.3.33', 'tblNotification', '2023-11-15 18:43:31');
INSERT INTO `dumpLog` VALUES (646, 'server=10.0.3.33', 'tblNotification', '2023-11-15 18:47:28');
INSERT INTO `dumpLog` VALUES (647, 'server=10.0.3.33', 'tblNotification', '2023-11-15 18:47:46');
INSERT INTO `dumpLog` VALUES (648, 'server=10.0.3.33', 'tblClanLeagueSchedule', '2023-11-16 16:40:03');
INSERT INTO `dumpLog` VALUES (649, 'server=10.0.3.33', 'tblClanLeagueParticipantReward', '2023-11-16 16:40:03');
INSERT INTO `dumpLog` VALUES (650, 'server=10.0.3.32', 'tblRockPaperScissorsReward', '2023-11-16 17:33:29');
INSERT INTO `dumpLog` VALUES (651, 'server=10.0.3.32', 'tblMatchingConfig', '2023-11-17 12:36:27');
INSERT INTO `dumpLog` VALUES (652, 'server=10.0.3.33', 'tblRockPaperScissorsReward', '2023-11-17 17:56:51');
INSERT INTO `dumpLog` VALUES (653, 'server=10.0.3.33', 'tblAdventureMode/13적용', '2023-11-20 12:44:42');
INSERT INTO `dumpLog` VALUES (654, 'server=10.0.3.33', 'tblPackageBasic', '2023-11-21 16:29:50');
INSERT INTO `dumpLog` VALUES (655, 'server=10.0.3.33', 'tblShopBasic', '2023-11-22 11:02:58');
INSERT INTO `dumpLog` VALUES (656, 'server=10.0.3.33', 'tblShopTab', '2023-11-22 11:02:58');
INSERT INTO `dumpLog` VALUES (657, 'server=10.0.3.33', 'tblConsumableBallGoods', '2023-11-22 11:02:58');
INSERT INTO `dumpLog` VALUES (658, 'server=10.0.3.33', 'tblSingleGoodsDailyGoldPack', '2023-11-22 11:02:58');
INSERT INTO `dumpLog` VALUES (659, 'server=10.0.3.33', 'tblBoardGameBasic', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (660, 'server=10.0.3.33', 'tblDailySpinSchedule', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (661, 'server=10.0.3.33', 'tblMiniBaseballBasic', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (662, 'server=10.0.3.33', 'tblTournament', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (663, 'server=10.0.3.33', 'tblTournamentBasic', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (664, 'server=10.0.3.33', 'tblTournamentStarReward', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (665, 'server=10.0.3.33', 'tblTournamentParticipateBatter', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (666, 'server=10.0.3.33', 'tblNotification', '2023-11-23 14:25:49');
INSERT INTO `dumpLog` VALUES (667, 'server=10.0.3.33', 'tblRockPaperScissorsBasic', '2023-11-23 16:33:35');
INSERT INTO `dumpLog` VALUES (668, 'server=10.0.3.33', 'tblRockPaperScissorsReStart', '2023-11-23 16:33:35');
INSERT INTO `dumpLog` VALUES (669, 'server=10.0.3.33', 'tblRockPaperScissorsReward', '2023-11-23 16:33:35');
INSERT INTO `dumpLog` VALUES (670, 'server=10.0.3.33', 'tblRockPaperScissorsGoods', '2023-11-23 16:33:35');
INSERT INTO `dumpLog` VALUES (671, 'server=10.0.3.33', 'tblShopBasic', '2023-11-24 10:32:48');
INSERT INTO `dumpLog` VALUES (672, 'server=10.0.3.33', 'tblShopTab', '2023-11-24 10:32:48');
INSERT INTO `dumpLog` VALUES (673, 'server=10.0.3.33', 'tblConsumableBallGoods', '2023-11-24 10:32:48');
INSERT INTO `dumpLog` VALUES (674, 'server=10.0.3.133', 'tblAdFreeRewardEventSchedule', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (675, 'server=10.0.3.133', 'tblDailyPick', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (676, 'server=10.0.3.133', 'tblConsumableItemSaleSchedule', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (677, 'server=10.0.3.133', 'tblShopBoxSchedule', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (678, 'server=10.0.3.133', 'tblRewardEventSchedule', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (679, 'server=10.0.3.133', 'tblConfrontationSchedule', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (680, 'server=10.0.3.133', 'tblConfrontationBasic', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (681, 'server=10.0.3.133', 'tblSuperPassSchedule', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (682, 'server=10.0.3.133', 'tblSuperPassBasic', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (683, 'server=10.0.3.133', 'tblSuperPassFreeReward', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (684, 'server=10.0.3.133', 'tblSuperPassReward', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (685, 'server=10.0.3.133', 'tblHonorShopSchedule', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (686, 'server=10.0.3.133', 'tblHonorShopBasic', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (687, 'server=10.0.3.133', 'tblHonorShopItem', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (688, 'server=10.0.3.133', 'tblNotification', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (689, 'server=10.0.3.133', 'tblSuperSurvivalBasic', '2023-11-24 18:35:09');
INSERT INTO `dumpLog` VALUES (690, 'server=10.0.3.32', 'tblPackageItem', '2023-11-28 17:49:35');
INSERT INTO `dumpLog` VALUES (691, 'server=10.0.3.32', 'tblPackageSchedule', '2023-11-28 17:52:47');
INSERT INTO `dumpLog` VALUES (692, 'server=10.0.3.32', 'tblStepPackageSchedule', '2023-11-28 17:55:18');
INSERT INTO `dumpLog` VALUES (693, 'server=10.0.3.33', 'tblShopBasic', '2023-11-29 12:35:57');
INSERT INTO `dumpLog` VALUES (694, 'server=10.0.3.33', 'tblPackageSchedule', '2023-11-29 12:35:57');
INSERT INTO `dumpLog` VALUES (695, 'server=10.0.3.33', 'tblPackageBasic', '2023-11-29 12:35:57');
INSERT INTO `dumpLog` VALUES (696, 'server=10.0.3.33', 'tblHonorGoodsBasic', '2023-11-29 12:35:57');
INSERT INTO `dumpLog` VALUES (697, 'server=10.0.3.33', 'tblHonorShopSchedule', '2023-11-29 12:35:57');
INSERT INTO `dumpLog` VALUES (698, 'server=10.0.3.33', 'tblClanLeagueSchedule', '2023-11-30 10:30:36');
INSERT INTO `dumpLog` VALUES (699, 'server=10.0.3.33', 'tblClanLeagueParticipantReward', '2023-11-30 10:30:36');
INSERT INTO `dumpLog` VALUES (700, 'server=10.0.3.32', '', '2023-11-30 16:19:54');
INSERT INTO `dumpLog` VALUES (701, 'server=10.0.3.32', 'tblAdventureRound/14적용', '2023-11-30 16:19:54');
INSERT INTO `dumpLog` VALUES (702, 'server=10.0.3.33', 'tblNotification', '2023-12-01 18:58:23');
INSERT INTO `dumpLog` VALUES (703, 'server=10.0.3.33', 'tblPackageSchedule', '2023-12-05 17:25:54');
INSERT INTO `dumpLog` VALUES (704, 'server=10.0.3.33', 'tblPackageBasic', '2023-12-05 17:25:54');
INSERT INTO `dumpLog` VALUES (705, 'server=10.0.3.33', 'tblSkinGoods', '2023-12-05 17:25:54');
INSERT INTO `dumpLog` VALUES (706, 'server=10.0.3.33', 'tblShopBasic', '2023-12-06 17:30:42');
INSERT INTO `dumpLog` VALUES (707, 'server=10.0.3.33', 'tblPackageSchedule', '2023-12-06 17:30:42');
INSERT INTO `dumpLog` VALUES (708, 'server=10.0.3.33', 'tblPackageBasic', '2023-12-06 17:30:42');
INSERT INTO `dumpLog` VALUES (709, 'server=10.0.3.33', 'tblSkinGoods', '2023-12-06 17:30:42');
INSERT INTO `dumpLog` VALUES (710, 'server=10.0.3.33', 'tblMatchingConfig', '2023-12-06 17:54:31');
INSERT INTO `dumpLog` VALUES (711, 'server=10.0.3.32', 'tblMatchingConfig', '2023-12-06 18:16:51');
INSERT INTO `dumpLog` VALUES (712, 'server=10.0.3.33', 'tblAdFreeRewardEventSchedule', '2023-12-07 10:50:09');
INSERT INTO `dumpLog` VALUES (713, 'server=10.0.3.33', 'tblBuffEvent', '2023-12-07 10:50:09');
INSERT INTO `dumpLog` VALUES (714, 'server=10.0.3.33', 'tblBuffWinStarSchedule', '2023-12-07 10:50:09');
INSERT INTO `dumpLog` VALUES (715, 'server=10.0.3.33', 'tblBuffWinStarBasic', '2023-12-07 10:50:09');
INSERT INTO `dumpLog` VALUES (716, 'server=10.0.3.33', 'tblBuffWinStar', '2023-12-07 10:50:09');
INSERT INTO `dumpLog` VALUES (717, 'server=10.0.3.33', 'tblClanConquestBasic', '2023-12-07 10:50:09');
INSERT INTO `dumpLog` VALUES (718, 'server=10.0.3.33', 'tblClanConquestBuffBatter', '2023-12-07 10:50:09');
INSERT INTO `dumpLog` VALUES (719, 'server=10.0.3.33', 'tblNotification', '2023-12-07 15:06:43');
INSERT INTO `dumpLog` VALUES (720, 'server=10.0.3.33', 'tblRockPaperScissorsBasic', '2023-12-07 15:06:43');
INSERT INTO `dumpLog` VALUES (721, 'server=10.0.3.33', 'tblTournamentParticipateBatter', '2023-12-07 18:53:57');
INSERT INTO `dumpLog` VALUES (722, 'server=10.0.3.33', 'tblTournamentBasic', '2023-12-07 18:53:57');
INSERT INTO `dumpLog` VALUES (723, 'server=10.0.3.33', 'tblTournament', '2023-12-07 18:53:57');
INSERT INTO `dumpLog` VALUES (724, 'server=10.0.3.33', 'tblTournamentStarReward', '2023-12-07 18:53:57');
INSERT INTO `dumpLog` VALUES (725, 'server=10.0.3.33', 'tblNotification', '2023-12-13 18:14:29');
INSERT INTO `dumpLog` VALUES (726, 'server=10.0.3.33', 'tblMatchingConfig', '2023-12-13 18:47:17');
INSERT INTO `dumpLog` VALUES (727, 'server=10.0.3.33', 'tblClanLeagueSchedule', '2023-12-14 12:53:09');
INSERT INTO `dumpLog` VALUES (728, 'server=10.0.3.33', 'tblClanLeagueParticipantReward', '2023-12-14 12:53:09');
INSERT INTO `dumpLog` VALUES (729, 'server=10.0.3.33', 'tblBotMatch', '2023-12-18 18:40:24');
INSERT INTO `dumpLog` VALUES (730, 'server=10.0.3.33', 'tblShopBasic', '2023-12-19 10:50:29');
INSERT INTO `dumpLog` VALUES (731, 'server=10.0.3.33', 'tblAdventureMode/15적용', '2023-12-20 11:15:27');
INSERT INTO `dumpLog` VALUES (732, 'server=10.0.3.33', 'tblMatchingConfig', '2023-12-20 14:31:39');
INSERT INTO `dumpLog` VALUES (733, 'server=10.0.3.33', 'tblPackageBasic', '2023-12-21 16:38:03');
INSERT INTO `dumpLog` VALUES (734, 'server=10.0.3.33', 'tblShopBasic', '2023-12-22 10:41:25');
INSERT INTO `dumpLog` VALUES (735, 'server=10.0.3.133', 'tblNotification', '2023-12-22 12:15:10');
INSERT INTO `dumpLog` VALUES (736, 'server=10.0.3.33', 'tblBingoEventSchedule', '2023-12-26 10:42:18');
INSERT INTO `dumpLog` VALUES (737, 'server=10.0.3.33', 'tblBingoEvent', '2023-12-26 10:42:18');
INSERT INTO `dumpLog` VALUES (738, 'server=10.0.3.33', 'tblClanConquestBasic', '2023-12-26 10:42:18');
INSERT INTO `dumpLog` VALUES (739, 'server=10.0.3.33', 'tblClanConquestBuffBatter', '2023-12-26 10:42:18');
INSERT INTO `dumpLog` VALUES (740, 'server=10.0.3.33', 'tblRockPaperScissorsBasic', '2023-12-27 12:36:33');
INSERT INTO `dumpLog` VALUES (741, 'server=10.0.3.33', 'tblShopBasic', '2023-12-29 10:44:10');
INSERT INTO `dumpLog` VALUES (742, 'server=10.0.3.33', 'tblPackageSchedule', '2023-12-29 10:44:10');
INSERT INTO `dumpLog` VALUES (743, 'server=10.0.3.33', 'tblHonorShopSchedule', '2023-12-29 10:44:10');
INSERT INTO `dumpLog` VALUES (744, 'server=10.0.3.33', 'tblPackageBasic', '2023-12-29 11:47:21');
INSERT INTO `dumpLog` VALUES (745, 'server=10.0.3.33', 'tblPackageSchedule', '2023-12-29 12:03:24');
INSERT INTO `dumpLog` VALUES (746, 'server=10.0.3.133', 'tblRewardEventSchedule', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (747, 'server=10.0.3.133', 'tblConfrontationSchedule', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (748, 'server=10.0.3.133', 'tblConfrontationBasic', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (749, 'server=10.0.3.133', 'tblSuperPassSchedule', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (750, 'server=10.0.3.133', 'tblSuperPassBasic', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (751, 'server=10.0.3.133', 'tblSuperSurvivalBasic', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (752, 'server=10.0.3.133', 'tblDailyPick', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (753, 'server=10.0.3.133', 'tblAdFreeRewardEventSchedule', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (754, 'server=10.0.3.133', 'tblHonorShopSchedule', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (755, 'server=10.0.3.133', 'tblHonorShopBasic', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (756, 'server=10.0.3.133', 'tblHonorShopItem', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (757, 'server=10.0.3.133', 'tblNotification', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (758, 'server=10.0.3.133', 'tblConsumableItemSaleSchedule', '2023-12-29 12:26:27');
INSERT INTO `dumpLog` VALUES (759, 'server=10.0.3.33', 'tblClanLeagueSchedule', '2023-12-29 12:35:34');
INSERT INTO `dumpLog` VALUES (760, 'server=10.0.3.33', 'tblClanLeagueParticipantReward', '2023-12-29 12:35:34');
INSERT INTO `dumpLog` VALUES (761, 'server=10.0.3.33', 'tblClanLeagueClanPoint', '2023-12-29 12:35:34');
INSERT INTO `dumpLog` VALUES (762, 'server=10.0.3.33', 'tblNoneClanMatchClanPoint', '2023-12-29 12:35:34');
INSERT INTO `dumpLog` VALUES (763, 'server=10.0.3.33', 'tblNotification', '2023-12-29 12:35:34');
INSERT INTO `dumpLog` VALUES (764, 'server=10.0.3.33', 'tblNotification', '2024-01-02 12:56:04');
INSERT INTO `dumpLog` VALUES (765, 'server=10.0.3.33', 'tblPackageSchedule', '2024-01-02 15:07:04');
INSERT INTO `dumpLog` VALUES (766, 'server=10.0.3.33', 'tblPackageBasic', '2024-01-02 15:07:04');
INSERT INTO `dumpLog` VALUES (767, 'server=10.0.3.33', 'tblPackageSchedule', '2024-01-02 15:21:37');
INSERT INTO `dumpLog` VALUES (768, 'server=10.0.3.33', 'tblPackageBasic', '2024-01-02 15:21:37');
INSERT INTO `dumpLog` VALUES (769, 'server=10.0.3.33', 'tblStepPackageSchedule', '2024-01-02 15:21:37');
INSERT INTO `dumpLog` VALUES (770, 'server=10.0.3.33', 'tblConsumableBallGoods', '2024-01-02 15:21:37');
INSERT INTO `dumpLog` VALUES (771, 'server=10.0.3.33', 'tblChallengeMode', '2024-01-02 15:21:37');
INSERT INTO `dumpLog` VALUES (772, 'server=10.0.3.33', 'tblWorldChampSchedule', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (773, 'server=10.0.3.33', 'tblWorldRoyaleBasic', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (774, 'server=10.0.3.33', 'tblWorldChallengeBasic', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (775, 'server=10.0.3.33', 'tblWorldChallengeRequirement', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (776, 'server=10.0.3.33', 'tblTournamentParticipateBatter', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (777, 'server=10.0.3.33', 'tblTournamentBasic', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (778, 'server=10.0.3.33', 'tblTournament', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (779, 'server=10.0.3.33', 'tblTournamentStarReward', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (780, 'server=10.0.3.33', 'tblNotification', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (781, 'server=10.0.3.33', 'tblMiniBaseballBasic', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (782, 'server=10.0.3.33', 'tblDailySpinSchedule', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (783, 'server=10.0.3.33', 'tblBoardGameBasic', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (784, 'server=10.0.3.33', 'tblRockPaperScissorsBasic', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (785, 'server=10.0.3.33', 'tblBuffEvent', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (786, 'server=10.0.3.33', 'tblBuffGoldMultipleBasic', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (787, 'server=10.0.3.33', 'tblAdFreeRewardEventSchedule', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (788, 'server=10.0.3.33', 'tblShopTab', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (789, 'server=10.0.3.33', 'tblSingleGoodsDailyGoldPack', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (790, 'server=10.0.3.33', 'tblConsumableBallGoods', '2024-01-04 16:09:26');
INSERT INTO `dumpLog` VALUES (791, 'server=10.0.3.33', 'tblAdventureMode', '2024-01-05 15:43:07');
INSERT INTO `dumpLog` VALUES (792, 'server=10.0.3.33', 'tblClanLeagueSchedule', '2024-01-09 15:11:50');
INSERT INTO `dumpLog` VALUES (793, 'server=10.0.3.33', 'tblClanLeagueParticipantReward', '2024-01-09 15:11:50');
INSERT INTO `dumpLog` VALUES (794, 'server=10.0.3.33', 'tblClanLeagueClanPoint', '2024-01-09 15:11:50');
INSERT INTO `dumpLog` VALUES (795, 'server=10.0.3.33', 'tblNoneClanMatchClanPoint', '2024-01-09 15:11:50');
INSERT INTO `dumpLog` VALUES (796, 'server=10.0.3.33', 'tblNotification', '2024-01-09 15:11:50');
INSERT INTO `dumpLog` VALUES (797, 'server=10.0.3.33', 'tblNotification', '2024-01-12 17:06:40');
INSERT INTO `dumpLog` VALUES (798, 'server=10.0.3.33', 'tblPackageItem', '2024-01-12 17:06:40');
INSERT INTO `dumpLog` VALUES (799, 'server=10.0.3.33', 'tblStepPackageSchedule', '2024-01-12 17:06:40');
INSERT INTO `dumpLog` VALUES (800, 'server=10.0.3.33', 'tblStepPackageGoods', '2024-01-12 17:06:40');
INSERT INTO `dumpLog` VALUES (801, 'server=10.0.3.33', 'tblPackageSchedule', '2024-01-17 10:52:39');
INSERT INTO `dumpLog` VALUES (802, 'server=10.0.3.33', 'tblShopBasic', '2024-01-17 10:52:39');
INSERT INTO `dumpLog` VALUES (803, 'server=10.0.3.33', 'tblHonorShopSchedule', '2024-01-17 10:52:39');
INSERT INTO `dumpLog` VALUES (804, 'server=10.0.3.33', 'tblClanLeagueParticipantReward', '2024-01-17 10:52:39');
INSERT INTO `dumpLog` VALUES (805, 'server=10.0.3.33', 'tblClanLeagueSchedule', '2024-01-17 10:52:39');
INSERT INTO `dumpLog` VALUES (806, 'server=10.0.3.33', 'tblTournamentParticipateBatter', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (807, 'server=10.0.3.33', 'tblTournamentBasic', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (808, 'server=10.0.3.33', 'tblTournament', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (809, 'server=10.0.3.33', 'tblTournamentStarReward', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (810, 'server=10.0.3.33', 'tblMiniBaseballBasic', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (811, 'server=10.0.3.33', 'tblDailySpinSchedule', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (812, 'server=10.0.3.33', 'tblBoardGameBasic', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (813, 'server=10.0.3.33', 'tblRockPaperScissorsBasic', '2024-01-18 14:52:52');
INSERT INTO `dumpLog` VALUES (814, 'server=10.0.3.33', 'tblShopBasic', '2024-01-19 10:51:05');
INSERT INTO `dumpLog` VALUES (815, 'server=10.0.3.33', 'tblNotification', '2024-01-19 10:51:05');
INSERT INTO `dumpLog` VALUES (816, 'server=10.0.3.33', 'tblShopBasic', '2024-01-19 10:54:37');
INSERT INTO `dumpLog` VALUES (817, 'server=10.0.3.33', 'tblNotification', '2024-01-19 10:54:37');
INSERT INTO `dumpLog` VALUES (818, 'server=10.0.3.33', 'tblNotification', '2024-01-24 10:33:11');
INSERT INTO `dumpLog` VALUES (819, 'server=10.0.3.33', 'tblPackageSchedule', '2024-01-30 11:12:46');
INSERT INTO `dumpLog` VALUES (820, 'server=10.0.3.33', 'tblPackageBasic', '2024-01-30 11:12:46');
INSERT INTO `dumpLog` VALUES (821, 'server=10.0.3.33', 'tblHonorShopSchedule', '2024-01-30 11:12:46');
INSERT INTO `dumpLog` VALUES (822, 'server=10.0.3.33', 'tblBuffEvent', '2024-01-30 14:35:25');
INSERT INTO `dumpLog` VALUES (823, 'server=10.0.3.33', 'tblAdFreeRewardEventSchedule', '2024-01-30 14:35:25');
INSERT INTO `dumpLog` VALUES (824, 'server=10.0.3.33', 'tblShopTab', '2024-01-30 14:35:25');
INSERT INTO `dumpLog` VALUES (825, 'server=10.0.3.33', 'tblSingleGoodsDailyGoldPack', '2024-01-30 14:35:25');
INSERT INTO `dumpLog` VALUES (826, 'server=10.0.3.33', 'tblConsumableBallGoods', '2024-01-30 14:35:25');
INSERT INTO `dumpLog` VALUES (827, 'server=10.0.3.33', 'tblTournamentParticipateBatter', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (828, 'server=10.0.3.33', 'tblTournamentBasic', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (829, 'server=10.0.3.33', 'tblTournament', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (830, 'server=10.0.3.33', 'tblTournamentStarReward', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (831, 'server=10.0.3.33', 'tblWorldChampSchedule', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (832, 'server=10.0.3.33', 'tblWorldRoyaleBasic', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (833, 'server=10.0.3.33', 'tblWorldChallengeBasic', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (834, 'server=10.0.3.33', 'tblWorldChallengeRequirement', '2024-01-31 17:18:51');
INSERT INTO `dumpLog` VALUES (835, 'server=10.0.3.133', 'tblConfrontationSchedule', '2024-01-31 18:25:49');
INSERT INTO `dumpLog` VALUES (836, 'server=10.0.3.33', 'tblNotification', '2024-02-01 10:45:45');
INSERT INTO `dumpLog` VALUES (837, 'server=10.0.3.33', 'tblTournamentParticipateBatter', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (838, 'server=10.0.3.33', 'tblTournamentBasic', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (839, 'server=10.0.3.33', 'tblTournament', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (840, 'server=10.0.3.33', 'tblTournamentStarReward', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (841, 'server=10.0.3.33', 'tblWorldChampSchedule', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (842, 'server=10.0.3.33', 'tblWorldRoyaleBasic', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (843, 'server=10.0.3.33', 'tblWorldChallengeBasic', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (844, 'server=10.0.3.33', 'tblWorldChallengeRequirement', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (845, 'server=10.0.3.33', 'tblNotification', '2024-02-01 11:54:58');
INSERT INTO `dumpLog` VALUES (846, 'server=10.0.3.33', 'tblPackageSchedule', '2024-02-01 12:02:24');
INSERT INTO `dumpLog` VALUES (847, 'server=10.0.3.33', 'tblSkinGoods', '2024-02-01 12:02:24');
INSERT INTO `dumpLog` VALUES (848, 'server=10.0.3.33', 'tblPackageSchedule', '2024-02-01 16:50:09');
INSERT INTO `dumpLog` VALUES (849, 'server=10.0.3.33', 'tblSkinGoods', '2024-02-01 16:50:09');
INSERT INTO `dumpLog` VALUES (850, 'server=10.0.3.33', 'tblShopBasic', '2024-02-02 13:00:04');
INSERT INTO `dumpLog` VALUES (851, 'server=10.0.3.33', 'tblDailySpin', '2024-02-02 13:00:04');
INSERT INTO `dumpLog` VALUES (852, 'server=10.0.3.33', 'tblRockPaperScissorsReward', '2024-02-02 13:00:04');
INSERT INTO `dumpLog` VALUES (853, 'server=10.0.3.33', 'tblRockPaperScissorsGoods', '2024-02-02 13:00:04');
INSERT INTO `dumpLog` VALUES (854, 'server=10.0.3.33', 'tblMiniBaseballReward', '2024-02-02 13:00:04');
INSERT INTO `dumpLog` VALUES (855, 'server=10.0.3.33', 'tblBingoEventSchedule', '2024-02-02 14:50:18');
INSERT INTO `dumpLog` VALUES (856, 'server=10.0.3.33', 'tblBingoEvent', '2024-02-02 14:50:18');
INSERT INTO `dumpLog` VALUES (857, 'server=10.0.3.33', 'tblClanConquestBasic', '2024-02-02 14:50:18');
INSERT INTO `dumpLog` VALUES (858, 'server=10.0.3.33', 'tblClanConquestBuffBatter', '2024-02-02 14:50:18');
INSERT INTO `dumpLog` VALUES (859, 'server=10.0.3.33', 'tblNotification', '2024-02-02 14:50:18');
INSERT INTO `dumpLog` VALUES (860, 'server=10.0.3.33', 'tblPackageSchedule', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (861, 'server=10.0.3.33', 'tblNotification', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (862, 'server=10.0.3.33', 'tblHomerunEventSchedule', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (863, 'server=10.0.3.33', 'tblHomerunPassBasic', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (864, 'server=10.0.3.33', 'tblClanLeagueParticipantReward', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (865, 'server=10.0.3.33', 'tblClanLeagueSchedule', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (866, 'server=10.0.3.33', 'tblClanLeagueClanPoint', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (867, 'server=10.0.3.33', 'tblNoneClanMatchClanPoint', '2024-02-05 18:07:13');
INSERT INTO `dumpLog` VALUES (868, 'server=10.0.3.33', 'tblAdventureMode', '2024-02-14 17:53:32');
INSERT INTO `dumpLog` VALUES (869, 'server=10.0.3.33', 'tblAdventureMode', '2024-02-15 14:05:10');
INSERT INTO `dumpLog` VALUES (870, 'server=10.0.3.33', 'tblAdventureClear', '2024-02-15 14:05:10');
INSERT INTO `dumpLog` VALUES (871, 'server=10.0.3.33', 'tblAdventureRound', '2024-02-15 14:05:10');
COMMIT;

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
-- Records of major
-- ----------------------------
BEGIN;
INSERT INTO `major` VALUES (10, 266, 'Aatrox', '아트록스', '5,3');
INSERT INTO `major` VALUES (11, 103, 'Ahri', '아리', '3');
INSERT INTO `major` VALUES (12, 84, 'Akali', '아칼리', '5,3');
INSERT INTO `major` VALUES (13, 166, 'Akshan', '아크샨', '5,3');
INSERT INTO `major` VALUES (14, 12, 'Alistar', '알리스타', '1');
INSERT INTO `major` VALUES (15, 32, 'Amumu', '아무무', '4,1');
INSERT INTO `major` VALUES (16, 34, 'Anivia', '애니비아', '3');
INSERT INTO `major` VALUES (17, 1, 'Annie', '애니', '3');
INSERT INTO `major` VALUES (18, 523, 'Aphelios', '아펠리오스', '2');
INSERT INTO `major` VALUES (19, 22, 'Ashe', '애쉬', '2');
INSERT INTO `major` VALUES (20, 136, 'Aurelion Sol', '아우렐리온 솔', '3');
INSERT INTO `major` VALUES (21, 268, 'Azir', '아지르', '3');
INSERT INTO `major` VALUES (22, 432, 'Bard', '바드', '1');
INSERT INTO `major` VALUES (23, 200, 'Bel\'Veth', '벨베스', '4');
INSERT INTO `major` VALUES (24, 53, 'Blitzcrank', '블리츠크랭크', '1');
INSERT INTO `major` VALUES (25, 63, 'Brand', '브랜드', '3,1');
INSERT INTO `major` VALUES (26, 201, 'Braum', '브라움', '1');
INSERT INTO `major` VALUES (27, 51, 'Caitlyn', '케이틀린', '2');
INSERT INTO `major` VALUES (28, 164, 'Camille', '카밀', '5,4');
INSERT INTO `major` VALUES (29, 69, 'Cassiopeia', '카시오페아', '5,3,2');
INSERT INTO `major` VALUES (30, 31, 'Cho\'Gath', '초가스', '5');
INSERT INTO `major` VALUES (31, 42, 'Corki', '코르키', '2');
INSERT INTO `major` VALUES (32, 122, 'Darius', '다리우스', '5');
INSERT INTO `major` VALUES (33, 131, 'Diana', '다이애나', '4,3');
INSERT INTO `major` VALUES (34, 119, 'Draven', '드레이븐', '2');
INSERT INTO `major` VALUES (35, 36, 'Dr. Mundo', '문도', '5,4');
INSERT INTO `major` VALUES (36, 245, 'Ekko', '에코', '4,3');
INSERT INTO `major` VALUES (37, 60, 'Elise', '엘리스', '4');
INSERT INTO `major` VALUES (38, 28, 'Evelynn', '이블린', '4');
INSERT INTO `major` VALUES (39, 81, 'Ezreal', '이즈리얼', '2');
INSERT INTO `major` VALUES (40, 9, 'Fiddlesticks', '피들스틱', '4');
INSERT INTO `major` VALUES (41, 114, 'Fiora', '피오라', '5');
INSERT INTO `major` VALUES (42, 105, 'Fizz', '피즈', '3');
INSERT INTO `major` VALUES (43, 3, 'Galio', '갈리오', '3,1');
INSERT INTO `major` VALUES (44, 41, 'Gangplank', '갱플랭크', '5');
INSERT INTO `major` VALUES (45, 86, 'Garen', '가렌', '5');
INSERT INTO `major` VALUES (46, 150, 'Gnar', '나르', '5');
INSERT INTO `major` VALUES (47, 79, 'Gragas', '그라가스', '5,4,3,1');
INSERT INTO `major` VALUES (48, 104, 'Graves', '그레이브즈', '5,4');
INSERT INTO `major` VALUES (49, 887, 'Gwen', '그웬', '5,4');
INSERT INTO `major` VALUES (50, 120, 'Hecarim', '헤카림', '5,4');
INSERT INTO `major` VALUES (51, 74, 'Heimerdinger', '하이머딩거', '5,1');
INSERT INTO `major` VALUES (52, 420, 'Illaoi', '일라오이', '5');
INSERT INTO `major` VALUES (53, 39, 'Irelia', '이렐리아', '5,3');
INSERT INTO `major` VALUES (54, 427, 'Ivern', '아이번', '4,1');
INSERT INTO `major` VALUES (55, 40, 'Janna', '잔나', '1');
INSERT INTO `major` VALUES (56, 59, 'Jarvan IV', '자르반 4세', '4');
INSERT INTO `major` VALUES (57, 24, 'Jax', '잭스', '5,4');
INSERT INTO `major` VALUES (58, 126, 'Jayce', '제이스', '5');
INSERT INTO `major` VALUES (59, 202, 'Jhin', '진', '2');
INSERT INTO `major` VALUES (60, 222, 'Jinx', '징크스', '2');
INSERT INTO `major` VALUES (61, 145, 'Kai\'Sa', '카이사', '2');
INSERT INTO `major` VALUES (62, 429, 'Kalista', '칼리스타', '5,2');
INSERT INTO `major` VALUES (63, 43, 'Karma', '카르마', '3,1');
INSERT INTO `major` VALUES (64, 30, 'Karthus', '카서스', '4,3');
INSERT INTO `major` VALUES (65, 38, 'Kassadin', '카사딘', '3');
INSERT INTO `major` VALUES (66, 55, 'Katarina', '카타리나', '3');
INSERT INTO `major` VALUES (67, 10, 'Kayle', '케일', '5');
INSERT INTO `major` VALUES (68, 141, 'Kayn', '케인', '4');
INSERT INTO `major` VALUES (69, 85, 'Kennen', '케넨', '5');
INSERT INTO `major` VALUES (70, 121, 'Kha\'Zix', '카직스', '4');
INSERT INTO `major` VALUES (71, 203, 'Kindred', '킨드레드', '4');
INSERT INTO `major` VALUES (72, 240, 'Kled', '클레드', '5');
INSERT INTO `major` VALUES (73, 96, 'Kog\'Maw', '코그모', '2');
INSERT INTO `major` VALUES (74, 897, 'K\'Sante', '크샨테', '5');
INSERT INTO `major` VALUES (75, 7, 'LeBlanc', '르블랑', '3');
INSERT INTO `major` VALUES (76, 64, 'Lee Sin', '리신', '5,4');
INSERT INTO `major` VALUES (77, 89, 'Leona', '레오나', '1');
INSERT INTO `major` VALUES (78, 876, 'Lillia', '릴리아', '5,4');
INSERT INTO `major` VALUES (79, 127, 'Lissandra', '리산드라', '3');
INSERT INTO `major` VALUES (80, 236, 'Lucian', '루시안', '3,2');
INSERT INTO `major` VALUES (81, 117, 'Lulu', '룰루', '5');
INSERT INTO `major` VALUES (82, 99, 'Lux', '럭스', '3,1');
INSERT INTO `major` VALUES (83, 54, 'Malphite', '말파이트', '5');
INSERT INTO `major` VALUES (84, 90, 'Malzahar', '말자하', '3');
INSERT INTO `major` VALUES (85, 57, 'Maokai', '마오카이', '5,4,1');
INSERT INTO `major` VALUES (86, 11, 'Master Yi', '마스터 이', '4');
INSERT INTO `major` VALUES (87, 21, 'Miss Fortune', '미스포츈', '2,1');
INSERT INTO `major` VALUES (88, 62, 'Wukong', '오공', '5,4');
INSERT INTO `major` VALUES (89, 82, 'Mordekaiser', '모데카이저', '5,4');
INSERT INTO `major` VALUES (90, 25, 'Morgana', '모르가나', '3,1');
INSERT INTO `major` VALUES (91, 267, 'Nami', '나미', '1');
INSERT INTO `major` VALUES (92, 75, 'Nasus', '나서스', '5,4');
INSERT INTO `major` VALUES (93, 111, 'Nautilus', '노틸러스', '1');
INSERT INTO `major` VALUES (94, 518, 'Neeko', '니코', '3,1');
INSERT INTO `major` VALUES (95, 76, 'Nidalee', '니달리', '4');
INSERT INTO `major` VALUES (96, 895, 'Nilah', '닐라', '2');
INSERT INTO `major` VALUES (97, 56, 'Nocturne', '녹턴', '5,4');
INSERT INTO `major` VALUES (98, 20, 'Nunu & Willump', '누누', '4');
INSERT INTO `major` VALUES (99, 2, 'Olaf', '올라프', '5,4');
INSERT INTO `major` VALUES (100, 61, 'Orianna', '오리아나', '3');
INSERT INTO `major` VALUES (101, 516, 'Ornn', '오른', '5');
INSERT INTO `major` VALUES (102, 80, 'Pantheon', '판테온', '5,3,1');
INSERT INTO `major` VALUES (103, 78, 'Poppy', '뽀삐', '5,4');
INSERT INTO `major` VALUES (104, 555, 'Pyke', '파이크', '1');
INSERT INTO `major` VALUES (105, 246, 'Qiyana', '키아나', '4,3');
INSERT INTO `major` VALUES (106, 133, 'Quinn', '퀸', '5');
INSERT INTO `major` VALUES (107, 497, 'Rakan', '라칸', '1');
INSERT INTO `major` VALUES (108, 33, 'Rammus', '람머스', '4');
INSERT INTO `major` VALUES (109, 421, 'Rek\'Sai', '렉사이', '4');
INSERT INTO `major` VALUES (110, 526, 'Rell', '렐', '1');
INSERT INTO `major` VALUES (111, 888, 'Renata Glasc', '레나크 글라스크', '1');
INSERT INTO `major` VALUES (112, 58, 'Renekton', '레넥톤', '5');
INSERT INTO `major` VALUES (113, 107, 'Rengar', '렝가', '5,4');
INSERT INTO `major` VALUES (114, 92, 'Riven', '리븐', '5');
INSERT INTO `major` VALUES (115, 68, 'Rumble', '럼블', '5,4,3');
INSERT INTO `major` VALUES (116, 13, 'Ryze', '라이즈', '5,3');
INSERT INTO `major` VALUES (117, 360, 'Samira', '사미라', '2');
INSERT INTO `major` VALUES (118, 113, 'Sejuani', '세주아니', '5,4');
INSERT INTO `major` VALUES (119, 235, 'Senna', '세나', '2,1');
INSERT INTO `major` VALUES (120, 147, 'Seraphine', '세라핀', '1');
INSERT INTO `major` VALUES (121, 875, 'Sett', '세트', '5,1');
INSERT INTO `major` VALUES (122, 35, 'Shaco', '샤코', '4,1');
INSERT INTO `major` VALUES (123, 98, 'Shen', '쉔', '5');
INSERT INTO `major` VALUES (124, 102, 'Shyvana', '쉬바나', '5,4');
INSERT INTO `major` VALUES (125, 27, 'Singed', '신지드', '5,3');
INSERT INTO `major` VALUES (126, 14, 'Sion', '사이온', '5');
INSERT INTO `major` VALUES (127, 15, 'Sivir', '시비르', '2');
INSERT INTO `major` VALUES (128, 72, 'Skarner', '스카너', '4');
INSERT INTO `major` VALUES (129, 37, 'Sona', '소나', '1');
INSERT INTO `major` VALUES (130, 16, 'Soraka', '소라카', '1');
INSERT INTO `major` VALUES (131, 50, 'Swain', '스웨인', '3,2,1');
INSERT INTO `major` VALUES (132, 517, 'Sylas', '사일러스', '5,4,3');
INSERT INTO `major` VALUES (133, 134, 'Syndra', '신드라', '3');
INSERT INTO `major` VALUES (134, 223, 'Tahm Kench', '탐켄치', '5,1');
INSERT INTO `major` VALUES (135, 163, 'Taliyah', '탈리아', '4,3');
INSERT INTO `major` VALUES (136, 91, 'Talon', '탈론', '4,3');
INSERT INTO `major` VALUES (137, 44, 'Taric', '타릭', '1');
INSERT INTO `major` VALUES (138, 17, 'Teemo', '티모', '2');
INSERT INTO `major` VALUES (139, 412, 'Thresh', '쓰레쉬', '1');
INSERT INTO `major` VALUES (140, 18, 'Tristana', '트리스타나', '2');
INSERT INTO `major` VALUES (141, 48, 'Trundle', '트런들', '5,4');
INSERT INTO `major` VALUES (142, 23, 'Tryndamere', '트린다미어', '5');
INSERT INTO `major` VALUES (143, 4, 'Twisted Fate', '트위스티드 페이트', '3');
INSERT INTO `major` VALUES (144, 29, 'Twitch', '트위치', '2');
INSERT INTO `major` VALUES (145, 77, 'Udyr', '우디르', '4');
INSERT INTO `major` VALUES (146, 6, 'Urgot', '우르곳', '5');
INSERT INTO `major` VALUES (147, 110, 'Varus', '바루스', '2');
INSERT INTO `major` VALUES (148, 67, 'Vayne', '베인', '5,2');
INSERT INTO `major` VALUES (149, 45, 'Veigar', '베이가', '3');
INSERT INTO `major` VALUES (150, 161, 'Vel\'Koz', '벨코즈', '3,1');
INSERT INTO `major` VALUES (151, 711, 'Vex', '백스', '3');
INSERT INTO `major` VALUES (152, 254, 'Vi', '바이', '4');
INSERT INTO `major` VALUES (153, 234, 'Viego', '비에고', '4');
INSERT INTO `major` VALUES (154, 112, 'Viktor', '빅토르', '3');
INSERT INTO `major` VALUES (155, 8, 'Vladimir', '블라디미르', '5,3');
INSERT INTO `major` VALUES (156, 106, 'Volibear', '볼리베어', '5,4');
INSERT INTO `major` VALUES (157, 19, 'Warwick', '워윅', '5,4');
INSERT INTO `major` VALUES (158, 498, 'Xayah', '자야', '2');
INSERT INTO `major` VALUES (159, 101, 'Xerath', '제라스', '3,1');
INSERT INTO `major` VALUES (160, 5, 'Xin Zhao', '신짜오', '4');
INSERT INTO `major` VALUES (161, 157, 'Yasuo', '야스오', '5,3,2');
INSERT INTO `major` VALUES (162, 777, 'Yone', '요네', '5,3');
INSERT INTO `major` VALUES (163, 83, 'Yorick', '요릭', '5');
INSERT INTO `major` VALUES (164, 350, 'Yuumi', '유미', '1');
INSERT INTO `major` VALUES (165, 154, 'Zac', '자크', '5,4,1');
INSERT INTO `major` VALUES (166, 238, 'Zed', '제드', '4,3');
INSERT INTO `major` VALUES (167, 221, 'Zeri', '제리', '2');
INSERT INTO `major` VALUES (168, 115, 'Ziggs', '직스', '3,2');
INSERT INTO `major` VALUES (169, 26, 'Zilean', '질리언', '1');
INSERT INTO `major` VALUES (170, 142, 'Zoe', '조이', '3');
INSERT INTO `major` VALUES (171, 143, 'Zyra', '자이라', '1');
COMMIT;

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
-- Records of tblLogMatchHistory
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for tblPenaltyRoulette
-- ----------------------------
DROP TABLE IF EXISTS `tblPenaltyRoulette`;
CREATE TABLE `tblPenaltyRoulette` (
  `basicId` int NOT NULL,
  `contentName_KR` varchar(255) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of tblPenaltyRoulette
-- ----------------------------
BEGIN;
INSERT INTO `tblPenaltyRoulette` VALUES (10001, '1명 랜덤 챔피언');
INSERT INTO `tblPenaltyRoulette` VALUES (10002, '지정해주는 1명 디스코드 음소거');
COMMIT;

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
-- Records of tblPlayer
-- ----------------------------
BEGIN;
INSERT INTO `tblPlayer` VALUES (1, 'Sy1234', '2024-02-13 05:40:41');
INSERT INTO `tblPlayer` VALUES (2, 'Sy123', '2024-02-13 06:56:33');
INSERT INTO `tblPlayer` VALUES (3, 'Sy12345', '2024-02-13 06:56:38');
COMMIT;

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
-- Records of tblPlayerRPS
-- ----------------------------
BEGIN;
COMMIT;

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
-- Records of tblRankHistory
-- ----------------------------
BEGIN;
INSERT INTO `tblRankHistory` VALUES (146, 78, '2024-01-09 07:59:22', 1, 75.00);
INSERT INTO `tblRankHistory` VALUES (147, 82, '2024-01-09 07:59:22', 2, 75.00);
INSERT INTO `tblRankHistory` VALUES (148, 83, '2024-01-09 07:59:22', 3, 75.00);
INSERT INTO `tblRankHistory` VALUES (149, 84, '2024-01-09 07:59:22', 4, 75.00);
INSERT INTO `tblRankHistory` VALUES (150, 86, '2024-01-09 07:59:22', 5, 75.00);
INSERT INTO `tblRankHistory` VALUES (151, 77, '2024-01-09 07:59:22', 6, 64.70);
INSERT INTO `tblRankHistory` VALUES (152, 79, '2024-01-09 07:59:22', 7, 64.70);
INSERT INTO `tblRankHistory` VALUES (153, 80, '2024-01-09 07:59:22', 8, 64.70);
INSERT INTO `tblRankHistory` VALUES (154, 81, '2024-01-09 07:59:22', 9, 64.70);
INSERT INTO `tblRankHistory` VALUES (155, 85, '2024-01-09 07:59:22', 10, 64.70);
INSERT INTO `tblRankHistory` VALUES (156, 77, '2024-01-09 09:12:17', 1, 88.90);
INSERT INTO `tblRankHistory` VALUES (157, 78, '2024-01-09 09:12:17', 2, 88.90);
INSERT INTO `tblRankHistory` VALUES (158, 79, '2024-01-09 09:12:17', 3, 88.90);
INSERT INTO `tblRankHistory` VALUES (159, 81, '2024-01-09 09:12:17', 4, 88.90);
INSERT INTO `tblRankHistory` VALUES (160, 82, '2024-01-09 09:12:17', 5, 88.90);
INSERT INTO `tblRankHistory` VALUES (161, 80, '2024-01-09 09:12:17', 6, 70.00);
INSERT INTO `tblRankHistory` VALUES (162, 83, '2024-01-09 09:12:17', 7, 70.00);
INSERT INTO `tblRankHistory` VALUES (163, 84, '2024-01-09 09:12:17', 8, 70.00);
INSERT INTO `tblRankHistory` VALUES (164, 85, '2024-01-09 09:12:17', 9, 70.00);
INSERT INTO `tblRankHistory` VALUES (165, 86, '2024-01-09 09:12:17', 10, 70.00);
INSERT INTO `tblRankHistory` VALUES (166, 77, '2024-01-09 09:27:21', 1, 75.00);
INSERT INTO `tblRankHistory` VALUES (167, 78, '2024-01-09 09:27:21', 2, 75.00);
INSERT INTO `tblRankHistory` VALUES (168, 84, '2024-01-09 09:27:21', 3, 75.00);
INSERT INTO `tblRankHistory` VALUES (169, 85, '2024-01-09 09:27:21', 4, 75.00);
INSERT INTO `tblRankHistory` VALUES (170, 86, '2024-01-09 09:27:21', 5, 75.00);
INSERT INTO `tblRankHistory` VALUES (171, 79, '2024-01-09 09:27:21', 6, 25.00);
INSERT INTO `tblRankHistory` VALUES (172, 80, '2024-01-09 09:27:21', 7, 25.00);
INSERT INTO `tblRankHistory` VALUES (173, 81, '2024-01-09 09:27:21', 8, 25.00);
INSERT INTO `tblRankHistory` VALUES (174, 82, '2024-01-09 09:27:21', 9, 25.00);
INSERT INTO `tblRankHistory` VALUES (175, 83, '2024-01-09 09:27:21', 10, 25.00);
INSERT INTO `tblRankHistory` VALUES (176, 78, '2024-01-09 09:29:31', 1, 55.60);
INSERT INTO `tblRankHistory` VALUES (177, 83, '2024-01-09 09:29:31', 2, 55.60);
INSERT INTO `tblRankHistory` VALUES (178, 84, '2024-01-09 09:29:31', 3, 55.60);
INSERT INTO `tblRankHistory` VALUES (179, 85, '2024-01-09 09:29:31', 4, 55.60);
INSERT INTO `tblRankHistory` VALUES (180, 86, '2024-01-09 09:29:31', 5, 55.60);
INSERT INTO `tblRankHistory` VALUES (181, 77, '2024-01-09 09:29:31', 6, 44.40);
INSERT INTO `tblRankHistory` VALUES (182, 79, '2024-01-09 09:29:31', 7, 44.40);
INSERT INTO `tblRankHistory` VALUES (183, 80, '2024-01-09 09:29:31', 8, 44.40);
INSERT INTO `tblRankHistory` VALUES (184, 81, '2024-01-09 09:29:31', 9, 44.40);
INSERT INTO `tblRankHistory` VALUES (185, 82, '2024-01-09 09:29:31', 10, 44.40);
INSERT INTO `tblRankHistory` VALUES (186, 76, '2024-01-09 09:40:25', 1, 98.50);
INSERT INTO `tblRankHistory` VALUES (187, 78, '2024-01-09 09:40:25', 2, 87.50);
INSERT INTO `tblRankHistory` VALUES (188, 83, '2024-01-09 09:40:25', 3, 87.50);
INSERT INTO `tblRankHistory` VALUES (189, 84, '2024-01-09 09:40:25', 4, 87.50);
INSERT INTO `tblRankHistory` VALUES (190, 85, '2024-01-09 09:40:25', 5, 87.50);
INSERT INTO `tblRankHistory` VALUES (191, 86, '2024-01-09 09:40:25', 6, 87.50);
INSERT INTO `tblRankHistory` VALUES (192, 77, '2024-01-09 09:40:25', 7, 12.50);
INSERT INTO `tblRankHistory` VALUES (193, 79, '2024-01-09 09:40:25', 8, 12.50);
INSERT INTO `tblRankHistory` VALUES (194, 80, '2024-01-09 09:40:25', 9, 12.50);
INSERT INTO `tblRankHistory` VALUES (195, 81, '2024-01-09 09:40:25', 10, 12.50);
INSERT INTO `tblRankHistory` VALUES (196, 82, '2024-01-09 09:40:25', 11, 12.50);
COMMIT;

-- ----------------------------
-- Table structure for tblServerVariable
-- ----------------------------
DROP TABLE IF EXISTS `tblServerVariable`;
CREATE TABLE `tblServerVariable` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `playerSeq` bigint NOT NULL,
  `winCount` int NOT NULL,
  `loseCount` int NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxPlayerSeq` (`playerSeq`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- ----------------------------
-- Records of tblServerVariable
-- ----------------------------
BEGIN;
INSERT INTO `tblServerVariable` VALUES (1, 'LoadingTime', '3');
INSERT INTO `tblServerVariable` VALUES (2, 'TotalRound', '5');
INSERT INTO `tblServerVariable` VALUES (3, 'Life', '5');
INSERT INTO `tblServerVariable` VALUES (4, 'MinSumValue', '10');
INSERT INTO `tblServerVariable` VALUES (5, 'MaxSumValue', '30');
COMMIT;

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
-- Records of tblUser
-- ----------------------------
BEGIN;
COMMIT;

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
-- Records of tblUserInfo
-- ----------------------------
BEGIN;
INSERT INTO `tblUserInfo` VALUES (76, 'test1234', '2023-06-15 11:19:53', NULL);
INSERT INTO `tblUserInfo` VALUES (77, 'qwerr', '2023-06-15 11:30:13', NULL);
INSERT INTO `tblUserInfo` VALUES (78, 'wwww', '2023-06-15 11:30:15', NULL);
INSERT INTO `tblUserInfo` VALUES (79, 'e', '2023-06-15 11:30:16', NULL);
INSERT INTO `tblUserInfo` VALUES (80, 'r', '2023-06-15 11:30:18', NULL);
INSERT INTO `tblUserInfo` VALUES (81, 't', '2023-06-15 11:30:21', NULL);
INSERT INTO `tblUserInfo` VALUES (82, 'y', '2023-06-15 11:30:23', NULL);
INSERT INTO `tblUserInfo` VALUES (83, 'u', '2023-06-15 11:30:24', NULL);
INSERT INTO `tblUserInfo` VALUES (84, 'i', '2023-06-15 11:30:27', NULL);
INSERT INTO `tblUserInfo` VALUES (85, 'o', '2023-06-15 11:30:29', NULL);
INSERT INTO `tblUserInfo` VALUES (86, 'p', '2023-06-15 11:30:31', NULL);
INSERT INTO `tblUserInfo` VALUES (87, 'blasion', '2023-11-01 15:00:01', NULL);
INSERT INTO `tblUserInfo` VALUES (88, '캬르륵', '2023-11-29 14:28:58', NULL);
INSERT INTO `tblUserInfo` VALUES (90, 'TestNick', '2024-01-08 12:55:08', NULL);
INSERT INTO `tblUserInfo` VALUES (91, 'TestNick1', '2024-01-08 12:55:34', NULL);
INSERT INTO `tblUserInfo` VALUES (92, 'TestNick2', '2024-01-08 12:58:04', NULL);
INSERT INTO `tblUserInfo` VALUES (93, 'hello123', '2024-01-08 14:13:32', NULL);
INSERT INTO `tblUserInfo` VALUES (94, 'hey12', '2024-01-08 17:57:12', NULL);
INSERT INTO `tblUserInfo` VALUES (95, 'qwerrrr', '2024-01-09 16:31:49', NULL);
COMMIT;

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
-- Records of tblUserWinnrateHistory
-- ----------------------------
BEGIN;
INSERT INTO `tblUserWinnrateHistory` VALUES (76, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (76, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (76, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (76, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (76, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (77, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (77, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (77, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (77, 4, 1, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (77, 5, 3, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (78, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (78, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (78, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (78, 4, 0, 1);
INSERT INTO `tblUserWinnrateHistory` VALUES (78, 5, 11, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (79, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (79, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (79, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (79, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (79, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (80, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (80, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (80, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (80, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (80, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (81, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (81, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (81, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (81, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (81, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (82, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (82, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (82, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (82, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (82, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (83, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (83, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (83, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (83, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (83, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (84, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (84, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (84, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (84, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (84, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (85, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (85, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (85, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (85, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (85, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (86, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (86, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (86, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (86, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (86, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (87, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (87, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (87, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (87, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (87, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (88, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (88, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (88, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (88, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (88, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (92, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (92, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (92, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (92, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (92, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (93, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (93, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (93, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (93, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (93, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (94, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (94, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (94, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (94, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (94, 5, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (95, 1, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (95, 2, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (95, 3, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (95, 4, 0, 0);
INSERT INTO `tblUserWinnrateHistory` VALUES (95, 5, 0, 0);
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
-- Table structure for tblMatchHistory
-- ----------------------------
DROP TABLE IF EXISTS `tblMatchHistory`;
CREATE TABLE `tblMatchHistory` (
  `seq` bigint NOT NULL AUTO_INCREMENT,
  `playerSeq` bigint NOT NULL,
  `data` varchar(255) NOT NULL,
  PRIMARY KEY (`seq`),
  UNIQUE KEY `idxPlayerSeq` (`playerSeq`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
