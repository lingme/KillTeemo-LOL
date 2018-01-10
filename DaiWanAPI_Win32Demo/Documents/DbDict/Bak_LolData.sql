/*
Navicat MySQL Data Transfer

Source Server         : My
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : loldata

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2017-06-13 00:11:15
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for allaero
-- ----------------------------
DROP TABLE IF EXISTS `allaero`;
CREATE TABLE `allaero` (
  `Id` int(11) NOT NULL,
  `StrId` varchar(10) NOT NULL,
  `Isp` varchar(10) NOT NULL,
  `AeroName` varchar(10) NOT NULL,
  `Idc` varchar(10) NOT NULL,
  `Tcls` int(11) NOT NULL,
  `Ob` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of allaero
-- ----------------------------
INSERT INTO `allaero` VALUES ('1', 'HN1', '电信一', '艾欧尼亚', '东莞东城', '257', '1');
INSERT INTO `allaero` VALUES ('2', 'WT1', '网通一', '比尔吉沃特', '济南担山屯', '258', '1');
INSERT INTO `allaero` VALUES ('3', 'HN2', '电信二', '祖安', '杭州东冠', '513', '1');
INSERT INTO `allaero` VALUES ('4', 'HN3', '电信三', '诺克萨斯', '东莞大朗', '769', '1');
INSERT INTO `allaero` VALUES ('5', 'HN4', '电信四', '班德尔城', '成都光华', '1025', '0');
INSERT INTO `allaero` VALUES ('6', 'WT2', '网通二', '德玛西亚', '济南担山屯', '514', '1');
INSERT INTO `allaero` VALUES ('7', 'HN5', '电信五', '皮尔特沃夫', '杭州东冠', '1281', '0');
INSERT INTO `allaero` VALUES ('8', 'HN6', '电信六', '战争学院', '东莞大朗', '1537', '0');
INSERT INTO `allaero` VALUES ('9', 'WT3', '网通三', '弗雷尔卓德', '天津数据中心', '770', '1');
INSERT INTO `allaero` VALUES ('10', 'HN7', '电信七', '巨神峰', '杭州东冠', '1793', '0');
INSERT INTO `allaero` VALUES ('11', 'HN8', '电信八', '雷瑟守备', '东莞大朗', '2049', '0');
INSERT INTO `allaero` VALUES ('12', 'WT4', '网通四', '无畏先锋', '济南担山屯', '1026', '0');
INSERT INTO `allaero` VALUES ('13', 'HN9', '电信九', '裁决之地', '成都高新', '2305', '0');
INSERT INTO `allaero` VALUES ('14', 'HN10', '电信十', '黑色玫瑰', '东莞大朗', '2561', '0');
INSERT INTO `allaero` VALUES ('15', 'HN11', '电信十一', '暗影岛', '东莞大朗', '2817', '0');
INSERT INTO `allaero` VALUES ('16', 'WT5', '网通五', '恕瑞玛', '天津数据中心', '1282', '0');
INSERT INTO `allaero` VALUES ('17', 'HN12', '电信十二', '钢铁烈阳', '成都高新', '3073', '0');
INSERT INTO `allaero` VALUES ('18', 'HN13', '电信十三', '水晶之痕', '杭州东冠', '3329', '0');
INSERT INTO `allaero` VALUES ('19', 'HN14', '电信十四', '均衡教派', '南京二长', '3585', '0');
INSERT INTO `allaero` VALUES ('20', 'WT6', '网通六', '扭曲丛林', '天津数据中心', '1538', '0');
INSERT INTO `allaero` VALUES ('21', 'EDU1', '教育网', '教育网专区', '上海南汇', '65539', '0');
INSERT INTO `allaero` VALUES ('22', 'HN15', '电信十五', '影流', '南京二长', '3841', '0');
INSERT INTO `allaero` VALUES ('23', 'HN16', '电信十六', '守望之海', '南京二长', '4097', '0');
INSERT INTO `allaero` VALUES ('24', 'HN17', '电信十七', '征服之海', '东莞大朗', '4353', '0');
INSERT INTO `allaero` VALUES ('25', 'HN18', '电信十八', '卡拉曼达', '深圳蛇口', '4609', '0');
INSERT INTO `allaero` VALUES ('26', 'WT7', '网通七', '巨龙之巢', '天津数据中心', '1794', '0');
INSERT INTO `allaero` VALUES ('27', 'HN19', '电信十九', '皮城警备', '成都高新', '4865', '0');
INSERT INTO `allaero` VALUES ('30', 'BGP1', '全网络大区一', '男爵领域', '上海腾讯宝信DC', '261', '0');

-- ----------------------------
-- Table structure for allchampion
-- ----------------------------
DROP TABLE IF EXISTS `allchampion`;
CREATE TABLE `allchampion` (
  `Id` int(11) NOT NULL,
  `Ename` varchar(20) NOT NULL,
  `Title` varchar(10) NOT NULL,
  `Cname` varchar(10) NOT NULL,
  `Pic` varchar(30) NOT NULL,
  `UpdateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of allchampion
-- ----------------------------
INSERT INTO `allchampion` VALUES ('1', 'Annie', '黑暗之女', '安妮', 'annie_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('2', 'Olaf', '狂战士', '奥拉夫', 'olaf_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('3', 'Galio', '哨兵之殇', '加里奥', 'galio_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('4', 'TwistedFate', '卡牌大师', '崔斯特', 'twistedfate_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('5', 'XinZhao', '德邦总管', '赵信', 'xinzhao_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('6', 'Urgot', '首领之傲', '厄加特', 'urgot_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('7', 'Leblanc', '诡术妖姬', '乐芙兰', 'leblanc_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('8', 'Vladimir', '猩红收割者', '弗拉基米尔', 'vladimir_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('9', 'FiddleSticks', '末日使者', '费德提克', 'fiddlesticks_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('10', 'Kayle', '审判天使', '凯尔', 'kayle_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('11', 'MasterYi', '无极剑圣', '易', 'masteryi_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('12', 'Alistar', '牛头酋长', '阿利斯塔', 'alistar_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('13', 'Ryze', '流浪法师', '瑞兹', 'ryze_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('14', 'Sion', '亡灵战神', '赛恩', 'sion_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('15', 'Sivir', '战争女神', '希维尔', 'sivir_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('16', 'Soraka', '众星之子', '索拉卡', 'soraka_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('17', 'Teemo', '迅捷斥候', '提莫', 'teemo_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('18', 'Tristana', '麦林炮手', '崔丝塔娜', 'tristana_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('19', 'Warwick', '嗜血猎手', '沃里克', 'warwick_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('20', 'Nunu', '雪人骑士', '努努', 'nunu_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('21', 'MissFortune', '赏金猎人', '厄运小姐', 'missfortune_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('22', 'Ashe', '寒冰射手', '艾希', 'ashe_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('23', 'Tryndamere', '蛮族之王', '泰达米尔', 'tryndamere_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('24', 'Jax', '武器大师', '贾克斯', 'jax_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('25', 'Morgana', '堕落天使', '莫甘娜', 'morgana_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('26', 'Zilean', '时光守护者', '基兰', 'zilean_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('27', 'Singed', '炼金术士', '辛吉德', 'singed_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('28', 'Evelynn', '寡妇制造者', '伊芙琳', 'evelynn_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('29', 'Twitch', '瘟疫之源', '图奇', 'twitch_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('30', 'Karthus', '死亡颂唱者', '卡尔萨斯', 'karthus_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('31', 'Chogath', '虚空恐惧', '科''加斯', 'chogath_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('32', 'Amumu', '殇之木乃伊', '阿木木', 'amumu_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('33', 'Rammus', '披甲龙龟', '拉莫斯', 'rammus_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('34', 'Anivia', '冰晶凤凰', '艾尼维亚', 'anivia_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('35', 'Shaco', '恶魔小丑', '萨科', 'shaco_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('36', 'DrMundo', '祖安狂人', '蒙多医生', 'drmundo_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('37', 'Sona', '琴瑟仙女', '娑娜', 'sona_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('38', 'Kassadin', '虚空行者', '卡萨丁', 'kassadin_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('39', 'Irelia', '刀锋意志', '艾瑞莉娅', 'irelia_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('40', 'Janna', '风暴之怒', '迦娜', 'janna_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('41', 'Gangplank', '海洋之灾', '普朗克', 'gangplank_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('42', 'Corki', '英勇投弹手', '库奇', 'corki_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('43', 'Karma', '天启者', '卡尔玛', 'karma_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('44', 'Taric', '宝石骑士', '塔里克', 'taric_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('45', 'Veigar', '邪恶小法师', '维迦', 'veigar_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('48', 'Trundle', '巨魔之王', '特朗德尔', 'trundle_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('50', 'Swain', '策士统领', '斯维因', 'swain_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('51', 'Caitlyn', '皮城女警', '凯特琳', 'caitlyn_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('53', 'Blitzcrank', '蒸汽机器人', '布里茨', 'blitzcrank_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('54', 'Malphite', '熔岩巨兽', '墨菲特', 'malphite_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('55', 'Katarina', '不祥之刃', '卡特琳娜', 'katarina_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('56', 'Nocturne', '永恒梦魇', '魔腾', 'nocturne_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('57', 'Maokai', '扭曲树精', '茂凯', 'maokai_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('58', 'Renekton', '荒漠屠夫', '雷克顿', 'renekton_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('59', 'JarvanIV', '德玛西亚皇子', '嘉文四世', 'jarvaniv_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('60', 'Elise', '蜘蛛女皇', '伊莉丝', 'elise_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('61', 'Orianna', '发条魔灵', '奥莉安娜', 'orianna_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('62', 'MonkeyKing', '齐天大圣', '孙悟空', 'monkeyking_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('63', 'Brand', '复仇焰魂', '布兰德', 'brand_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('64', 'LeeSin', '盲僧', '李青', 'leesin_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('67', 'Vayne', '暗夜猎手', '薇恩', 'vayne_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('68', 'Rumble', '机械公敌', '兰博', 'rumble_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('69', 'Cassiopeia', '魔蛇之拥', '卡西奥佩娅', 'cassiopeia_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('72', 'Skarner', '水晶先锋', '斯卡纳', 'skarner_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('74', 'Heimerdinger', '大发明家', '黑默丁格', 'heimerdinger_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('75', 'Nasus', '沙漠死神', '内瑟斯', 'nasus_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('76', 'Nidalee', '狂野女猎手', '奈德丽', 'nidalee_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('77', 'Udyr', '兽灵行者', '乌迪尔', 'udyr_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('78', 'Poppy', '圣锤之毅', '波比', 'poppy_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('79', 'Gragas', '酒桶', '古拉加斯', 'gragas_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('80', 'Pantheon', '战争之王', '潘森', 'pantheon_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('81', 'Ezreal', '探险家', '伊泽瑞尔', 'ezreal_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('82', 'Mordekaiser', '金属大师', '莫德凯撒', 'mordekaiser_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('83', 'Yorick', '掘墓者', '约里克', 'yorick_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('84', 'Akali', '暗影之拳', '阿卡丽', 'akali_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('85', 'Kennen', '狂暴之心', '凯南', 'kennen_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('86', 'Garen', '德玛西亚之力', '盖伦', 'garen_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('89', 'Leona', '曙光女神', '蕾欧娜', 'leona_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('90', 'Malzahar', '虚空先知', '玛尔扎哈', 'malzahar_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('91', 'Talon', '刀锋之影', '泰隆', 'talon_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('92', 'Riven', '放逐之刃', '锐雯', 'riven_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('96', 'KogMaw', '深渊巨口', '克格''莫', 'kogmaw_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('98', 'Shen', '暮光之眼', '慎', 'shen_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('99', 'Lux', '光辉女郎', '拉克丝', 'lux_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('101', 'Xerath', '远古巫灵', '泽拉斯', 'xerath_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('102', 'Shyvana', '龙血武姬', '希瓦娜', 'shyvana_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('103', 'Ahri', '九尾妖狐', '阿狸', 'ahri_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('104', 'Graves', '法外狂徒', '格雷福斯', 'graves_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('105', 'Fizz', '潮汐海灵', '菲兹', 'fizz_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('106', 'Volibear', '雷霆咆哮', '沃利贝尔', 'volibear_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('107', 'Rengar', '傲之追猎者', '雷恩加尔', 'rengar_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('110', 'Varus', '惩戒之箭', '韦鲁斯', 'varus_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('111', 'Nautilus', '深海泰坦', '诺提勒斯', 'nautilus_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('112', 'Viktor', '机械先驱', '维克托', 'viktor_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('113', 'Sejuani', '凛冬之怒', '瑟庄妮', 'sejuani_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('114', 'Fiora', '无双剑姬', '菲奥娜', 'fiora_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('115', 'Ziggs', '爆破鬼才', '吉格斯', 'ziggs_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('117', 'Lulu', '仙灵女巫', '璐璐', 'lulu_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('119', 'Draven', '荣耀行刑官', '德莱文', 'draven_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('120', 'Hecarim', '战争之影', '赫卡里姆', 'hecarim_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('121', 'Khazix', '虚空掠夺者', '卡兹克', 'khazix_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('122', 'Darius', '诺克萨斯之手', '德莱厄斯', 'darius_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('126', 'Jayce', '未来守护者', '杰斯', 'jayce_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('127', 'Lissandra', '冰霜女巫', '丽桑卓', 'lissandra_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('131', 'Diana', '皎月女神', '黛安娜', 'diana_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('133', 'Quinn', '德玛西亚之翼', '奎因', 'quinn_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('134', 'Syndra', '暗黑元首', '辛德拉', 'syndra_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('136', 'AurelionSol', '铸星龙王', '奥瑞利安·索尔', 'AurelionSol_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('143', 'Zyra', '荆棘之兴', '婕拉', 'zyra_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('150', 'Gnar', '迷失之牙', '纳尔', 'gnar_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('154', 'Zac', '生化魔人', '扎克', 'zac_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('157', 'Yasuo', '疾风剑豪', '亚索', 'yasuo_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('161', 'Velkoz', '虚空之眼', '维克兹', 'velkoz_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('163', 'Taliyah', '岩雀', '塔莉垭', 'Taliyah_Square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('164', 'Camille', '青钢影', '卡蜜尔', 'Camille_Square_0.png', '2017-01-09 21:45:48');
INSERT INTO `allchampion` VALUES ('201', 'Braum', '弗雷尔卓德之心', '布隆', 'braum_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('202', 'Jhin', '戏命师', '烬', 'Jhin_Square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('203', 'Kindred', '永猎双子', '千珏', 'Kindred_Square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('222', 'Jinx', '暴走萝莉', '金克丝', 'jinx_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('223', 'TahmKench', '河流之王', '塔姆', 'TahmKench_Square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('236', 'Lucian', '圣枪游侠', '卢锡安', 'lucian_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('238', 'Zed', '影流之主', '劫', 'zed_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('240', 'Kled', '暴怒骑士', '克烈', 'Kled.png ', '2016-09-26 20:46:54');
INSERT INTO `allchampion` VALUES ('245', 'Ekko', '时间刺客', '艾克', 'Ekko_Square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('254', 'Vi', '皮城执法官', '蔚', 'vi_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('266', 'Aatrox', '暗裔剑魔', '亚托克斯', 'aatrox_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('267', 'Nami', '唤潮鲛姬', '娜美', 'nami_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('268', 'Azir', '沙漠皇帝', '阿兹尔', 'azir_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('412', 'Thresh', '魂锁典狱长', '锤石', 'thresh_square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('420', 'Illaoi', '海兽祭司', '俄洛伊', 'illaoi_Square_0.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('421', 'RekSai', '虚空遁地兽', '雷克塞', 'RekSai.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('427', 'Ivern', '翠神', '艾翁', 'Ivern_Square_0.png', '2016-10-16 21:45:48');
INSERT INTO `allchampion` VALUES ('429', 'Kalista', '复仇之矛', '卡莉丝塔', 'Kalista.png', '2016-08-14 21:45:48');
INSERT INTO `allchampion` VALUES ('432', 'Bard', '星界游神', '巴德', 'Bard_Square_0.png', '2016-08-14 21:45:48');

-- ----------------------------
-- Table structure for gametype
-- ----------------------------
DROP TABLE IF EXISTS `gametype`;
CREATE TABLE `gametype` (
  `Id` int(11) NOT NULL,
  `Title` varchar(10) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of gametype
-- ----------------------------
INSERT INTO `gametype` VALUES ('1', '自定义');
INSERT INTO `gametype` VALUES ('2', '新手关');
INSERT INTO `gametype` VALUES ('3', '匹配赛');
INSERT INTO `gametype` VALUES ('4', '排位赛');
INSERT INTO `gametype` VALUES ('5', '战队赛');
INSERT INTO `gametype` VALUES ('6', '大乱斗');
INSERT INTO `gametype` VALUES ('7', '人机');
INSERT INTO `gametype` VALUES ('8', '统治战场');
INSERT INTO `gametype` VALUES ('9', '大对决');
INSERT INTO `gametype` VALUES ('11', '克隆赛');
INSERT INTO `gametype` VALUES ('14', '无限火力');
INSERT INTO `gametype` VALUES ('15', '镜像赛');
INSERT INTO `gametype` VALUES ('16', '末日赛');
INSERT INTO `gametype` VALUES ('17', '飞升赛');
INSERT INTO `gametype` VALUES ('18', '六杀丛林');
INSERT INTO `gametype` VALUES ('19', '魄罗乱斗');
INSERT INTO `gametype` VALUES ('20', '互选征召');
INSERT INTO `gametype` VALUES ('21', '佣兵战');

-- ----------------------------
-- Table structure for maptype
-- ----------------------------
DROP TABLE IF EXISTS `maptype`;
CREATE TABLE `maptype` (
  `Id` int(11) NOT NULL,
  `MapName` varchar(10) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of maptype
-- ----------------------------
INSERT INTO `maptype` VALUES ('0', '未知地图');
INSERT INTO `maptype` VALUES ('1', '召唤师峡谷');
INSERT INTO `maptype` VALUES ('3', '试炼之地');
INSERT INTO `maptype` VALUES ('8', '水晶之痕');
INSERT INTO `maptype` VALUES ('10', '扭曲丛林');
INSERT INTO `maptype` VALUES ('11', '召唤师峡谷');
INSERT INTO `maptype` VALUES ('12', '嚎哭深渊');
INSERT INTO `maptype` VALUES ('14', '屠夫之桥');

-- ----------------------------
-- Table structure for tierqueue
-- ----------------------------
DROP TABLE IF EXISTS `tierqueue`;
CREATE TABLE `tierqueue`(
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Tier` int(11) NOT NULL,
  `Queue` int(11) NOT NULL,
  `Title` varchar(10) NOT NULL,
  PRIMARY KEY(`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tierqueue
-- ----------------------------
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('5', '4', '青铜V');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('5', '3', '青铜IV');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('5', '2', '青铜III');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('5', '1', '青铜II');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('5', '0', '青铜I');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('4', '4', '白银V');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('4', '3', '白银IV');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('4', '2', '白银III');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('4', '1', '白银II');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('4', '0', '白银I');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('3', '4', '黄金V');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('3', '3', '黄金IV');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('3', '2', '黄金III');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('3', '1', '黄金II');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('3', '0', '黄金I');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('2', '4', '铂金V');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('2', '3', '铂金IV');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('2', '2', '铂金III');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('2', '1', '铂金II');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('2', '0', '铂金I');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('1', '4', '钻石V');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('1', '3', '钻石IV');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('1', '2', '钻石III');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('1', '1', '钻石II');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('1', '0', '钻石I');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('0', '0', '最强王者');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('6', '0', '超凡大师');
INSERT INTO `tierqueue`(`Tier`,`Queue`,`Title`) VALUES ('255', '255', '无段位');

-- ----------------------------
-- Table structure for winorlose
-- ----------------------------
DROP TABLE IF EXISTS `winorlose`;
CREATE TABLE `winorlose` (
  `Id` int(11) NOT NULL,
  `Title` varchar(10) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of winorlose
-- ----------------------------
INSERT INTO `winorlose` VALUES ('0', 'Lose');
INSERT INTO `winorlose` VALUES ('1', 'Win');
