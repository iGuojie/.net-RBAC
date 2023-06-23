/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50741 (5.7.41-log)
 Source Host           : localhost:3306
 Source Schema         : authority

 Target Server Type    : MySQL
 Target Server Version : 50741 (5.7.41-log)
 File Encoding         : 65001

 Date: 23/06/2023 21:49:43
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20230622112008_InitDB', '6.0.0');
INSERT INTO `__efmigrationshistory` VALUES ('20230622121926_ResourceAddRoles', '6.0.0');
INSERT INTO `__efmigrationshistory` VALUES ('20230622122411_RoleAddUser', '6.0.0');
INSERT INTO `__efmigrationshistory` VALUES ('20230622124105_PerfectManyToMany', '6.0.0');

-- ----------------------------
-- Table structure for resourcerole
-- ----------------------------
DROP TABLE IF EXISTS `resourcerole`;
CREATE TABLE `resourcerole`  (
  `ResourcesUrl` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `RolesName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ResourcesUrl`, `RolesName`) USING BTREE,
  INDEX `IX_ResourceRole_RolesName`(`RolesName`) USING BTREE,
  CONSTRAINT `FK_ResourceRole_Resources_ResourcesUrl` FOREIGN KEY (`ResourcesUrl`) REFERENCES `resources` (`Url`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_ResourceRole_Roles_RolesName` FOREIGN KEY (`RolesName`) REFERENCES `roles` (`Name`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of resourcerole
-- ----------------------------
INSERT INTO `resourcerole` VALUES ('/Admin/Admin', 'admin');
INSERT INTO `resourcerole` VALUES ('/Ordinary/Ordinary', 'ordinaryUser');

-- ----------------------------
-- Table structure for resources
-- ----------------------------
DROP TABLE IF EXISTS `resources`;
CREATE TABLE `resources`  (
  `Url` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Descrpition` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  PRIMARY KEY (`Url`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of resources
-- ----------------------------
INSERT INTO `resources` VALUES ('/Admin/Admin', '管理员测试');
INSERT INTO `resources` VALUES ('/Ordinary/Ordinary', '普通用户测试');

-- ----------------------------
-- Table structure for roles
-- ----------------------------
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles`  (
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  PRIMARY KEY (`Name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of roles
-- ----------------------------
INSERT INTO `roles` VALUES ('admin', '管理员');
INSERT INTO `roles` VALUES ('ordinaryUser', '普通用户');

-- ----------------------------
-- Table structure for roleuser
-- ----------------------------
DROP TABLE IF EXISTS `roleuser`;
CREATE TABLE `roleuser`  (
  `RolesName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `UsersId` int(11) NOT NULL,
  PRIMARY KEY (`RolesName`, `UsersId`) USING BTREE,
  INDEX `IX_RoleUser_UsersId`(`UsersId`) USING BTREE,
  CONSTRAINT `FK_RoleUser_Roles_RolesName` FOREIGN KEY (`RolesName`) REFERENCES `roles` (`Name`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_RoleUser_Users_UsersId` FOREIGN KEY (`UsersId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of roleuser
-- ----------------------------
INSERT INTO `roleuser` VALUES ('admin', 1);
INSERT INTO `roleuser` VALUES ('ordinaryUser', 1);
INSERT INTO `roleuser` VALUES ('ordinaryUser', 2);

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NickName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (1, 'admin', '123456');
INSERT INTO `users` VALUES (2, 'changyaya', '123456');

SET FOREIGN_KEY_CHECKS = 1;
