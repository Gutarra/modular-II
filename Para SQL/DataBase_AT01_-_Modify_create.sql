-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-03-01 23:51:44.876

use master
IF EXISTS(SELECT name FROM sys.databases WHERE name = N'Almacen')
 SET NOCOUNT ON
 DECLARE @DBName varchar(50)
 DECLARE @spidstr varchar(8000)
 DECLARE @ConnKilled smallint
 SET @ConnKilled=0
 SET @spidstr = ''
 Set @DBName = 'AT'
 IF db_id(@DBName) < 4
 BEGIN
 PRINT 'Connections to system databases cannot be killed'
 RETURN
 END
 SELECT @spidstr=coalesce(@spidstr,',' )+'kill '+convert(varchar, spid)+ '; '
 FROM master..sysprocesses WHERE dbid=db_id(@DBName)
 IF LEN(@spidstr) > 0
 BEGIN
 EXEC(@spidstr)
 SELECT @ConnKilled = COUNT(1)
 FROM master..sysprocesses WHERE dbid=db_id(@DBName)
 END
 drop database AT

use master
create database AT
go
use AT;

-- tables
-- Table: Cargo
CREATE TABLE Cargo (
    CodCargo tinyint  NOT NULL IDENTITY(1, 1),
    Nombre varchar(50)  NOT NULL,
    CONSTRAINT Cargo_pk PRIMARY KEY  (CodCargo)
);

insert into Cargo
values
('ADMINISTRADOR'),
('COORDINADOR'),
('SECRETARIA');

-- Table: Departamento
CREATE TABLE Departamento (
    IdDepartamento tinyint  NOT NULL,
    Nombre varchar(50)  NOT NULL,
    CONSTRAINT Departamento_pk PRIMARY KEY  (IdDepartamento)
);

insert into Departamento
values
(1,  'Amazonas'),
(2, 'Áncash'),
(3, 'Apurímac'),
(4, 'Arequipa'),
(5, 'Ayacucho'),
(6, 'Cajamarca'),
(7, 'Callao'),
(8, 'Cusco'),
(9, 'Huancavelica'),
(10, 'Huánuco'),
(11, 'Ica'),
(12, 'Junín'),
(13, 'La Libertad'),
(14, 'Lambayeque'),
(15, 'Lima'),
(16, 'Loreto'),
(17, 'Madre de Dios'),
(18, 'Moquegua'),
(19, 'Pasco'),
(20, 'Piura'),
(21, 'Puno'),
(22, 'San Martín'),
(23, 'Tacna'),
(24, 'Tumbes'),
(25, 'Ucayali');

-- Table: Distrito
CREATE TABLE Distrito (
    IdDistrito smallint  NOT NULL,
    Nombre varchar(100)  NOT NULL,
    IdProvincia tinyint  NOT NULL,
    CONSTRAINT Distrito_pk PRIMARY KEY  (IdDistrito)
);

INSERT INTO Distrito
VALUES
(1, 'Chachapoyas', 1),
(2, 'Asunción', 1),
(3, 'Balsas', 1),
(4, 'Cheto', 1),
(5, 'Chiliquin', 1),
(6, 'Chuquibamba', 1),
(7, 'Granada', 1),
(8, 'Huancas', 1),
(9, 'La Jalca', 1),
(10, 'Leimebamba', 1),
(11, 'Levanto', 1),
(12, 'Magdalena', 1),
(13, 'Mariscal Castilla', 1),
(14, 'Molinopampa', 1),
(15, 'Montevideo', 1),
(16, 'Olleros', 1),
(17, 'Quinjalca', 1),
(18, 'San Francisco de Daguas', 1),
(19, 'San Isidro de Maino', 1),
(20, 'Soloco', 1),
(21, 'Sonche', 1),
(22, 'Bagua', 2),
(23, 'Aramango', 2),
(24, 'Copallin', 2),
(25, 'El Parco', 2),
(26, 'Imaza', 2),
(27, 'La Peca', 2),
(28, 'Jumbilla', 3),
(29, 'Chisquilla', 3),
(30, 'Churuja', 3),
(31, 'Corosha', 3),
(32, 'Cuispes', 3),
(33, 'Florida', 3),
(34, 'Jazan', 3),
(35, 'Recta', 3),
(36, 'San Carlos', 3),
(37, 'Shipasbamba', 3),
(38, 'Valera', 3),
(39, 'Yambrasbamba', 3),
(40, 'Nieva', 4),
(41, 'El Cenepa', 4),
(42, 'Río Santiago', 4),
(43, 'Lamud', 5),
(44, 'Camporredondo', 5),
(45, 'Cocabamba', 5),
(46, 'Colcamar', 5),
(47, 'Conila', 5),
(48, 'Inguilpata', 5),
(49, 'Longuita', 5),
(50, 'Lonya Chico', 5),
(51, 'Luya', 5),
(52, 'Luya Viejo', 5),
(53, 'María', 5),
(54, 'Ocalli', 5),
(55, 'Ocumal', 5),
(56, 'Pisuquia', 5),
(57, 'Providencia', 5),
(58, 'San Cristóbal', 5),
(59, 'San Francisco de Yeso', 5),
(60, 'San Jerónimo', 5),
(61, 'San Juan de Lopecancha', 5),
(62, 'Santa Catalina', 5),
(63, 'Santo Tomas', 5),
(64, 'Tingo', 5),
(65, 'Trita', 5),
(66, 'San Nicolás', 6),
(67, 'Chirimoto', 6),
(68, 'Cochamal', 6),
(69, 'Huambo', 6),
(70, 'Limabamba', 6),
(71, 'Longar', 6),
(72, 'Mariscal Benavides', 6),
(73, 'Milpuc', 6),
(74, 'Omia', 6),
(75, 'Santa Rosa', 6),
(76, 'Totora', 6),
(77, 'Vista Alegre', 6),
(78, 'Bagua Grande', 7),
(79, 'Cajaruro', 7),
(80, 'Cumba', 7),
(81, 'El Milagro', 7),
(82, 'Jamalca', 7),
(83, 'Lonya Grande', 7),
(84, 'Yamon', 7),
(85, 'Huaraz', 8),
(86, 'Cochabamba', 8),
(87, 'Colcabamba', 8),
(88, 'Huanchay', 8),
(89, 'Independencia', 8),
(90, 'Jangas', 8),
(91, 'La Libertad', 8),
(92, 'Olleros', 8),
(93, 'Pampas Grande', 8),
(94, 'Pariacoto', 8),
(95, 'Pira', 8),
(96, 'Tarica', 8),
(97, 'Aija', 9),
(98, 'Coris', 9),
(99, 'Huacllan', 9),
(100, 'La Merced', 9),
(101, 'Succha', 9),
(102, 'Llamellin', 10),
(103, 'Aczo', 10),
(104, 'Chaccho', 10),
(105, 'Chingas', 10),
(106, 'Mirgas', 10),
(107, 'San Juan de Rontoy', 10),
(108, 'Chacas', 11),
(109, 'Acochaca', 11),
(110, 'Chiquian', 12),
(111, 'Abelardo Pardo Lezameta', 12),
(112, 'Antonio Raymondi', 12),
(113, 'Aquia', 12),
(114, 'Cajacay', 12),
(115, 'Canis', 12),
(116, 'Colquioc', 12),
(117, 'Huallanca', 12),
(118, 'Huasta', 12),
(119, 'Huayllacayan', 12),
(120, 'La Primavera', 12),
(121, 'Mangas', 12),
(122, 'Pacllon', 12),
(123, 'San Miguel de Corpanqui', 12),
(124, 'Ticllos', 12),
(125, 'Carhuaz', 13),
(126, 'Acopampa', 13),
(127, 'Amashca', 13),
(128, 'Anta', 13),
(129, 'Ataquero', 13),
(130, 'Marcara', 13),
(131, 'Pariahuanca', 13),
(132, 'San Miguel de Aco', 13),
(133, 'Shilla', 13),
(134, 'Tinco', 13),
(135, 'Yungar', 13),
(136, 'San Luis', 14),
(137, 'San Nicolás', 14),
(138, 'Yauya', 14),
(139, 'Casma', 15),
(140, 'Buena Vista Alta', 15),
(141, 'Comandante Noel', 15),
(142, 'Yautan', 15),
(143, 'Corongo', 16),
(144, 'Aco', 16),
(145, 'Bambas', 16),
(146, 'Cusca', 16),
(147, 'La Pampa', 16),
(148, 'Yanac', 16),
(149, 'Yupan', 16),
(150, 'Huari', 17),
(151, 'Anra', 17),
(152, 'Cajay', 17),
(153, 'Chavin de Huantar', 17),
(154, 'Huacachi', 17),
(155, 'Huacchis', 17),
(156, 'Huachis', 17),
(157, 'Huantar', 17),
(158, 'Masin', 17),
(159, 'Paucas', 17),
(160, 'Ponto', 17),
(161, 'Rahuapampa', 17),
(162, 'Rapayan', 17),
(163, 'San Marcos', 17),
(164, 'San Pedro de Chana', 17),
(165, 'Uco', 17),
(166, 'Huarmey', 18),
(167, 'Cochapeti', 18),
(168, 'Culebras', 18),
(169, 'Huayan', 18),
(170, 'Malvas', 18),
(171, 'Caraz', 19),
(172, 'Huallanca', 19),
(173, 'Huata', 19),
(174, 'Huaylas', 19),
(175, 'Mato', 19),
(176, 'Pamparomas', 19),
(177, 'Pueblo Libre', 19),
(178, 'Santa Cruz', 19),
(179, 'Santo Toribio', 19),
(180, 'Yuracmarca', 19),
(181, 'Piscobamba', 20),
(182, 'Casca', 20),
(183, 'Eleazar Guzmán Barron', 20),
(184, 'Fidel Olivas Escudero', 20),
(185, 'Llama', 20),
(186, 'Llumpa', 20),
(187, 'Lucma', 20),
(188, 'Musga', 20),
(189, 'Ocros', 21),
(190, 'Acas', 21),
(191, 'Cajamarquilla', 21),
(192, 'Carhuapampa', 21),
(193, 'Cochas', 21),
(194, 'Congas', 21),
(195, 'Llipa', 21),
(196, 'San Cristóbal de Rajan', 21),
(197, 'San Pedro', 21),
(198, 'Santiago de Chilcas', 21),
(199, 'Cabana', 22),
(200, 'Bolognesi', 22),
(201, 'Conchucos', 22),
(202, 'Huacaschuque', 22),
(203, 'Huandoval', 22),
(204, 'Lacabamba', 22),
(205, 'Llapo', 22),
(206, 'Pallasca', 22),
(207, 'Pampas', 22),
(208, 'Santa Rosa', 22),
(209, 'Tauca', 22),
(210, 'Pomabamba', 23),
(211, 'Huayllan', 23),
(212, 'Parobamba', 23),
(213, 'Quinuabamba', 23),
(214, 'Recuay', 24),
(215, 'Catac', 24),
(216, 'Cotaparaco', 24),
(217, 'Huayllapampa', 24),
(218, 'Llacllin', 24),
(219, 'Marca', 24),
(220, 'Pampas Chico', 24),
(221, 'Pararin', 24),
(222, 'Tapacocha', 24),
(223, 'Ticapampa', 24),
(224, 'Chimbote', 25),
(225, 'Cáceres del Perú', 25),
(226, 'Coishco', 25),
(227, 'Macate', 25),
(228, 'Moro', 25),
(229, 'Nepeña', 25),
(230, 'Samanco', 25),
(231, 'Santa', 25),
(232, 'Nuevo Chimbote', 25),
(233, 'Sihuas', 26),
(234, 'Acobamba', 26),
(235, 'Alfonso Ugarte', 26),
(236, 'Cashapampa', 26),
(237, 'Chingalpo', 26),
(238, 'Huayllabamba', 26),
(239, 'Quiches', 26),
(240, 'Ragash', 26),
(241, 'San Juan', 26),
(242, 'Sicsibamba', 26),
(243, 'Yungay', 27),
(244, 'Cascapara', 27),
(245, 'Mancos', 27),
(246, 'Matacoto', 27),
(247, 'Quillo', 27),
(248, 'Ranrahirca', 27),
(249, 'Shupluy', 27),
(250, 'Yanama', 27),
(251, 'Abancay', 28),
(252, 'Chacoche', 28),
(253, 'Circa', 28),
(254, 'Curahuasi', 28),
(255, 'Huanipaca', 28),
(256, 'Lambrama', 28),
(257, 'Pichirhua', 28),
(258, 'San Pedro de Cachora', 28),
(259, 'Tamburco', 28),
(260, 'Andahuaylas', 29),
(261, 'Andarapa', 29),
(262, 'Chiara', 29),
(263, 'Huancarama', 29),
(264, 'Huancaray', 29),
(265, 'Huayana', 29),
(266, 'Kishuara', 29),
(267, 'Pacobamba', 29),
(268, 'Pacucha', 29),
(269, 'Pampachiri', 29),
(270, 'Pomacocha', 29),
(271, 'San Antonio de Cachi', 29),
(272, 'San Jerónimo', 29),
(273, 'San Miguel de Chaccrampa', 29),
(274, 'Santa María de Chicmo', 29),
(275, 'Talavera', 29),
(276, 'Tumay Huaraca', 29),
(277, 'Turpo', 29),
(278, 'Kaquiabamba', 29),
(279, 'José María Arguedas', 29),
(280, 'Antabamba', 30),
(281, 'El Oro', 30),
(282, 'Huaquirca', 30),
(283, 'Juan Espinoza Medrano', 30),
(284, 'Oropesa', 30),
(285, 'Pachaconas', 30),
(286, 'Sabaino', 30),
(287, 'Chalhuanca', 31),
(288, 'Capaya', 31),
(289, 'Caraybamba', 31),
(290, 'Chapimarca', 31),
(291, 'Colcabamba', 31),
(292, 'Cotaruse', 31),
(293, 'Ihuayllo', 31),
(294, 'Justo Apu Sahuaraura', 31),
(295, 'Lucre', 31),
(296, 'Pocohuanca', 31),
(297, 'San Juan de Chacña', 31),
(298, 'Sañayca', 31),
(299, 'Soraya', 31),
(300, 'Tapairihua', 31),
(301, 'Tintay', 31),
(302, 'Toraya', 31),
(303, 'Yanaca', 31),
(304, 'Tambobamba', 32),
(305, 'Cotabambas', 32),
(306, 'Coyllurqui', 32),
(307, 'Haquira', 32),
(308, 'Mara', 32),
(309, 'Challhuahuacho', 32),
(310, 'Chincheros', 33),
(311, 'Anco_Huallo', 33),
(312, 'Cocharcas', 33),
(313, 'Huaccana', 33),
(314, 'Ocobamba', 33),
(315, 'Ongoy', 33),
(316, 'Uranmarca', 33),
(317, 'Ranracancha', 33),
(318, 'Rocchacc', 33),
(319, 'El Porvenir', 33),
(320, 'Los Chankas', 33),
(321, 'Chuquibambilla', 34),
(322, 'Curpahuasi', 34),
(323, 'Gamarra', 34),
(324, 'Huayllati', 34),
(325, 'Mamara', 34),
(326, 'Micaela Bastidas', 34),
(327, 'Pataypampa', 34),
(328, 'Progreso', 34),
(329, 'San Antonio', 34),
(330, 'Santa Rosa', 34),
(331, 'Turpay', 34),
(332, 'Vilcabamba', 34),
(333, 'Virundo', 34),
(334, 'Curasco', 34),
(335, 'Arequipa', 35),
(336, 'Alto Selva Alegre', 35),
(337, 'Cayma', 35),
(338, 'Cerro Colorado', 35),
(339, 'Characato', 35),
(340, 'Chiguata', 35),
(341, 'Jacobo Hunter', 35),
(342, 'La Joya', 35),
(343, 'Mariano Melgar', 35),
(344, 'Miraflores', 35),
(345, 'Mollebaya', 35),
(346, 'Paucarpata', 35),
(347, 'Pocsi', 35),
(348, 'Polobaya', 35),
(349, 'Quequeña', 35),
(350, 'Sabandia', 35),
(351, 'Sachaca', 35),
(352, 'San Juan de Siguas', 35),
(353, 'San Juan de Tarucani', 35),
(354, 'Santa Isabel de Siguas', 35),
(355, 'Santa Rita de Siguas', 35),
(356, 'Socabaya', 35),
(357, 'Tiabaya', 35),
(358, 'Uchumayo', 35),
(359, 'Vitor', 35),
(360, 'Yanahuara', 35),
(361, 'Yarabamba', 35),
(362, 'Yura', 35),
(363, 'José Luis Bustamante Y Rivero', 35),
(364, 'Camaná', 36),
(365, 'José María Quimper', 36),
(366, 'Mariano Nicolás Valcárcel', 36),
(367, 'Mariscal Cáceres', 36),
(368, 'Nicolás de Pierola', 36),
(369, 'Ocoña', 36),
(370, 'Quilca', 36),
(371, 'Samuel Pastor', 36),
(372, 'Caravelí', 37),
(373, 'Acarí', 37),
(374, 'Atico', 37),
(375, 'Atiquipa', 37),
(376, 'Bella Unión', 37),
(377, 'Cahuacho', 37),
(378, 'Chala', 37),
(379, 'Chaparra', 37),
(380, 'Huanuhuanu', 37),
(381, 'Jaqui', 37),
(382, 'Lomas', 37),
(383, 'Quicacha', 37),
(384, 'Yauca', 37),
(385, 'Aplao', 38),
(386, 'Andagua', 38),
(387, 'Ayo', 38),
(388, 'Chachas', 38),
(389, 'Chilcaymarca', 38),
(390, 'Choco', 38),
(391, 'Huancarqui', 38),
(392, 'Machaguay', 38),
(393, 'Orcopampa', 38),
(394, 'Pampacolca', 38),
(395, 'Tipan', 38),
(396, 'Uñon', 38),
(397, 'Uraca', 38),
(398, 'Viraco', 38),
(399, 'Chivay', 39),
(400, 'Achoma', 39),
(401, 'Cabanaconde', 39),
(402, 'Callalli', 39),
(403, 'Caylloma', 39),
(404, 'Coporaque', 39),
(405, 'Huambo', 39),
(406, 'Huanca', 39),
(407, 'Ichupampa', 39),
(408, 'Lari', 39),
(409, 'Lluta', 39),
(410, 'Maca', 39),
(411, 'Madrigal', 39),
(412, 'San Antonio de Chuca', 39),
(413, 'Sibayo', 39),
(414, 'Tapay', 39),
(415, 'Tisco', 39),
(416, 'Tuti', 39),
(417, 'Yanque', 39),
(418, 'Majes', 39),
(419, 'Chuquibamba', 40),
(420, 'Andaray', 40),
(421, 'Cayarani', 40),
(422, 'Chichas', 40),
(423, 'Iray', 40),
(424, 'Río Grande', 40),
(425, 'Salamanca', 40),
(426, 'Yanaquihua', 40),
(427, 'Mollendo', 41),
(428, 'Cocachacra', 41),
(429, 'Dean Valdivia', 41),
(430, 'Islay', 41),
(431, 'Mejia', 41),
(432, 'Punta de Bombón', 41),
(433, 'Cotahuasi', 42),
(434, 'Alca', 42),
(435, 'Charcana', 42),
(436, 'Huaynacotas', 42),
(437, 'Pampamarca', 42),
(438, 'Puyca', 42),
(439, 'Quechualla', 42),
(440, 'Sayla', 42),
(441, 'Tauria', 42),
(442, 'Tomepampa', 42),
(443, 'Toro', 42),
(444, 'Ayacucho', 43),
(445, 'Acocro', 43),
(446, 'Acos Vinchos', 43),
(447, 'Carmen Alto', 43),
(448, 'Chiara', 43),
(449, 'Ocros', 43),
(450, 'Pacaycasa', 43),
(451, 'Quinua', 43),
(452, 'San José de Ticllas', 43),
(453, 'San Juan Bautista', 43),
(454, 'Santiago de Pischa', 43),
(455, 'Socos', 43),
(456, 'Tambillo', 43),
(457, 'Vinchos', 43),
(458, 'Jesús Nazareno', 43),
(459, 'Andrés Avelino Cáceres Dorregaray', 43),
(460, 'Cangallo', 44),
(461, 'Chuschi', 44),
(462, 'Los Morochucos', 44),
(463, 'María Parado de Bellido', 44),
(464, 'Paras', 44),
(465, 'Totos', 44),
(466, 'Sancos', 45),
(467, 'Carapo', 45),
(468, 'Sacsamarca', 45),
(469, 'Santiago de Lucanamarca', 45),
(470, 'Huanta', 46),
(471, 'Ayahuanco', 46),
(472, 'Huamanguilla', 46),
(473, 'Iguain', 46),
(474, 'Luricocha', 46),
(475, 'Santillana', 46),
(476, 'Sivia', 46),
(477, 'Llochegua', 46),
(478, 'Canayre', 46),
(479, 'Uchuraccay', 46),
(480, 'Pucacolpa', 46),
(481, 'Chaca', 46),
(482, 'San Miguel', 47),
(483, 'Anco', 47),
(484, 'Ayna', 47),
(485, 'Chilcas', 47),
(486, 'Chungui', 47),
(487, 'Luis Carranza', 47),
(488, 'Santa Rosa', 47),
(489, 'Tambo', 47),
(490, 'Samugari', 47),
(491, 'Anchihuay', 47),
(492, 'Oronccoy', 47),
(493, 'Puquio', 48),
(494, 'Aucara', 48),
(495, 'Cabana', 48),
(496, 'Carmen Salcedo', 48),
(497, 'Chaviña', 48),
(498, 'Chipao', 48),
(499, 'Huac-Huas', 48),
(500, 'Laramate', 48),
(501, 'Leoncio Prado', 48),
(502, 'Llauta', 48),
(503, 'Lucanas', 48),
(504, 'Ocaña', 48),
(505, 'Otoca', 48),
(506, 'Saisa', 48),
(507, 'San Cristóbal', 48),
(508, 'San Juan', 48),
(509, 'San Pedro', 48),
(510, 'San Pedro de Palco', 48),
(511, 'Sancos', 48),
(512, 'Santa Ana de Huaycahuacho', 48),
(513, 'Santa Lucia', 48),
(514, 'Coracora', 49),
(515, 'Chumpi', 49),
(516, 'Coronel Castañeda', 49),
(517, 'Pacapausa', 49),
(518, 'Pullo', 49),
(519, 'Puyusca', 49),
(520, 'San Francisco de Ravacayco', 49),
(521, 'Upahuacho', 49),
(522, 'Pausa', 50),
(523, 'Colta', 50),
(524, 'Corculla', 50),
(525, 'Lampa', 50),
(526, 'Marcabamba', 50),
(527, 'Oyolo', 50),
(528, 'Pararca', 50),
(529, 'San Javier de Alpabamba', 50),
(530, 'San José de Ushua', 50),
(531, 'Sara Sara', 50),
(532, 'Querobamba', 51),
(533, 'Belén', 51),
(534, 'Chalcos', 51),
(535, 'Chilcayoc', 51),
(536, 'Huacaña', 51),
(537, 'Morcolla', 51),
(538, 'Paico', 51),
(539, 'San Pedro de Larcay', 51),
(540, 'San Salvador de Quije', 51),
(541, 'Santiago de Paucaray', 51),
(542, 'Soras', 51),
(543, 'Huancapi', 52),
(544, 'Alcamenca', 52),
(545, 'Apongo', 52),
(546, 'Asquipata', 52),
(547, 'Canaria', 52),
(548, 'Cayara', 52),
(549, 'Colca', 52),
(550, 'Huamanquiquia', 52),
(551, 'Huancaraylla', 52),
(552, 'Hualla', 52),
(553, 'Sarhua', 52),
(554, 'Vilcanchos', 52),
(555, 'Vilcas Huaman', 53),
(556, 'Accomarca', 53),
(557, 'Carhuanca', 53),
(558, 'Concepción', 53),
(559, 'Huambalpa', 53),
(560, 'Independencia', 53),
(561, 'Saurama', 53),
(562, 'Vischongo', 53),
(563, 'Cajamarca', 54),
(564, 'Asunción', 54),
(565, 'Chetilla', 54),
(566, 'Cospan', 54),
(567, 'Encañada', 54),
(568, 'Jesús', 54),
(569, 'Llacanora', 54),
(570, 'Los Baños del Inca', 54),
(571, 'Magdalena', 54),
(572, 'Matara', 54),
(573, 'Namora', 54),
(574, 'San Juan', 54),
(575, 'Cajabamba', 55),
(576, 'Cachachi', 55),
(577, 'Condebamba', 55),
(578, 'Sitacocha', 55),
(579, 'Celendín', 56),
(580, 'Chumuch', 56),
(581, 'Cortegana', 56),
(582, 'Huasmin', 56),
(583, 'Jorge Chávez', 56),
(584, 'José Gálvez', 56),
(585, 'Miguel Iglesias', 56),
(586, 'Oxamarca', 56),
(587, 'Sorochuco', 56),
(588, 'Sucre', 56),
(589, 'Utco', 56),
(590, 'La Libertad de Pallan', 56),
(591, 'Chota', 57),
(592, 'Anguia', 57),
(593, 'Chadin', 57),
(594, 'Chiguirip', 57),
(595, 'Chimban', 57),
(596, 'Choropampa', 57),
(597, 'Cochabamba', 57),
(598, 'Conchan', 57),
(599, 'Huambos', 57),
(600, 'Lajas', 57),
(601, 'Llama', 57),
(602, 'Miracosta', 57),
(603, 'Paccha', 57),
(604, 'Pion', 57),
(605, 'Querocoto', 57),
(606, 'San Juan de Licupis', 57),
(607, 'Tacabamba', 57),
(608, 'Tocmoche', 57),
(609, 'Chalamarca', 57),
(610, 'Contumaza', 58),
(611, 'Chilete', 58),
(612, 'Cupisnique', 58),
(613, 'Guzmango', 58),
(614, 'San Benito', 58),
(615, 'Santa Cruz de Toledo', 58),
(616, 'Tantarica', 58),
(617, 'Yonan', 58),
(618, 'Cutervo', 59),
(619, 'Callayuc', 59),
(620, 'Choros', 59),
(621, 'Cujillo', 59),
(622, 'La Ramada', 59),
(623, 'Pimpingos', 59),
(624, 'Querocotillo', 59),
(625, 'San Andrés de Cutervo', 59),
(626, 'San Juan de Cutervo', 59),
(627, 'San Luis de Lucma', 59),
(628, 'Santa Cruz', 59),
(629, 'Santo Domingo de la Capilla', 59),
(630, 'Santo Tomas', 59),
(631, 'Socota', 59),
(632, 'Toribio Casanova', 59),
(633, 'Bambamarca', 60),
(634, 'Chugur', 60),
(635, 'Hualgayoc', 60),
(636, 'Jaén', 61),
(637, 'Bellavista', 61),
(638, 'Chontali', 61),
(639, 'Colasay', 61),
(640, 'Huabal', 61),
(641, 'Las Pirias', 61),
(642, 'Pomahuaca', 61),
(643, 'Pucara', 61),
(644, 'Sallique', 61),
(645, 'San Felipe', 61),
(646, 'San José del Alto', 61),
(647, 'Santa Rosa', 61),
(648, 'San Ignacio', 62),
(649, 'Chirinos', 62),
(650, 'Huarango', 62),
(651, 'La Coipa', 62),
(652, 'Namballe', 62),
(653, 'San José de Lourdes', 62),
(654, 'Tabaconas', 62),
(655, 'Pedro Gálvez', 63),
(656, 'Chancay', 63),
(657, 'Eduardo Villanueva', 63),
(658, 'Gregorio Pita', 63),
(659, 'Ichocan', 63),
(660, 'José Manuel Quiroz', 63),
(661, 'José Sabogal', 63),
(662, 'San Miguel', 64),
(663, 'Bolívar', 64),
(664, 'Calquis', 64),
(665, 'Catilluc', 64),
(666, 'El Prado', 64),
(667, 'La Florida', 64),
(668, 'Llapa', 64),
(669, 'Nanchoc', 64),
(670, 'Niepos', 64),
(671, 'San Gregorio', 64),
(672, 'San Silvestre de Cochan', 64),
(673, 'Tongod', 64),
(674, 'Unión Agua Blanca', 64),
(675, 'San Pablo', 65),
(676, 'San Bernardino', 65),
(677, 'San Luis', 65),
(678, 'Tumbaden', 65),
(679, 'Santa Cruz', 66),
(680, 'Andabamba', 66),
(681, 'Catache', 66),
(682, 'Chancaybaños', 66),
(683, 'La Esperanza', 66),
(684, 'Ninabamba', 66),
(685, 'Pulan', 66),
(686, 'Saucepampa', 66),
(687, 'Sexi', 66),
(688, 'Uticyacu', 66),
(689, 'Yauyucan', 66),
(690, 'Callao', 67),
(691, 'Bellavista', 67),
(692, 'Carmen de la Legua Reynoso', 67),
(693, 'La Perla', 67),
(694, 'La Punta', 67),
(695, 'Ventanilla', 67),
(696, 'Mi Perú', 67),
(697, 'Cusco', 68),
(698, 'Ccorca', 68),
(699, 'Poroy', 68),
(700, 'San Jerónimo', 68),
(701, 'San Sebastian', 68),
(702, 'Santiago', 68),
(703, 'Saylla', 68),
(704, 'Wanchaq', 68),
(705, 'Acomayo', 69),
(706, 'Acopia', 69),
(707, 'Acos', 69),
(708, 'Mosoc Llacta', 69),
(709, 'Pomacanchi', 69),
(710, 'Rondocan', 69),
(711, 'Sangarara', 69),
(712, 'Anta', 70),
(713, 'Ancahuasi', 70),
(714, 'Cachimayo', 70),
(715, 'Chinchaypujio', 70),
(716, 'Huarocondo', 70),
(717, 'Limatambo', 70),
(718, 'Mollepata', 70),
(719, 'Pucyura', 70),
(720, 'Zurite', 70),
(721, 'Calca', 71),
(722, 'Coya', 71),
(723, 'Lamay', 71),
(724, 'Lares', 71),
(725, 'Pisac', 71),
(726, 'San Salvador', 71),
(727, 'Taray', 71),
(728, 'Yanatile', 71),
(729, 'Yanaoca', 72),
(730, 'Checca', 72),
(731, 'Kunturkanki', 72),
(732, 'Langui', 72),
(733, 'Layo', 72),
(734, 'Pampamarca', 72),
(735, 'Quehue', 72),
(736, 'Tupac Amaru', 72),
(737, 'Sicuani', 73),
(738, 'Checacupe', 73),
(739, 'Combapata', 73),
(740, 'Marangani', 73),
(741, 'Pitumarca', 73),
(742, 'San Pablo', 73),
(743, 'San Pedro', 73),
(744, 'Tinta', 73),
(745, 'Santo Tomas', 74),
(746, 'Capacmarca', 74),
(747, 'Chamaca', 74),
(748, 'Colquemarca', 74),
(749, 'Livitaca', 74),
(750, 'Llusco', 74),
(751, 'Quiñota', 74),
(752, 'Velille', 74),
(753, 'Espinar', 75),
(754, 'Condoroma', 75),
(755, 'Coporaque', 75),
(756, 'Ocoruro', 75),
(757, 'Pallpata', 75),
(758, 'Pichigua', 75),
(759, 'Suyckutambo', 75),
(760, 'Alto Pichigua', 75),
(761, 'Santa Ana', 76),
(762, 'Echarate', 76),
(763, 'Huayopata', 76),
(764, 'Maranura', 76),
(765, 'Ocobamba', 76),
(766, 'Quellouno', 76),
(767, 'Kimbiri', 76),
(768, 'Santa Teresa', 76),
(769, 'Vilcabamba', 76),
(770, 'Pichari', 76),
(771, 'Inkawasi', 76),
(772, 'Villa Virgen', 76),
(773, 'Villa Kintiarina', 76),
(774, 'Megantoni', 76),
(775, 'Paruro', 77),
(776, 'Accha', 77),
(777, 'Ccapi', 77),
(778, 'Colcha', 77),
(779, 'Huanoquite', 77),
(780, 'Omachaç', 77),
(781, 'Paccaritambo', 77),
(782, 'Pillpinto', 77),
(783, 'Yaurisque', 77),
(784, 'Paucartambo', 78),
(785, 'Caicay', 78),
(786, 'Challabamba', 78),
(787, 'Colquepata', 78),
(788, 'Huancarani', 78),
(789, 'Kosñipata', 78),
(790, 'Urcos', 79),
(791, 'Andahuaylillas', 79),
(792, 'Camanti', 79),
(793, 'Ccarhuayo', 79),
(794, 'Ccatca', 79),
(795, 'Cusipata', 79),
(796, 'Huaro', 79),
(797, 'Lucre', 79),
(798, 'Marcapata', 79),
(799, 'Ocongate', 79),
(800, 'Oropesa', 79),
(801, 'Quiquijana', 79),
(802, 'Urubamba', 80),
(803, 'Chinchero', 80),
(804, 'Huayllabamba', 80),
(805, 'Machupicchu', 80),
(806, 'Maras', 80),
(807, 'Ollantaytambo', 80),
(808, 'Yucay', 80),
(809, 'Huancavelica', 81),
(810, 'Acobambilla', 81),
(811, 'Acoria', 81),
(812, 'Conayca', 81),
(813, 'Cuenca', 81),
(814, 'Huachocolpa', 81),
(815, 'Huayllahuara', 81),
(816, 'Izcuchaca', 81),
(817, 'Laria', 81),
(818, 'Manta', 81),
(819, 'Mariscal Cáceres', 81),
(820, 'Moya', 81),
(821, 'Nuevo Occoro', 81),
(822, 'Palca', 81),
(823, 'Pilchaca', 81),
(824, 'Vilca', 81),
(825, 'Yauli', 81),
(826, 'Ascensión', 81),
(827, 'Huando', 81),
(828, 'Acobamba', 82),
(829, 'Andabamba', 82),
(830, 'Anta', 82),
(831, 'Caja', 82),
(832, 'Marcas', 82),
(833, 'Paucara', 82),
(834, 'Pomacocha', 82),
(835, 'Rosario', 82),
(836, 'Lircay', 83),
(837, 'Anchonga', 83),
(838, 'Callanmarca', 83),
(839, 'Ccochaccasa', 83),
(840, 'Chincho', 83),
(841, 'Congalla', 83),
(842, 'Huanca-Huanca', 83),
(843, 'Huayllay Grande', 83),
(844, 'Julcamarca', 83),
(845, 'San Antonio de Antaparco', 83),
(846, 'Santo Tomas de Pata', 83),
(847, 'Secclla', 83),
(848, 'Castrovirreyna', 84),
(849, 'Arma', 84),
(850, 'Aurahua', 84),
(851, 'Capillas', 84),
(852, 'Chupamarca', 84),
(853, 'Cocas', 84),
(854, 'Huachos', 84),
(855, 'Huamatambo', 84),
(856, 'Mollepampa', 84),
(857, 'San Juan', 84),
(858, 'Santa Ana', 84),
(859, 'Tantara', 84),
(860, 'Ticrapo', 84),
(861, 'Churcampa', 85),
(862, 'Anco', 85),
(863, 'Chinchihuasi', 85),
(864, 'El Carmen', 85),
(865, 'La Merced', 85),
(866, 'Locroja', 85),
(867, 'Paucarbamba', 85),
(868, 'San Miguel de Mayocc', 85),
(869, 'San Pedro de Coris', 85),
(870, 'Pachamarca', 85),
(871, 'Cosme', 85),
(872, 'Huaytara', 86),
(873, 'Ayavi', 86),
(874, 'Córdova', 86),
(875, 'Huayacundo Arma', 86),
(876, 'Laramarca', 86),
(877, 'Ocoyo', 86),
(878, 'Pilpichaca', 86),
(879, 'Querco', 86),
(880, 'Quito-Arma', 86),
(881, 'San Antonio de Cusicancha', 86),
(882, 'San Francisco de Sangayaico', 86),
(883, 'San Isidro', 86),
(884, 'Santiago de Chocorvos', 86),
(885, 'Santiago de Quirahuara', 86),
(886, 'Santo Domingo de Capillas', 86),
(887, 'Tambo', 86),
(888, 'Pampas', 87),
(889, 'Acostambo', 87),
(890, 'Acraquia', 87),
(891, 'Ahuaycha', 87),
(892, 'Colcabamba', 87),
(893, 'Daniel Hernández', 87),
(894, 'Huachocolpa', 87),
(895, 'Huaribamba', 87),
(896, 'Ñahuimpuquio', 87),
(897, 'Pazos', 87),
(898, 'Quishuar', 87),
(899, 'Salcabamba', 87),
(900, 'Salcahuasi', 87),
(901, 'San Marcos de Rocchac', 87),
(902, 'Surcubamba', 87),
(903, 'Tintay Puncu', 87),
(904, 'Quichuas', 87),
(905, 'Andaymarca', 87),
(906, 'Roble', 87),
(907, 'Pichos', 87),
(908, 'Santiago de Tucuma', 87),
(909, 'Huanuco', 88),
(910, 'Amarilis', 88),
(911, 'Chinchao', 88),
(912, 'Churubamba', 88),
(913, 'Margos', 88),
(914, 'Quisqui (Kichki)', 88),
(915, 'San Francisco de Cayran', 88),
(916, 'San Pedro de Chaulan', 88),
(917, 'Santa María del Valle', 88),
(918, 'Yarumayo', 88),
(919, 'Pillco Marca', 88),
(920, 'Yacus', 88),
(921, 'San Pablo de Pillao', 88),
(922, 'Ambo', 89),
(923, 'Cayna', 89),
(924, 'Colpas', 89),
(925, 'Conchamarca', 89),
(926, 'Huacar', 89),
(927, 'San Francisco', 89),
(928, 'San Rafael', 89),
(929, 'Tomay Kichwa', 89),
(930, 'La Unión', 90),
(931, 'Chuquis', 90),
(932, 'Marías', 90),
(933, 'Pachas', 90),
(934, 'Quivilla', 90),
(935, 'Ripan', 90),
(936, 'Shunqui', 90),
(937, 'Sillapata', 90),
(938, 'Yanas', 90),
(939, 'Huacaybamba', 91),
(940, 'Canchabamba', 91),
(941, 'Cochabamba', 91),
(942, 'Pinra', 91),
(943, 'Llata', 92),
(944, 'Arancay', 92),
(945, 'Chavín de Pariarca', 92),
(946, 'Jacas Grande', 92),
(947, 'Jircan', 92),
(948, 'Miraflores', 92),
(949, 'Monzón', 92),
(950, 'Punchao', 92),
(951, 'Puños', 92),
(952, 'Singa', 92),
(953, 'Tantamayo', 92),
(954, 'Rupa-Rupa', 93),
(955, 'Daniel Alomía Robles', 93),
(956, 'Hermílio Valdizan', 93),
(957, 'José Crespo y Castillo', 93),
(958, 'Luyando', 93),
(959, 'Mariano Damaso Beraun', 93),
(960, 'Pucayacu', 93),
(961, 'Castillo Grande', 93),
(962, 'Pueblo Nuevo', 93),
(963, 'Santo Domingo de Anda', 93),
(964, 'Huacrachuco', 94),
(965, 'Cholon', 94),
(966, 'San Buenaventura', 94),
(967, 'La Morada', 94),
(968, 'Santa Rosa de Alto Yanajanca', 94),
(969, 'Panao', 95),
(970, 'Chaglla', 95),
(971, 'Molino', 95),
(972, 'Umari', 95),
(973, 'Puerto Inca', 96),
(974, 'Codo del Pozuzo', 96),
(975, 'Honoria', 96),
(976, 'Tournavista', 96),
(977, 'Yuyapichis', 96),
(978, 'Jesús', 97),
(979, 'Baños', 97),
(980, 'Jivia', 97),
(981, 'Queropalca', 97),
(982, 'Rondos', 97),
(983, 'San Francisco de Asís', 97),
(984, 'San Miguel de Cauri', 97),
(985, 'Chavinillo', 98),
(986, 'Cahuac', 98),
(987, 'Chacabamba', 98),
(988, 'Aparicio Pomares', 98),
(989, 'Jacas Chico', 98),
(990, 'Obas', 98),
(991, 'Pampamarca', 98),
(992, 'Choras', 98),
(993, 'Ica', 99),
(994, 'La Tinguiña', 99),
(995, 'Los Aquijes', 99),
(996, 'Ocucaje', 99),
(997, 'Pachacutec', 99),
(998, 'Parcona', 99),
(999, 'Pueblo Nuevo', 99)
INSERT INTO Distrito
VALUES
(1000, 'Salas', 99),
(1001, 'San José de Los Molinos', 99),
(1002, 'San Juan Bautista', 99),
(1003, 'Santiago', 99),
(1004, 'Subtanjalla', 99),
(1005, 'Tate', 99),
(1006, 'Yauca del Rosario', 99),
(1007, 'Chincha Alta', 100),
(1008, 'Alto Laran', 100),
(1009, 'Chavin', 100),
(1010, 'Chincha Baja', 100),
(1011, 'El Carmen', 100),
(1012, 'Grocio Prado', 100),
(1013, 'Pueblo Nuevo', 100),
(1014, 'San Juan de Yanac', 100),
(1015, 'San Pedro de Huacarpana', 100),
(1016, 'Sunampe', 100),
(1017, 'Tambo de Mora', 100),
(1018, 'Nasca', 101),
(1019, 'Changuillo', 101),
(1020, 'El Ingenio', 101),
(1021, 'Marcona', 101),
(1022, 'Vista Alegre', 101),
(1023, 'Palpa', 102),
(1024, 'Llipata', 102),
(1025, 'Río Grande', 102),
(1026, 'Santa Cruz', 102),
(1027, 'Tibillo', 102),
(1028, 'Pisco', 103),
(1029, 'Huancano', 103),
(1030, 'Humay', 103),
(1031, 'Independencia', 103),
(1032, 'Paracas', 103),
(1033, 'San Andrés', 103),
(1034, 'San Clemente', 103),
(1035, 'Tupac Amaru Inca', 103),
(1036, 'Huancayo', 104),
(1037, 'Carhuacallanga', 104),
(1038, 'Chacapampa', 104),
(1039, 'Chicche', 104),
(1040, 'Chilca', 104),
(1041, 'Chongos Alto', 104),
(1042, 'Chupuro', 104),
(1043, 'Colca', 104),
(1044, 'Cullhuas', 104),
(1045, 'El Tambo', 104),
(1046, 'Huacrapuquio', 104),
(1047, 'Hualhuas', 104),
(1048, 'Huancan', 104),
(1049, 'Huasicancha', 104),
(1050, 'Huayucachi', 104),
(1051, 'Ingenio', 104),
(1052, 'Pariahuanca', 104),
(1053, 'Pilcomayo', 104),
(1054, 'Pucara', 104),
(1055, 'Quichuay', 104),
(1056, 'Quilcas', 104),
(1057, 'San Agustín', 104),
(1058, 'San Jerónimo de Tunan', 104),
(1059, 'Saño', 104),
(1060, 'Sapallanga', 104),
(1061, 'Sicaya', 104),
(1062, 'Santo Domingo de Acobamba', 104),
(1063, 'Viques', 104),
(1064, 'Concepción', 105),
(1065, 'Aco', 105),
(1066, 'Andamarca', 105),
(1067, 'Chambara', 105),
(1068, 'Cochas', 105),
(1069, 'Comas', 105),
(1070, 'Heroínas Toledo', 105),
(1071, 'Manzanares', 105),
(1072, 'Mariscal Castilla', 105),
(1073, 'Matahuasi', 105),
(1074, 'Mito', 105),
(1075, 'Nueve de Julio', 105),
(1076, 'Orcotuna', 105),
(1077, 'San José de Quero', 105),
(1078, 'Santa Rosa de Ocopa', 105),
(1079, 'Chanchamayo', 106),
(1080, 'Perene', 106),
(1081, 'Pichanaqui', 106),
(1082, 'San Luis de Shuaro', 106),
(1083, 'San Ramón', 106),
(1084, 'Vitoc', 106),
(1085, 'Jauja', 107),
(1086, 'Acolla', 107),
(1087, 'Apata', 107),
(1088, 'Ataura', 107),
(1089, 'Canchayllo', 107),
(1090, 'Curicaca', 107),
(1091, 'El Mantaro', 107),
(1092, 'Huamali', 107),
(1093, 'Huaripampa', 107),
(1094, 'Huertas', 107),
(1095, 'Janjaillo', 107),
(1096, 'Julcán', 107),
(1097, 'Leonor Ordóñez', 107),
(1098, 'Llocllapampa', 107),
(1099, 'Marco', 107),
(1100, 'Masma', 107),
(1101, 'Masma Chicche', 107),
(1102, 'Molinos', 107),
(1103, 'Monobamba', 107),
(1104, 'Muqui', 107),
(1105, 'Muquiyauyo', 107),
(1106, 'Paca', 107),
(1107, 'Paccha', 107),
(1108, 'Pancan', 107),
(1109, 'Parco', 107),
(1110, 'Pomacancha', 107),
(1111, 'Ricran', 107),
(1112, 'San Lorenzo', 107),
(1113, 'San Pedro de Chunan', 107),
(1114, 'Sausa', 107),
(1115, 'Sincos', 107),
(1116, 'Tunan Marca', 107),
(1117, 'Yauli', 107),
(1118, 'Yauyos', 107),
(1119, 'Junin', 108),
(1120, 'Carhuamayo', 108),
(1121, 'Ondores', 108),
(1122, 'Ulcumayo', 108),
(1123, 'Satipo', 109),
(1124, 'Coviriali', 109),
(1125, 'Llaylla', 109),
(1126, 'Mazamari', 109),
(1127, 'Pampa Hermosa', 109),
(1128, 'Pangoa', 109),
(1129, 'Río Negro', 109),
(1130, 'Río Tambo', 109),
(1131, 'Vizcatan del Ene', 109),
(1132, 'Tarma', 110),
(1133, 'Acobamba', 110),
(1134, 'Huaricolca', 110),
(1135, 'Huasahuasi', 110),
(1136, 'La Unión', 110),
(1137, 'Palca', 110),
(1138, 'Palcamayo', 110),
(1139, 'San Pedro de Cajas', 110),
(1140, 'Tapo', 110),
(1141, 'La Oroya', 111),
(1142, 'Chacapalpa', 111),
(1143, 'Huay-Huay', 111),
(1144, 'Marcapomacocha', 111),
(1145, 'Morococha', 111),
(1146, 'Paccha', 111),
(1147, 'Santa Bárbara de Carhuacayan', 111),
(1148, 'Santa Rosa de Sacco', 111),
(1149, 'Suitucancha', 111),
(1150, 'Yauli', 111),
(1151, 'Chupaca', 112),
(1152, 'Ahuac', 112),
(1153, 'Chongos Bajo', 112),
(1154, 'Huachac', 112),
(1155, 'Huamancaca Chico', 112),
(1156, 'San Juan de Iscos', 112),
(1157, 'San Juan de Jarpa', 112),
(1158, 'Tres de Diciembre', 112),
(1159, 'Yanacancha', 112),
(1160, 'Trujillo', 113),
(1161, 'El Porvenir', 113),
(1162, 'Florencia de Mora', 113),
(1163, 'Huanchaco', 113),
(1164, 'La Esperanza', 113),
(1165, 'Laredo', 113),
(1166, 'Moche', 113),
(1167, 'Poroto', 113),
(1168, 'Salaverry', 113),
(1169, 'Simbal', 113),
(1170, 'Victor Larco Herrera', 113),
(1171, 'Ascope', 114),
(1172, 'Chicama', 114),
(1173, 'Chocope', 114),
(1174, 'Magdalena de Cao', 114),
(1175, 'Paijan', 114),
(1176, 'Rázuri', 114),
(1177, 'Santiago de Cao', 114),
(1178, 'Casa Grande', 114),
(1179, 'Bolívar', 115),
(1180, 'Bambamarca', 115),
(1181, 'Condormarca', 115),
(1182, 'Longotea', 115),
(1183, 'Uchumarca', 115),
(1184, 'Ucuncha', 115),
(1185, 'Chepen', 116),
(1186, 'Pacanga', 116),
(1187, 'Pueblo Nuevo', 116),
(1188, 'Julcan', 117),
(1189, 'Calamarca', 117),
(1190, 'Carabamba', 117),
(1191, 'Huaso', 117),
(1192, 'Otuzco', 118),
(1193, 'Agallpampa', 118),
(1194, 'Charat', 118),
(1195, 'Huaranchal', 118),
(1196, 'La Cuesta', 118),
(1197, 'Mache', 118),
(1198, 'Paranday', 118),
(1199, 'Salpo', 118),
(1200, 'Sinsicap', 118),
(1201, 'Usquil', 118),
(1202, 'San Pedro de Lloc', 119),
(1203, 'Guadalupe', 119),
(1204, 'Jequetepeque', 119),
(1205, 'Pacasmayo', 119),
(1206, 'San José', 119),
(1207, 'Tayabamba', 120),
(1208, 'Buldibuyo', 120),
(1209, 'Chillia', 120),
(1210, 'Huancaspata', 120),
(1211, 'Huaylillas', 120),
(1212, 'Huayo', 120),
(1213, 'Ongon', 120),
(1214, 'Parcoy', 120),
(1215, 'Pataz', 120),
(1216, 'Pias', 120),
(1217, 'Santiago de Challas', 120),
(1218, 'Taurija', 120),
(1219, 'Urpay', 120),
(1220, 'Huamachuco', 121),
(1221, 'Chugay', 121),
(1222, 'Cochorco', 121),
(1223, 'Curgos', 121),
(1224, 'Marcabal', 121),
(1225, 'Sanagoran', 121),
(1226, 'Sarin', 121),
(1227, 'Sartimbamba', 121),
(1228, 'Santiago de Chuco', 122),
(1229, 'Angasmarca', 122),
(1230, 'Cachicadan', 122),
(1231, 'Mollebamba', 122),
(1232, 'Mollepata', 122),
(1233, 'Quiruvilca', 122),
(1234, 'Santa Cruz de Chuca', 122),
(1235, 'Sitabamba', 122),
(1236, 'Cascas', 123),
(1237, 'Lucma', 123),
(1238, 'Marmot', 123),
(1239, 'Sayapullo', 123),
(1240, 'Viru', 124),
(1241, 'Chao', 124),
(1242, 'Guadalupito', 124),
(1243, 'Chiclayo', 125),
(1244, 'Chongoyape', 125),
(1245, 'Eten', 125),
(1246, 'Eten Puerto', 125),
(1247, 'José Leonardo Ortiz', 125),
(1248, 'La Victoria', 125),
(1249, 'Lagunas', 125),
(1250, 'Monsefu', 125),
(1251, 'Nueva Arica', 125),
(1252, 'Oyotun', 125),
(1253, 'Picsi', 125),
(1254, 'Pimentel', 125),
(1255, 'Reque', 125),
(1256, 'Santa Rosa', 125),
(1257, 'Saña', 125),
(1258, 'Cayalti', 125),
(1259, 'Patapo', 125),
(1260, 'Pomalca', 125),
(1261, 'Pucala', 125),
(1262, 'Tuman', 125),
(1263, 'Ferreñafe', 126),
(1264, 'Cañaris', 126),
(1265, 'Incahuasi', 126),
(1266, 'Manuel Antonio Mesones Muro', 126),
(1267, 'Pitipo', 126),
(1268, 'Pueblo Nuevo', 126),
(1269, 'Lambayeque', 127),
(1270, 'Chochope', 127),
(1271, 'Illimo', 127),
(1272, 'Jayanca', 127),
(1273, 'Mochumi', 127),
(1274, 'Morrope', 127),
(1275, 'Motupe', 127),
(1276, 'Olmos', 127),
(1277, 'Pacora', 127),
(1278, 'Salas', 127),
(1279, 'San José', 127),
(1280, 'Tucume', 127),
(1281, 'Lima', 128),
(1282, 'Ancón', 128),
(1283, 'Ate', 128),
(1284, 'Barranco', 128),
(1285, 'Breña', 128),
(1286, 'Carabayllo', 128),
(1287, 'Chaclacayo', 128),
(1288, 'Chorrillos', 128),
(1289, 'Cieneguilla', 128),
(1290, 'Comas', 128),
(1291, 'El Agustino', 128),
(1292, 'Independencia', 128),
(1293, 'Jesús María', 128),
(1294, 'La Molina', 128),
(1295, 'La Victoria', 128),
(1296, 'Lince', 128),
(1297, 'Los Olivos', 128),
(1298, 'Lurigancho', 128),
(1299, 'Lurin', 128),
(1300, 'Magdalena del Mar', 128),
(1301, 'Pueblo Libre', 128),
(1302, 'Miraflores', 128),
(1303, 'Pachacamac', 128),
(1304, 'Pucusana', 128),
(1305, 'Puente Piedra', 128),
(1306, 'Punta Hermosa', 128),
(1307, 'Punta Negra', 128),
(1308, 'Rímac', 128),
(1309, 'San Bartolo', 128),
(1310, 'San Borja', 128),
(1311, 'San Isidro', 128),
(1312, 'San Juan de Lurigancho', 128),
(1313, 'San Juan de Miraflores', 128),
(1314, 'San Luis', 128),
(1315, 'San Martín de Porres', 128),
(1316, 'San Miguel', 128),
(1317, 'Santa Anita', 128),
(1318, 'Santa María del Mar', 128),
(1319, 'Santa Rosa', 128),
(1320, 'Santiago de Surco', 128),
(1321, 'Surquillo', 128),
(1322, 'Villa El Salvador', 128),
(1323, 'Villa María del Triunfo', 128),
(1324, 'Barranca', 129),
(1325, 'Paramonga', 129),
(1326, 'Pativilca', 129),
(1327, 'Supe', 129),
(1328, 'Supe Puerto', 129),
(1329, 'Cajatambo', 130),
(1330, 'Copa', 130),
(1331, 'Gorgor', 130),
(1332, 'Huancapon', 130),
(1333, 'Manas', 130),
(1334, 'Canta', 131),
(1335, 'Arahuay', 131),
(1336, 'Huamantanga', 131),
(1337, 'Huaros', 131),
(1338, 'Lachaqui', 131),
(1339, 'San Buenaventura', 131),
(1340, 'Santa Rosa de Quives', 131),
(1341, 'San Vicente de Cañete', 132),
(1342, 'Asia', 132),
(1343, 'Calango', 132),
(1344, 'Cerro Azul', 132),
(1345, 'Chilca', 132),
(1346, 'Coayllo', 132),
(1347, 'Imperial', 132),
(1348, 'Lunahuana', 132),
(1349, 'Mala', 132),
(1350, 'Nuevo Imperial', 132),
(1351, 'Pacaran', 132),
(1352, 'Quilmana', 132),
(1353, 'San Antonio', 132),
(1354, 'San Luis', 132),
(1355, 'Santa Cruz de Flores', 132),
(1356, 'Zúñiga', 132),
(1357, 'Huaral', 133),
(1358, 'Atavillos Alto', 133),
(1359, 'Atavillos Bajo', 133),
(1360, 'Aucallama', 133),
(1361, 'Chancay', 133),
(1362, 'Ihuari', 133),
(1363, 'Lampian', 133),
(1364, 'Pacaraos', 133),
(1365, 'San Miguel de Acos', 133),
(1366, 'Santa Cruz de Andamarca', 133),
(1367, 'Sumbilca', 133),
(1368, 'Veintisiete de Noviembre', 133),
(1369, 'Matucana', 134),
(1370, 'Antioquia', 134),
(1371, 'Callahuanca', 134),
(1372, 'Carampoma', 134),
(1373, 'Chicla', 134),
(1374, 'Cuenca', 134),
(1375, 'Huachupampa', 134),
(1376, 'Huanza', 134),
(1377, 'Huarochiri', 134),
(1378, 'Lahuaytambo', 134),
(1379, 'Langa', 134),
(1380, 'Laraos', 134),
(1381, 'Mariatana', 134),
(1382, 'Ricardo Palma', 134),
(1383, 'San Andrés de Tupicocha', 134),
(1384, 'San Antonio', 134),
(1385, 'San Bartolomé', 134),
(1386, 'San Damian', 134),
(1387, 'San Juan de Iris', 134),
(1388, 'San Juan de Tantaranche', 134),
(1389, 'San Lorenzo de Quinti', 134),
(1390, 'San Mateo', 134),
(1391, 'San Mateo de Otao', 134),
(1392, 'San Pedro de Casta', 134),
(1393, 'San Pedro de Huancayre', 134),
(1394, 'Sangallaya', 134),
(1395, 'Santa Cruz de Cocachacra', 134),
(1396, 'Santa Eulalia', 134),
(1397, 'Santiago de Anchucaya', 134),
(1398, 'Santiago de Tuna', 134),
(1399, 'Santo Domingo de Los Olleros', 134),
(1400, 'Surco', 134),
(1401, 'Huacho', 135),
(1402, 'Ambar', 135),
(1403, 'Caleta de Carquin', 135),
(1404, 'Checras', 135),
(1405, 'Hualmay', 135),
(1406, 'Huaura', 135),
(1407, 'Leoncio Prado', 135),
(1408, 'Paccho', 135),
(1409, 'Santa Leonor', 135),
(1410, 'Santa María', 135),
(1411, 'Sayan', 135),
(1412, 'Vegueta', 135),
(1413, 'Oyon', 136),
(1414, 'Andajes', 136),
(1415, 'Caujul', 136),
(1416, 'Cochamarca', 136),
(1417, 'Navan', 136),
(1418, 'Pachangara', 136),
(1419, 'Yauyos', 137),
(1420, 'Alis', 137),
(1421, 'Allauca', 137),
(1422, 'Ayaviri', 137),
(1423, 'Azángaro', 137),
(1424, 'Cacra', 137),
(1425, 'Carania', 137),
(1426, 'Catahuasi', 137),
(1427, 'Chocos', 137),
(1428, 'Cochas', 137),
(1429, 'Colonia', 137),
(1430, 'Hongos', 137),
(1431, 'Huampara', 137),
(1432, 'Huancaya', 137),
(1433, 'Huangascar', 137),
(1434, 'Huantan', 137),
(1435, 'Huañec', 137),
(1436, 'Laraos', 137),
(1437, 'Lincha', 137),
(1438, 'Madean', 137),
(1439, 'Miraflores', 137),
(1440, 'Omas', 137),
(1441, 'Putinza', 137),
(1442, 'Quinches', 137),
(1443, 'Quinocay', 137),
(1444, 'San Joaquín', 137),
(1445, 'San Pedro de Pilas', 137),
(1446, 'Tanta', 137),
(1447, 'Tauripampa', 137),
(1448, 'Tomas', 137),
(1449, 'Tupe', 137),
(1450, 'Viñac', 137),
(1451, 'Vitis', 137),
(1452, 'Iquitos', 138),
(1453, 'Alto Nanay', 138),
(1454, 'Fernando Lores', 138),
(1455, 'Indiana', 138),
(1456, 'Las Amazonas', 138),
(1457, 'Mazan', 138),
(1458, 'Napo', 138),
(1459, 'Punchana', 138),
(1460, 'Torres Causana', 138),
(1461, 'Belén', 138),
(1462, 'San Juan Bautista', 138),
(1463, 'Yurimaguas', 139),
(1464, 'Balsapuerto', 139),
(1465, 'Jeberos', 139),
(1466, 'Lagunas', 139),
(1467, 'Santa Cruz', 139),
(1468, 'Teniente Cesar López Rojas', 139),
(1469, 'Nauta', 140),
(1470, 'Parinari', 140),
(1471, 'Tigre', 140),
(1472, 'Trompeteros', 140),
(1473, 'Urarinas', 140),
(1474, 'Ramón Castilla', 141),
(1475, 'Pebas', 141),
(1476, 'Yavari', 141),
(1477, 'San Pablo', 141),
(1478, 'Requena', 142),
(1479, 'Alto Tapiche', 142),
(1480, 'Capelo', 142),
(1481, 'Emilio San Martín', 142),
(1482, 'Maquia', 142),
(1483, 'Puinahua', 142),
(1484, 'Saquena', 142),
(1485, 'Soplin', 142),
(1486, 'Tapiche', 142),
(1487, 'Jenaro Herrera', 142),
(1488, 'Yaquerana', 142),
(1489, 'Contamana', 143),
(1490, 'Inahuaya', 143),
(1491, 'Padre Márquez', 143),
(1492, 'Pampa Hermosa', 143),
(1493, 'Sarayacu', 143),
(1494, 'Vargas Guerra', 143),
(1495, 'Barranca', 144),
(1496, 'Cahuapanas', 144),
(1497, 'Manseriche', 144),
(1498, 'Morona', 144),
(1499, 'Pastaza', 144),
(1500, 'Andoas', 144),
(1501, 'Putumayo', 145),
(1502, 'Rosa Panduro', 145),
(1503, 'Teniente Manuel Clavero', 145),
(1504, 'Yaguas', 145),
(1505, 'Tambopata', 146),
(1506, 'Inambari', 146),
(1507, 'Las Piedras', 146),
(1508, 'Laberinto', 146),
(1509, 'Manu', 147),
(1510, 'Fitzcarrald', 147),
(1511, 'Madre de Dios', 147),
(1512, 'Huepetuhe', 147),
(1513, 'Iñapari', 148),
(1514, 'Iberia', 148),
(1515, 'Tahuamanu', 148),
(1516, 'Moquegua', 149),
(1517, 'Carumas', 149),
(1518, 'Cuchumbaya', 149),
(1519, 'Samegua', 149),
(1520, 'San Cristóbal', 149),
(1521, 'Torata', 149),
(1522, 'Omate', 150),
(1523, 'Chojata', 150),
(1524, 'Coalaque', 150),
(1525, 'Ichuña', 150),
(1526, 'La Capilla', 150),
(1527, 'Lloque', 150),
(1528, 'Matalaque', 150),
(1529, 'Puquina', 150),
(1530, 'Quinistaquillas', 150),
(1531, 'Ubinas', 150),
(1532, 'Yunga', 150),
(1533, 'Ilo', 151),
(1534, 'El Algarrobal', 151),
(1535, 'Pacocha', 151),
(1536, 'Chaupimarca', 152),
(1537, 'Huachon', 152),
(1538, 'Huariaca', 152),
(1539, 'Huayllay', 152),
(1540, 'Ninacaca', 152),
(1541, 'Pallanchacra', 152),
(1542, 'Paucartambo', 152),
(1543, 'San Francisco de Asís de Yarusyacan', 152),
(1544, 'Simon Bolívar', 152),
(1545, 'Ticlacayan', 152),
(1546, 'Tinyahuarco', 152),
(1547, 'Vicco', 152),
(1548, 'Yanacancha', 152),
(1549, 'Yanahuanca', 153),
(1550, 'Chacayan', 153),
(1551, 'Goyllarisquizga', 153),
(1552, 'Paucar', 153),
(1553, 'San Pedro de Pillao', 153),
(1554, 'Santa Ana de Tusi', 153),
(1555, 'Tapuc', 153),
(1556, 'Vilcabamba', 153),
(1557, 'Oxapampa', 154),
(1558, 'Chontabamba', 154),
(1559, 'Huancabamba', 154),
(1560, 'Palcazu', 154),
(1561, 'Pozuzo', 154),
(1562, 'Puerto Bermúdez', 154),
(1563, 'Villa Rica', 154),
(1564, 'Constitución', 154),
(1565, 'Piura', 155),
(1566, 'Castilla', 155),
(1567, 'Catacaos', 155),
(1568, 'Cura Mori', 155),
(1569, 'El Tallan', 155),
(1570, 'La Arena', 155),
(1571, 'La Unión', 155),
(1572, 'Las Lomas', 155),
(1573, 'Tambo Grande', 155),
(1574, 'Veintiseis de Octubre', 155),
(1575, 'Ayabaca', 156),
(1576, 'Frias', 156),
(1577, 'Jilili', 156),
(1578, 'Lagunas', 156),
(1579, 'Montero', 156),
(1580, 'Pacaipampa', 156),
(1581, 'Paimas', 156),
(1582, 'Sapillica', 156),
(1583, 'Sicchez', 156),
(1584, 'Suyo', 156),
(1585, 'Huancabamba', 157),
(1586, 'Canchaque', 157),
(1587, 'El Carmen de la Frontera', 157),
(1588, 'Huarmaca', 157),
(1589, 'Lalaquiz', 157),
(1590, 'San Miguel de El Faique', 157),
(1591, 'Sondor', 157),
(1592, 'Sondorillo', 157),
(1593, 'Chulucanas', 158),
(1594, 'Buenos Aires', 158),
(1595, 'Chalaco', 158),
(1596, 'La Matanza', 158),
(1597, 'Morropon', 158),
(1598, 'Salitral', 158),
(1599, 'San Juan de Bigote', 158),
(1600, 'Santa Catalina de Mossa', 158),
(1601, 'Santo Domingo', 158),
(1602, 'Yamango', 158),
(1603, 'Paita', 159),
(1604, 'Amotape', 159),
(1605, 'Arenal', 159),
(1606, 'Colan', 159),
(1607, 'La Huaca', 159),
(1608, 'Tamarindo', 159),
(1609, 'Vichayal', 159),
(1610, 'Sullana', 160),
(1611, 'Bellavista', 160),
(1612, 'Ignacio Escudero', 160),
(1613, 'Lancones', 160),
(1614, 'Marcavelica', 160),
(1615, 'Miguel Checa', 160),
(1616, 'Querecotillo', 160),
(1617, 'Salitral', 160),
(1618, 'Pariñas', 161),
(1619, 'El Alto', 161),
(1620, 'La Brea', 161),
(1621, 'Lobitos', 161),
(1622, 'Los Organos', 161),
(1623, 'Mancora', 161),
(1624, 'Sechura', 162),
(1625, 'Bellavista de la Unión', 162),
(1626, 'Bernal', 162),
(1627, 'Cristo Nos Valga', 162),
(1628, 'Vice', 162),
(1629, 'Rinconada Llicuar', 162),
(1630, 'Puno', 163),
(1631, 'Acora', 163),
(1632, 'Amantani', 163),
(1633, 'Atuncolla', 163),
(1634, 'Capachica', 163),
(1635, 'Chucuito', 163),
(1636, 'Coata', 163),
(1637, 'Huata', 163),
(1638, 'Mañazo', 163),
(1639, 'Paucarcolla', 163),
(1640, 'Pichacani', 163),
(1641, 'Plateria', 163),
(1642, 'San Antonio', 163),
(1643, 'Tiquillaca', 163),
(1644, 'Vilque', 163),
(1645, 'Azángaro', 164),
(1646, 'Achaya', 164),
(1647, 'Arapa', 164),
(1648, 'Asillo', 164),
(1649, 'Caminaca', 164),
(1650, 'Chupa', 164),
(1651, 'José Domingo Choquehuanca', 164),
(1652, 'Muñani', 164),
(1653, 'Potoni', 164),
(1654, 'Saman', 164),
(1655, 'San Anton', 164),
(1656, 'San José', 164),
(1657, 'San Juan de Salinas', 164),
(1658, 'Santiago de Pupuja', 164),
(1659, 'Tirapata', 164),
(1660, 'Macusani', 165),
(1661, 'Ajoyani', 165),
(1662, 'Ayapata', 165),
(1663, 'Coasa', 165),
(1664, 'Corani', 165),
(1665, 'Crucero', 165),
(1666, 'Ituata', 165),
(1667, 'Ollachea', 165),
(1668, 'San Gaban', 165),
(1669, 'Usicayos', 165),
(1670, 'Juli', 166),
(1671, 'Desaguadero', 166),
(1672, 'Huacullani', 166),
(1673, 'Kelluyo', 166),
(1674, 'Pisacoma', 166),
(1675, 'Pomata', 166),
(1676, 'Zepita', 166),
(1677, 'Ilave', 167),
(1678, 'Capazo', 167),
(1679, 'Pilcuyo', 167),
(1680, 'Santa Rosa', 167),
(1681, 'Conduriri', 167),
(1682, 'Huancane', 168),
(1683, 'Cojata', 168),
(1684, 'Huatasani', 168),
(1685, 'Inchupalla', 168),
(1686, 'Pusi', 168),
(1687, 'Rosaspata', 168),
(1688, 'Taraco', 168),
(1689, 'Vilque Chico', 168),
(1690, 'Lampa', 169),
(1691, 'Cabanilla', 169),
(1692, 'Calapuja', 169),
(1693, 'Nicasio', 169),
(1694, 'Ocuviri', 169),
(1695, 'Palca', 169),
(1696, 'Paratia', 169),
(1697, 'Pucara', 169),
(1698, 'Santa Lucia', 169),
(1699, 'Vilavila', 169),
(1700, 'Ayaviri', 170),
(1701, 'Antauta', 170),
(1702, 'Cupi', 170),
(1703, 'Llalli', 170),
(1704, 'Macari', 170),
(1705, 'Nuñoa', 170),
(1706, 'Orurillo', 170),
(1707, 'Santa Rosa', 170),
(1708, 'Umachiri', 170),
(1709, 'Moho', 171),
(1710, 'Conima', 171),
(1711, 'Huayrapata', 171),
(1712, 'Tilali', 171),
(1713, 'Putina', 172),
(1714, 'Ananea', 172),
(1715, 'Pedro Vilca Apaza', 172),
(1716, 'Quilcapuncu', 172),
(1717, 'Sina', 172),
(1718, 'Juliaca', 173),
(1719, 'Cabana', 173),
(1720, 'Cabanillas', 173),
(1721, 'Caracoto', 173),
(1722, 'San Miguel', 173),
(1723, 'Sandia', 174),
(1724, 'Cuyocuyo', 174),
(1725, 'Limbani', 174),
(1726, 'Patambuco', 174),
(1727, 'Phara', 174),
(1728, 'Quiaca', 174),
(1729, 'San Juan del Oro', 174),
(1730, 'Yanahuaya', 174),
(1731, 'Alto Inambari', 174),
(1732, 'San Pedro de Putina Punco', 174),
(1733, 'Yunguyo', 175),
(1734, 'Anapia', 175),
(1735, 'Copani', 175),
(1736, 'Cuturapi', 175),
(1737, 'Ollaraya', 175),
(1738, 'Tinicachi', 175),
(1739, 'Unicachi', 175),
(1740, 'Moyobamba', 176),
(1741, 'Calzada', 176),
(1742, 'Habana', 176),
(1743, 'Jepelacio', 176),
(1744, 'Soritor', 176),
(1745, 'Yantalo', 176),
(1746, 'Bellavista', 177),
(1747, 'Alto Biavo', 177),
(1748, 'Bajo Biavo', 177),
(1749, 'Huallaga', 177),
(1750, 'San Pablo', 177),
(1751, 'San Rafael', 177),
(1752, 'San José de Sisa', 178),
(1753, 'Agua Blanca', 178),
(1754, 'San Martín', 178),
(1755, 'Santa Rosa', 178),
(1756, 'Shatoja', 178),
(1757, 'Saposoa', 179),
(1758, 'Alto Saposoa', 179),
(1759, 'El Eslabón', 179),
(1760, 'Piscoyacu', 179),
(1761, 'Sacanche', 179),
(1762, 'Tingo de Saposoa', 179),
(1763, 'Lamas', 180),
(1764, 'Alonso de Alvarado', 180),
(1765, 'Barranquita', 180),
(1766, 'Caynarachi', 180),
(1767, 'Cuñumbuqui', 180),
(1768, 'Pinto Recodo', 180),
(1769, 'Rumisapa', 180),
(1770, 'San Roque de Cumbaza', 180),
(1771, 'Shanao', 180),
(1772, 'Tabalosos', 180),
(1773, 'Zapatero', 180),
(1774, 'Juanjuí', 181),
(1775, 'Campanilla', 181),
(1776, 'Huicungo', 181),
(1777, 'Pachiza', 181),
(1778, 'Pajarillo', 181),
(1779, 'Picota', 182),
(1780, 'Buenos Aires', 182),
(1781, 'Caspisapa', 182),
(1782, 'Pilluana', 182),
(1783, 'Pucacaca', 182),
(1784, 'San Cristóbal', 182),
(1785, 'San Hilarión', 182),
(1786, 'Shamboyacu', 182),
(1787, 'Tingo de Ponasa', 182),
(1788, 'Tres Unidos', 182),
(1789, 'Rioja', 183),
(1790, 'Awajun', 183),
(1791, 'Elías Soplin Vargas', 183),
(1792, 'Nueva Cajamarca', 183),
(1793, 'Pardo Miguel', 183),
(1794, 'Posic', 183),
(1795, 'San Fernando', 183),
(1796, 'Yorongos', 183),
(1797, 'Yuracyacu', 183),
(1798, 'Tarapoto', 184),
(1799, 'Alberto Leveau', 184),
(1800, 'Cacatachi', 184),
(1801, 'Chazuta', 184),
(1802, 'Chipurana', 184),
(1803, 'El Porvenir', 184),
(1804, 'Huimbayoc', 184),
(1805, 'Juan Guerra', 184),
(1806, 'La Banda de Shilcayo', 184),
(1807, 'Morales', 184),
(1808, 'Papaplaya', 184),
(1809, 'San Antonio', 184),
(1810, 'Sauce', 184),
(1811, 'Shapaja', 184),
(1812, 'Tocache', 185),
(1813, 'Nuevo Progreso', 185),
(1814, 'Polvora', 185),
(1815, 'Shunte', 185),
(1816, 'Uchiza', 185),
(1817, 'Tacna', 186),
(1818, 'Alto de la Alianza', 186),
(1819, 'Calana', 186),
(1820, 'Ciudad Nueva', 186),
(1821, 'Inclan', 186),
(1822, 'Pachia', 186),
(1823, 'Palca', 186),
(1824, 'Pocollay', 186),
(1825, 'Sama', 186),
(1826, 'Coronel Gregorio Albarracín Lanchipa', 186),
(1827, 'La Yarada los Palos', 186),
(1828, 'Candarave', 187),
(1829, 'Cairani', 187),
(1830, 'Camilaca', 187),
(1831, 'Curibaya', 187),
(1832, 'Huanuara', 187),
(1833, 'Quilahuani', 187),
(1834, 'Locumba', 188),
(1835, 'Ilabaya', 188),
(1836, 'Ite', 188),
(1837, 'Tarata', 189),
(1838, 'Héroes Albarracín', 189),
(1839, 'Estique', 189),
(1840, 'Estique-Pampa', 189),
(1841, 'Sitajara', 189),
(1842, 'Susapaya', 189),
(1843, 'Tarucachi', 189),
(1844, 'Ticaco', 189),
(1845, 'Tumbes', 190),
(1846, 'Corrales', 190),
(1847, 'La Cruz', 190),
(1848, 'Pampas de Hospital', 190),
(1849, 'San Jacinto', 190),
(1850, 'San Juan de la Virgen', 190),
(1851, 'Zorritos', 191),
(1852, 'Casitas', 191),
(1853, 'Canoas de Punta Sal', 191),
(1854, 'Zarumilla', 192),
(1855, 'Aguas Verdes', 192),
(1856, 'Matapalo', 192),
(1857, 'Papayal', 192),
(1858, 'Calleria', 193),
(1859, 'Campoverde', 193),
(1860, 'Iparia', 193),
(1861, 'Masisea', 193),
(1862, 'Yarinacocha', 193),
(1863, 'Nueva Requena', 193),
(1864, 'Manantay', 193),
(1865, 'Raymondi', 194),
(1866, 'Sepahua', 194),
(1867, 'Tahuania', 194),
(1868, 'Yurua', 194),
(1869, 'Padre Abad', 195),
(1870, 'Irazola', 195),
(1871, 'Curimana', 195),
(1872, 'Neshuya', 195),
(1873, 'Alexander Von Humboldt', 195),
(1874, 'Purus', 196);

-- Table: Empresa
CREATE TABLE Empresa (
    Codigo tinyint  NOT NULL IDENTITY(1, 1),
    RUC varchar(11)  NOT NULL,
    Nombre varchar(200)  NOT NULL,
    Direccion varchar(200)  NOT NULL,
    Distrito smallint  NOT NULL,
    Telefono varchar(20)  NOT NULL,
    Correo varchar(200)  NULL,
    Web varchar(200)  NULL,
    CONSTRAINT Empresa_pk PRIMARY KEY  (Codigo)
);

insert into Empresa(RUC, Nombre, Direccion, Distrito, Telefono)
values
('20568504730','Alfa y Taurus','Jr Moquehuá N°139',1036,'964245227');

-- Table: EstadoPago
CREATE TABLE EstadoPago (
    Codigo tinyint  NOT NULL IDENTITY(1, 1),
    Detalle varchar(50)  NOT NULL,
    CONSTRAINT EstadoPago_pk PRIMARY KEY  (Codigo)
);

insert into EstadoPago
values 
('no pagado'),
('pagado o cancelado'),
('pago parcial');

-- Table: Estudiante
CREATE TABLE Estudiante (
    Identificacion_Codigo tinyint  NOT NULL,
    NDocumeto varchar(20)  NOT NULL,
    ApellidosNombres varchar(200)  NOT NULL,
    PadreAp_NDocumento varchar(20)  NOT NULL,
    Padre_NDocumento varchar(20)  NULL,
    ColegioProcedencia varchar(150)  NOT NULL,
    Peso float  NOT NULL,
    Talla smallint  NOT NULL,
    CondicionSalud varchar(200)  NULL,
    FechaNacimiento date  NOT NULL,
    NumeroCelular varchar(50)  NULL,
    CONSTRAINT Estudiante_pk PRIMARY KEY  (NDocumeto)
);

-- Table: FechaPago
SET DATEFORMAT MDY -- Formato americano;

CREATE TABLE FechaPago (
    Codigo tinyint  NOT NULL IDENTITY(1, 1),
    FechaVenc date  NOT NULL,
    CONSTRAINT FechaPago_pk PRIMARY KEY  (Codigo)
);

insert into FechaPago
values
('03/31/2020'), -- vencimineto del 1 mes
('04/30/2020'), -- vencimineto del 2 mes
('05/31/2020'), -- vencimineto del 3 mes
('06/30/2020'), -- vencimineto del 4 mes
('07/31/2020'), -- vencimineto del 5 mes
('08/31/2020'), -- vencimineto del 6 mes
('09/30/2020'), -- vencimineto del 7 mes
('10/31/2020'), -- vencimineto del 8 mes
('11/30/2020'), -- vencimineto del 9 mes
('12/31/2020'), -- vencimineto del 10 mes
('03/31/2021'),
('04/30/2021'),
('05/31/2021'),
('06/30/2021'),
('07/31/2021'),
('08/31/2021'),
('09/30/2021'),
('10/31/2021'),
('11/30/2021'),
('12/31/2021');

-- Table: GradoAcademico
CREATE TABLE GradoAcademico (
    Grado char(1)  NOT NULL,
    Seccion char(1)  NOT NULL,
    Capacidad smallint  NOT NULL DEFAULT 50,
    CONSTRAINT GradoAcademico_pk PRIMARY KEY  (Grado,Seccion)
);

insert into GradoAcademico
values
('1','A',50),
('1','B',50),
('1','C',50),
('2','A',50),
('2','B',50),
('2','C',50),
('3','A',50),
('3','B',50),
('3','C',50),
('4','A',50),
('4','B',50),
('4','C',50),
('5','A',50),
('5','B',50),
('5','C',50);

-- Table: Identificacion
CREATE TABLE Identificacion (
    Codigo tinyint  NOT NULL IDENTITY(1, 1),
    Nombre varchar(100)  NOT NULL,
    CONSTRAINT Identificacion_pk PRIMARY KEY  (Codigo)
);

insert into Identificacion
values
('LIBRETA ELECTORAL O DNI'),
('CARNET DE EXTRANJERIA'),
('PASAPORTE');

-- Table: Inasistencia
CREATE TABLE Inasistencia (
    FechaIncidencia date  NOT NULL,
    Estudiante_NDocumeto varchar(20)  NOT NULL,
    TipoInsidencia_Codigo tinyint  NOT NULL,
    CONSTRAINT Inasistencia_pk PRIMARY KEY  (FechaIncidencia,Estudiante_NDocumeto,TipoInsidencia_Codigo)
);

-- Table: Matricula
CREATE TABLE Matricula (
    PeriodoAcademico_Year char(4)  NOT NULL,
    Estudiante_NDocumeto varchar(20)  NOT NULL,
    Usuario_NDocumento varchar(15)  NOT NULL,
    VerificacionMatricula bit  NOT NULL DEFAULT 0,
    GradoAcademico_Grado char(1)  NOT NULL,
    GradoAcademico_Seccion char(1)  NOT NULL,
    FechaRegistro datetime  NOT NULL,
    CONSTRAINT Matricula_pk PRIMARY KEY  (PeriodoAcademico_Year,Estudiante_NDocumeto)
);

if exists (select * from ::fn_listextendedproperty('MS_Description', 'schema', 'dbo', 'TABLE', 'Matricula', null,null))
BEGIN
    EXEC sp_dropextendedproperty
        @name = N'MS_Description',
        @level0type = N'SCHEMA',
    	@level0name = 'dbo',
    	@level1type = N'TABLE',
        @level1name = 'Matricula';
END; 

EXEC sp_addextendedproperty
    @name  = N'MS_Description',
    @value = N'Contiene datos del estudiante y grado academico
',
    @level0type = N'SCHEMA',
    @level0name = 'dbo',
    @level1type = N'TABLE',
    @level1name = 'Matricula';

-- Table: Matricula_DiversoPago
CREATE TABLE Matricula_DiversoPago (
    Estudiante_NDocumeto varchar(20)  NOT NULL,
    Monto_Codigo tinyint  NOT NULL,
    FechaPago_Codigo tinyint  NOT NULL,
    PeriodoAcademico_Year char(4)  NOT NULL,
    Prorroga tinyint  NOT NULL,
    EstadoPago_Codigo tinyint  NOT NULL DEFAULT 1,
    CONSTRAINT Matricula_DiversoPago_pk PRIMARY KEY  (Estudiante_NDocumeto,Monto_Codigo,FechaPago_Codigo)
);

if exists (select * from ::fn_listextendedproperty('MS_Description', 'schema', 'dbo', 'TABLE', 'Matricula_DiversoPago', null,null))
BEGIN
    EXEC sp_dropextendedproperty
        @name = N'MS_Description',
        @level0type = N'SCHEMA',
    	@level0name = 'dbo',
    	@level1type = N'TABLE',
        @level1name = 'Matricula_DiversoPago';
END; 

EXEC sp_addextendedproperty
    @name  = N'MS_Description',
    @value = N'Esta tabla contiene los detalles de los pagos diversos por estudiante según el grado de estudio',
    @level0type = N'SCHEMA',
    @level0name = 'dbo',
    @level1type = N'TABLE',
    @level1name = 'Matricula_DiversoPago';

-- Table: Monto
CREATE TABLE Monto (
    Codigo tinyint  NOT NULL IDENTITY(1, 1),
    Descripcion varchar(100)  NOT NULL,
    Monto smallmoney  NOT NULL,
    CONSTRAINT Monto_pk PRIMARY KEY  (Codigo)
);

insert into Monto
values
('Matricula',120),
('Pension mensual 1',160),
('Pension mensual 5',180),
('Material Academico',220),
('Reuniones-Multa',30),
('Pension mensual 2',160),
('Pension mensual 3',160),
('Pension mensual 4',160);

-- Table: MultiplePago
CREATE TABLE MultiplePago (
    Estudiante_NDocumeto varchar(20)  NOT NULL,
    Monto_Codigo tinyint  NOT NULL,
    FechaPago_Codigo tinyint  NOT NULL,
    Pago_Numero bigint  NOT NULL,
    MontoPagado smallmoney  NOT NULL,
    CONSTRAINT MultiplePago_pk PRIMARY KEY  (Estudiante_NDocumeto,Monto_Codigo,FechaPago_Codigo,Pago_Numero)
);

if exists (select * from ::fn_listextendedproperty('MS_Description', 'schema', 'dbo', 'TABLE', 'MultiplePago', null,null))
BEGIN
    EXEC sp_dropextendedproperty
        @name = N'MS_Description',
        @level0type = N'SCHEMA',
    	@level0name = 'dbo',
    	@level1type = N'TABLE',
        @level1name = 'MultiplePago';
END; 

EXEC sp_addextendedproperty
    @name  = N'MS_Description',
    @value = N'Esta tabla contiene los pagos que se REALIZAN en función a pagos diversos',
    @level0type = N'SCHEMA',
    @level0name = 'dbo',
    @level1type = N'TABLE',
    @level1name = 'MultiplePago';

-- Table: Padre
CREATE TABLE Padre (
    Identificacion_Codigo tinyint  NOT NULL,
    NDocumento varchar(20)  NOT NULL,
    NombreCompleto varchar(200)  NOT NULL,
    Direccion varchar(200)  NOT NULL,
    Distrito smallint  NOT NULL,
    NumeroCelular varchar(50)  NOT NULL,
    Trabajo varchar(150)  NOT NULL,
    Correo varchar(150)  NULL,
    CONSTRAINT Padre_pk PRIMARY KEY  (NDocumento)
);

-- Table: Pago
CREATE TABLE Pago (
    Numero bigint  NOT NULL IDENTITY(-9223372036854775808, 1),
    Monto smallmoney  NOT NULL,
    Fecha datetime  NOT NULL,
    CONSTRAINT Pago_pk PRIMARY KEY  (Numero)
);

-- Table: PeriodoAcademico
CREATE TABLE PeriodoAcademico (
    Year char(4)  NOT NULL,
    FechaInicio date  NOT NULL,
    FechaFinal date  NOT NULL,
    CONSTRAINT PeriodoAcademico_pk PRIMARY KEY  (Year)
);

SET DATEFORMAT MDY -- Formato americano
insert into PeriodoAcademico
values
('2020','03/02/2020','12/18/2020'),
('2021','03/01/2021','12/10/2021');

-- Table: Provincia
CREATE TABLE Provincia (
    IdProvincia tinyint  NOT NULL,
    Nombre varchar(50)  NOT NULL,
    IdDepartamento tinyint  NOT NULL,
    CONSTRAINT Provincia_pk PRIMARY KEY  (IdProvincia)
);

insert into Provincia
values
(1, 'Chachapoyas', 1),
(2, 'Bagua', 1),
(3, 'Bongará', 1),
(4, 'Condorcanqui', 1),
(5, 'Luya', 1),
(6, 'Rodríguez de Mendoza', 1),
(7, 'Utcubamba', 1),
(8, 'Huaraz', 2),
(9, 'Aija', 2),
(10, 'Antonio Raymondi', 2),
(11, 'Asunción', 2),
(12, 'Bolognesi', 2),
(13, 'Carhuaz', 2),
(14, 'Carlos Fermín Fitzcarrald', 2),
(15, 'Casma', 2),
(16, 'Corongo', 2),
(17, 'Huari', 2),
(18, 'Huarmey', 2),
(19, 'Huaylas', 2),
(20, 'Mariscal Luzuriaga', 2),
(21, 'Ocros', 2),
(22, 'Pallasca', 2),
(23, 'Pomabamba', 2),
(24, 'Recuay', 2),
(25, 'Santa', 2),
(26, 'Sihuas', 2),
(27, 'Yungay', 2),
(28, 'Abancay', 3),
(29, 'Andahuaylas', 3),
(30, 'Antabamba', 3),
(31, 'Aymaraes', 3),
(32, 'Cotabambas', 3),
(33, 'Chincheros', 3),
(34, 'Grau', 3),
(35, 'Arequipa', 4),
(36, 'Camaná', 4),
(37, 'Caravelí', 4),
(38, 'Castilla', 4),
(39, 'Caylloma', 4),
(40, 'Condesuyos', 4),
(41, 'Islay', 4),
(42, 'La Uniòn', 4),
(43, 'Huamanga', 5),
(44, 'Cangallo', 5),
(45, 'Huanca Sancos', 5),
(46, 'Huanta', 5),
(47, 'La Mar', 5),
(48, 'Lucanas', 5),
(49, 'Parinacochas', 5),
(50, 'Pàucar del Sara Sara', 5),
(51, 'Sucre', 5),
(52, 'Víctor Fajardo', 5),
(53, 'Vilcas Huamán', 5),
(54, 'Cajamarca', 6),
(55, 'Cajabamba', 6),
(56, 'Celendín', 6),
(57, 'Chota', 6),
(58, 'Contumazá', 6),
(59, 'Cutervo', 6),
(60, 'Hualgayoc', 6),
(61, 'Jaén', 6),
(62, 'San Ignacio', 6),
(63, 'San Marcos', 6),
(64, 'San Miguel', 6),
(65, 'San Pablo', 6),
(66, 'Santa Cruz', 6),
(67, 'Prov. Const. del Callao', 7),
(68, 'Cusco', 8),
(69, 'Acomayo', 8),
(70, 'Anta', 8),
(71, 'Calca', 8),
(72, 'Canas', 8),
(73, 'Canchis', 8),
(74, 'Chumbivilcas', 8),
(75, 'Espinar', 8),
(76, 'La Convención', 8),
(77, 'Paruro', 8),
(78, 'Paucartambo', 8),
(79, 'Quispicanchi', 8),
(80, 'Urubamba', 8),
(81, 'Huancavelica', 9),
(82, 'Acobamba', 9),
(83, 'Angaraes', 9),
(84, 'Castrovirreyna', 9),
(85, 'Churcampa', 9),
(86, 'Huaytará', 9),
(87, 'Tayacaja', 9),
(88, 'Huánuco', 10),
(89, 'Ambo', 10),
(90, 'Dos de Mayo', 10),
(91, 'Huacaybamba', 10),
(92, 'Huamalíes', 10),
(93, 'Leoncio Prado', 10),
(94, 'Marañón', 10),
(95, 'Pachitea', 10),
(96, 'Puerto Inca', 10),
(97, 'Lauricocha', 10),
(98, 'Yarowilca ', 10),
(99, 'Ica ', 11),
(100, 'Chincha ', 11),
(101, 'Nasca ', 11),
(102, 'Palpa ', 11),
(103, 'Pisco ', 11),
(104, 'Huancayo ', 12),
(105, 'Concepción ', 12),
(106, 'Chanchamayo ', 12),
(107, 'Jauja ', 12),
(108, 'Junín ', 12),
(109, 'Satipo ', 12),
(110, 'Tarma ', 12),
(111, 'Yauli ', 12),
(112, 'Chupaca ', 12),
(113, 'Trujillo ', 13),
(114, 'Ascope ', 13),
(115, 'Bolívar ', 13),
(116, 'Chepén ', 13),
(117, 'Julcán ', 13),
(118, 'Otuzco ', 13),
(119, 'Pacasmayo ', 13),
(120, 'Pataz ', 13),
(121, 'Sánchez Carrión ', 13),
(122, 'Santiago de Chuco ', 13),
(123, 'Gran Chimú ', 13),
(124, 'Virú ', 13),
(125, 'Chiclayo ', 14),
(126, 'Ferreñafe ', 14),
(127, 'Lambayeque ', 14),
(128, 'Lima ', 15),
(129, 'Barranca ', 15),
(130, 'Cajatambo ', 15),
(131, 'Canta ', 15),
(132, 'Cañete ', 15),
(133, 'Huaral ', 15),
(134, 'Huarochirí ', 15),
(135, 'Huaura ', 15),
(136, 'Oyón ', 15),
(137, 'Yauyos ', 15),
(138, 'Maynas ', 16),
(139, 'Alto Amazonas ', 16),
(140, 'Loreto ', 16),
(141, 'Mariscal Ramón Castilla ', 16),
(142, 'Requena ', 16),
(143, 'Ucayali ', 16),
(144, 'Datem del Marañón ', 16),
(145, 'Putumayo', 16),
(146, 'Tambopata ', 17),
(147, 'Manu ', 17),
(148, 'Tahuamanu ', 17),
(149, 'Mariscal Nieto ', 18),
(150, 'General Sánchez Cerro ', 18),
(151, 'Ilo ', 18),
(152, 'Pasco ', 19),
(153, 'Daniel Alcides Carrión ', 19),
(154, 'Oxapampa ', 19),
(155, 'Piura ', 20),
(156, 'Ayabaca ', 20),
(157, 'Huancabamba ', 20),
(158, 'Morropón ', 20),
(159, 'Paita ', 20),
(160, 'Sullana ', 20),
(161, 'Talara ', 20),
(162, 'Sechura ', 20),
(163, 'Puno ', 21),
(164, 'Azángaro ', 21),
(165, 'Carabaya ', 21),
(166, 'Chucuito ', 21),
(167, 'El Collao ', 21),
(168, 'Huancané ', 21),
(169, 'Lampa ', 21),
(170, 'Melgar ', 21),
(171, 'Moho ', 21),
(172, 'San Antonio de Putina ', 21),
(173, 'San Román ', 21),
(174, 'Sandia ', 21),
(175, 'Yunguyo ', 21),
(176, 'Moyobamba ', 22),
(177, 'Bellavista ', 22),
(178, 'El Dorado ', 22),
(179, 'Huallaga ', 22),
(180, 'Lamas ', 22),
(181, 'Mariscal Cáceres ', 22),
(182, 'Picota ', 22),
(183, 'Rioja ', 22),
(184, 'San Martín ', 22),
(185, 'Tocache ', 22),
(186, 'Tacna ', 23),
(187, 'Candarave ', 23),
(188, 'Jorge Basadre ', 23),
(189, 'Tarata ', 23),
(190, 'Tumbes ', 24),
(191, 'Contralmirante Villar ', 24),
(192, 'Zarumilla ', 24),
(193, 'Coronel Portillo ', 25),
(194, 'Atalaya ', 25),
(195, 'Padre Abad ', 25),
(196, 'Purús', 25);

-- Table: TipoInsidencia
CREATE TABLE TipoInsidencia (
    Codigo tinyint  NOT NULL IDENTITY(1, 1),
    Descripcion varchar(100)  NOT NULL,
    CONSTRAINT TipoInsidencia_pk PRIMARY KEY  (Codigo)
);

insert into TipoInsidencia
values
('FALTA'),
('FALTA A REUNIONES');

-- Table: Usuario
CREATE TABLE Usuario (
    Identificacion_Codigo tinyint  NOT NULL,
    NDocumento varchar(15)  NOT NULL,
    username varchar(30)  NOT NULL,
    password varchar(120)  NOT NULL,
    Nombres varchar(80)  NOT NULL,
    Apellidos varchar(100)  NOT NULL,
    Direccion varchar(200)  NOT NULL,
    Distrito smallint  NOT NULL,
    Correo varchar(150)  NOT NULL,
    Cargo_CodCargo tinyint  NOT NULL,
    Empresa_Codigo tinyint  NOT NULL,
    CONSTRAINT Usuario_pk PRIMARY KEY  (NDocumento)
);

insert into Usuario
values
(1,'00000000','brian','123','BRIAN R.','HUAMÁM BALDEÓN','Los Fresnos',1045,'brianrhb15@gmail.com',1,1);

-- foreign keys
-- Reference: Distrito_Provincia (table: Distrito)
ALTER TABLE Distrito ADD CONSTRAINT Distrito_Provincia
    FOREIGN KEY (IdProvincia)
    REFERENCES Provincia (IdProvincia);

-- Reference: Empresa_Distrito (table: Empresa)
ALTER TABLE Empresa ADD CONSTRAINT Empresa_Distrito
    FOREIGN KEY (Distrito)
    REFERENCES Distrito (IdDistrito);

-- Reference: Estudiante_Identificacion (table: Estudiante)
ALTER TABLE Estudiante ADD CONSTRAINT Estudiante_Identificacion
    FOREIGN KEY (Identificacion_Codigo)
    REFERENCES Identificacion (Codigo);

-- Reference: Estudiante_Padre (table: Estudiante)
ALTER TABLE Estudiante ADD CONSTRAINT Estudiante_Padre
    FOREIGN KEY (Padre_NDocumento)
    REFERENCES Padre (NDocumento);

-- Reference: Estudiante_Padre_Ap (table: Estudiante)
ALTER TABLE Estudiante ADD CONSTRAINT Estudiante_Padre_Ap
    FOREIGN KEY (PadreAp_NDocumento)
    REFERENCES Padre (NDocumento);

-- Reference: Inasistencia_TipoInsidencia (table: Inasistencia)
ALTER TABLE Inasistencia ADD CONSTRAINT Inasistencia_TipoInsidencia
    FOREIGN KEY (TipoInsidencia_Codigo)
    REFERENCES TipoInsidencia (Codigo);

-- Reference: Inasistencias_Estudiante (table: Inasistencia)
ALTER TABLE Inasistencia ADD CONSTRAINT Inasistencias_Estudiante
    FOREIGN KEY (Estudiante_NDocumeto)
    REFERENCES Estudiante (NDocumeto);

-- Reference: Matricula_Estudiante (table: Matricula)
ALTER TABLE Matricula ADD CONSTRAINT Matricula_Estudiante
    FOREIGN KEY (Estudiante_NDocumeto)
    REFERENCES Estudiante (NDocumeto);

-- Reference: Matricula_GradoAcademico (table: Matricula)
ALTER TABLE Matricula ADD CONSTRAINT Matricula_GradoAcademico
    FOREIGN KEY (GradoAcademico_Grado,GradoAcademico_Seccion)
    REFERENCES GradoAcademico (Grado,Seccion);

-- Reference: Matricula_Monto_Pago_Matricula_Monto (table: MultiplePago)
ALTER TABLE MultiplePago ADD CONSTRAINT Matricula_Monto_Pago_Matricula_Monto
    FOREIGN KEY (Estudiante_NDocumeto,Monto_Codigo,FechaPago_Codigo)
    REFERENCES Matricula_DiversoPago (Estudiante_NDocumeto,Monto_Codigo,FechaPago_Codigo);

-- Reference: Matricula_Monto_Pago_Pago (table: MultiplePago)
ALTER TABLE MultiplePago ADD CONSTRAINT Matricula_Monto_Pago_Pago
    FOREIGN KEY (Pago_Numero)
    REFERENCES Pago (Numero);

-- Reference: Matricula_Pago_EstadoPago (table: Matricula_DiversoPago)
ALTER TABLE Matricula_DiversoPago ADD CONSTRAINT Matricula_Pago_EstadoPago
    FOREIGN KEY (EstadoPago_Codigo)
    REFERENCES EstadoPago (Codigo);

-- Reference: Matricula_Pago_FechaPago (table: Matricula_DiversoPago)
ALTER TABLE Matricula_DiversoPago ADD CONSTRAINT Matricula_Pago_FechaPago
    FOREIGN KEY (FechaPago_Codigo)
    REFERENCES FechaPago (Codigo);

-- Reference: Matricula_Pago_Matricula (table: Matricula_DiversoPago)
ALTER TABLE Matricula_DiversoPago ADD CONSTRAINT Matricula_Pago_Matricula
    FOREIGN KEY (PeriodoAcademico_Year,Estudiante_NDocumeto)
    REFERENCES Matricula (PeriodoAcademico_Year,Estudiante_NDocumeto);

-- Reference: Matricula_Pago_Monto (table: Matricula_DiversoPago)
ALTER TABLE Matricula_DiversoPago ADD CONSTRAINT Matricula_Pago_Monto
    FOREIGN KEY (Monto_Codigo)
    REFERENCES Monto (Codigo);

-- Reference: Matricula_PeriodoAcademico (table: Matricula)
ALTER TABLE Matricula ADD CONSTRAINT Matricula_PeriodoAcademico
    FOREIGN KEY (PeriodoAcademico_Year)
    REFERENCES PeriodoAcademico (Year);

-- Reference: Matricula_Usuario (table: Matricula)
ALTER TABLE Matricula ADD CONSTRAINT Matricula_Usuario
    FOREIGN KEY (Usuario_NDocumento)
    REFERENCES Usuario (NDocumento);

-- Reference: Padre_Distrito (table: Padre)
ALTER TABLE Padre ADD CONSTRAINT Padre_Distrito
    FOREIGN KEY (Distrito)
    REFERENCES Distrito (IdDistrito);

-- Reference: Padre_Identificacion (table: Padre)
ALTER TABLE Padre ADD CONSTRAINT Padre_Identificacion
    FOREIGN KEY (Identificacion_Codigo)
    REFERENCES Identificacion (Codigo);

-- Reference: Provincia_Departamento (table: Provincia)
ALTER TABLE Provincia ADD CONSTRAINT Provincia_Departamento
    FOREIGN KEY (IdDepartamento)
    REFERENCES Departamento (IdDepartamento);

-- Reference: Usuario_Cargo (table: Usuario)
ALTER TABLE Usuario ADD CONSTRAINT Usuario_Cargo
    FOREIGN KEY (Cargo_CodCargo)
    REFERENCES Cargo (CodCargo);

-- Reference: Usuario_Distrito (table: Usuario)
ALTER TABLE Usuario ADD CONSTRAINT Usuario_Distrito
    FOREIGN KEY (Distrito)
    REFERENCES Distrito (IdDistrito);

-- Reference: Usuario_Empresa (table: Usuario)
ALTER TABLE Usuario ADD CONSTRAINT Usuario_Empresa
    FOREIGN KEY (Empresa_Codigo)
    REFERENCES Empresa (Codigo);

-- Reference: Usuarios_Identificacion (table: Usuario)
ALTER TABLE Usuario ADD CONSTRAINT Usuarios_Identificacion
    FOREIGN KEY (Identificacion_Codigo)
    REFERENCES Identificacion (Codigo);

use AT
go
create proc usp_Padre_insertar
@parId_codigo tinyint,
@parNdocumento varchar(20),
@parNombreCompleto varchar(200),
@parDireccion varchar(200),
@parDistrito smallint,
@parNumeroCelular varchar(50),
@parTrabajo varchar(150),
@parCorreo varchar(150)
as
insert into Padre(Identificacion_Codigo, NDocumento, NombreCompleto, Direccion, Distrito, NumeroCelular, Trabajo, Correo)
values
(@parId_codigo,
@parNdocumento,
@parNombreCompleto,
@parDireccion,
@parDistrito,
@parNumeroCelular,
@parTrabajo,
@parCorreo)
go

create proc usp_Estudiante_insertar
@parId_codigo tinyint,
@parNdocumento varchar(20),
@parApellidosNombres varchar(200),
@parPadreAp_NDocumento varchar(20),
@parPadre_NDocumento varchar(20),
@parColegioProcedencia varchar(150),
@parPeso float,
@parTalla smallint,
@parCondicionSalud varchar(200),
@parFechaNacimineto date,
@parNumeroCelular varchar(50)
as
SET DATEFORMAT DMY
insert into Estudiante(Identificacion_Codigo, NDocumeto, ApellidosNombres, PadreAp_NDocumento, Padre_NDocumento, ColegioProcedencia, Peso, Talla, CondicionSalud, FechaNacimiento, NumeroCelular)
values
(@parId_codigo,
@parNdocumento,
@parApellidosNombres,
@parPadreAp_NDocumento,
@parPadre_NDocumento,
@parColegioProcedencia,
@parPeso,
@parTalla,
@parCondicionSalud,
@parFechaNacimineto,
@parNumeroCelular)
go

create proc usp_Identificacion_listar
as
SELECT        Identificacion.*
FROM            Identificacion
go

create proc usp_GragoAcademico_listarGrados
as
SELECT        Grado
FROM            GradoAcademico
GROUP BY  Grado
go
create proc usp_GradoAcademico_listarSecciones
@parGrado char(1)
as
SELECT        GradoAcademico.Seccion, GradoAcademico.Capacidad, COUNT(Matricula.Estudiante_NDocumeto) AS Matriculados, GradoAcademico.Grado
FROM            GradoAcademico LEFT OUTER JOIN
                         Matricula ON GradoAcademico.Grado = Matricula.GradoAcademico_Grado AND GradoAcademico.Seccion = Matricula.GradoAcademico_Seccion
WHERE Grado = @parGrado
GROUP BY GradoAcademico.Grado, GradoAcademico.Seccion,PeriodoAcademico_Year,Capacidad
go
create proc usp_Usuario_Validar
@parusername varchar(30),
@parpassword varchar(120)
as
SELECT        Cargo.Nombre as Cargo, Usuario.NDocumento, Usuario.username, Usuario.Nombres, Usuario.Apellidos, Usuario.Correo
FROM            Usuario INNER JOIN
                         Cargo ON Usuario.Cargo_CodCargo = Cargo.CodCargo
WHERE   username = @parusername and password = @parpassword
go


create proc usp_Cargo_Listar_todo
as
SELECT        CodCargo, Nombre
FROM            Cargo
go

Create proc usp_Padre_Listar_por_DNI_o_NumeroDocumento
@parNumeroDoc varchar(20)
as
SELECT        Identificacion_Codigo, NDocumento, NombreCompleto, Direccion, NumeroCelular, Trabajo, Correo
FROM            Padre
WHERE  NDocumento like @parNumeroDoc + '%'
go

create proc usp_Departamento_listar
as
SELECT        IdDepartamento, Nombre
FROM            Departamento
go

create proc usp_Provincia_listar
@parIdDepartemento tinyint
as
SELECT        IdProvincia, Nombre, IdDepartamento
FROM            Provincia
WHERE  IdDepartamento = @parIdDepartemento
go

create proc usp_Distrito_listar
@parIdProvincia tinyint
as
SELECT        IdDistrito, Nombre, IdProvincia
FROM            Distrito
WHERE  IdProvincia = @parIdProvincia
go

create proc usp_Matricula_registrar
@parYear char(4),
@parEstudiante varchar(20),
@parUsuario varchar(15),
@parVerificacionMatricula bit,
@parGrado char(1),
@parSeccion char(1)
as
insert into Matricula
values
(@parYear,@parEstudiante,@parUsuario,@parVerificacionMatricula,@parGrado,@parSeccion,GETDATE())
 DECLARE @mes tinyint
 DECLARE @valorMaximo tinyint
 DECLARE @numeromes tinyint
 DECLARE @pension tinyint
 SET @numeromes = 12 - MONTH(GETDATE())
 IF @numeromes >= 10
 BEGIN
 SET @numeromes = 9
 END
if @parGrado between 1 and 4
begin
 SELECT @valorMaximo = COUNT(FechaPago.Codigo)FROM FechaPago
 SET @mes = @valorMaximo - @numeromes
  insert into Matricula_DiversoPago(Estudiante_NDocumeto, Monto_Codigo, FechaPago_Codigo, PeriodoAcademico_Year, EstadoPago_Codigo, Prorroga) 
  values 
  (@parEstudiante,1,@mes,@parYear,1,0),
  (@parEstudiante,4,@mes,@parYear,1,0)
  if @parGrado = 1 begin set @pension = 2 end
  else
 begin
  if @parGrado = 2 begin set @pension = 6 end
  else
   begin
    if @parGrado = 3 begin set @pension = 7 end
    else
     begin
      set @pension = 8
     end
   end
 end
 WHILE @mes<= @valorMaximo
 BEGIN
  insert into Matricula_DiversoPago(Estudiante_NDocumeto, Monto_Codigo, FechaPago_Codigo, PeriodoAcademico_Year, EstadoPago_Codigo, Prorroga) 
  values
  (@parEstudiante,@pension,@mes,@parYear,1,0)
  SET @mes = @mes + 1;
 END;
end
else
begin
 SELECT @valorMaximo = COUNT(FechaPago.Codigo)FROM FechaPago
 SET @mes = @valorMaximo - @numeromes
 insert into Matricula_DiversoPago(Estudiante_NDocumeto, Monto_Codigo, FechaPago_Codigo, PeriodoAcademico_Year, EstadoPago_Codigo, Prorroga) 
 values 
 (@parEstudiante,1,@mes,@parYear,1,0),
 (@parEstudiante,4,@mes,@parYear,1,0)   
 WHILE @mes<= @valorMaximo
 BEGIN
  insert into Matricula_DiversoPago(Estudiante_NDocumeto, Monto_Codigo, FechaPago_Codigo, PeriodoAcademico_Year, EstadoPago_Codigo, Prorroga ) 
  values
  (@parEstudiante,3,@mes,@parYear,1,0)
  SET @mes = @mes + 1;
 END;
end
go

create proc usp_PeriodoPeriodoAcademico_listaractual
as
SELECT        Year, FechaInicio, FechaFinal
FROM            PeriodoAcademico
Where  Year = YEAR(GETDATE())
go

create proc usp_Estudiante_listar_porDocumento
@parNumDoc varchar(20)
as
SELECT        NDocumeto, ApellidosNombres
FROM            Estudiante
WHERE  NDocumeto like @parNumDoc + '%'
go

create proc usp_MatriculaDiversoPago_listar_porEstudiante
@parNumDoc varchar(20)
as
SELECT        Matricula_DiversoPago.Estudiante_NDocumeto, EstadoPago.Detalle, DATEADD(DAY, Matricula_DiversoPago.Prorroga, FechaPago.FechaVenc) AS FV, Monto.Descripcion, 
    (Monto.Monto - SUM(MultiplePago.MontoPagado)) AS Monto, Monto.Monto AS DEF, Matricula_DiversoPago.Prorroga,
                         Monto.Codigo AS MontoCodigo, FechaPago.Codigo AS FechaCodigo
FROM            Matricula_DiversoPago INNER JOIN
                         EstadoPago ON Matricula_DiversoPago.EstadoPago_Codigo = EstadoPago.Codigo INNER JOIN
                         FechaPago ON Matricula_DiversoPago.FechaPago_Codigo = FechaPago.Codigo INNER JOIN
                         Monto ON Matricula_DiversoPago.Monto_Codigo = Monto.Codigo LEFT JOIN
                         MultiplePago ON Matricula_DiversoPago.Estudiante_NDocumeto = MultiplePago.Estudiante_NDocumeto AND Matricula_DiversoPago.Monto_Codigo = MultiplePago.Monto_Codigo AND 
                         Matricula_DiversoPago.FechaPago_Codigo = MultiplePago.FechaPago_Codigo
WHERE        (Matricula_DiversoPago.Estudiante_NDocumeto = @parNumDoc)
GROUP BY Detalle,Descripcion,Monto.Codigo,FechaPago.Codigo,Matricula_DiversoPago.Estudiante_NDocumeto,Monto.Monto,Matricula_DiversoPago.Prorroga,FechaPago.FechaVenc, Matricula_DiversoPago.Prorroga
ORDER BY FechaPago.FechaVenc, Monto.Descripcion
go

create proc usp_MatriculaDiversoPago_listar_SinPagar_porEstudiante
@parNumDoc varchar(20)
as
SELECT        Matricula_DiversoPago.Estudiante_NDocumeto, EstadoPago.Detalle, DATEADD(DAY, Matricula_DiversoPago.Prorroga, FechaPago.FechaVenc) AS FV, Monto.Descripcion, 
    (Monto.Monto - SUM(MultiplePago.MontoPagado)) AS Monto, Monto.Monto AS DEF, Matricula_DiversoPago.Prorroga,
                         Monto.Codigo AS MontoCodigo, FechaPago.Codigo AS FechaCodigo
FROM            Matricula_DiversoPago INNER JOIN
                         EstadoPago ON Matricula_DiversoPago.EstadoPago_Codigo = EstadoPago.Codigo INNER JOIN
                         FechaPago ON Matricula_DiversoPago.FechaPago_Codigo = FechaPago.Codigo INNER JOIN
                         Monto ON Matricula_DiversoPago.Monto_Codigo = Monto.Codigo LEFT JOIN
                         MultiplePago ON Matricula_DiversoPago.Estudiante_NDocumeto = MultiplePago.Estudiante_NDocumeto AND Matricula_DiversoPago.Monto_Codigo = MultiplePago.Monto_Codigo AND 
                         Matricula_DiversoPago.FechaPago_Codigo = MultiplePago.FechaPago_Codigo
WHERE        (Matricula_DiversoPago.Estudiante_NDocumeto = @parNumDoc) AND (YEAR(FechaPago.FechaVenc) = YEAR(GETDATE())) AND (Matricula_DiversoPago.EstadoPago_Codigo= 1 OR Matricula_DiversoPago.EstadoPago_Codigo = 3)  AND Monto <> 0
GROUP BY Detalle,Descripcion,Monto.Codigo,FechaPago.Codigo,Matricula_DiversoPago.Estudiante_NDocumeto,Monto.Monto,Matricula_DiversoPago.Prorroga,FechaPago.FechaVenc, Matricula_DiversoPago.Prorroga
ORDER BY FechaPago.FechaVenc, Monto.Descripcion
go

create proc usp_Padre_comprobar_siExiste
@parNumDoc varchar(20)
as
SELECT        NombreCompleto, Direccion, NumeroCelular, Trabajo, Correo, Identificacion_Codigo, NDocumento
FROM            Padre
WHERE  NDocumento = @parNumDoc
go

create proc usp_Estudiante_comprobar_siExiste
@parNumDoc varchar(20)
as
SELECT        NumeroCelular, FechaNacimiento, CondicionSalud, Peso, ColegioProcedencia, ApellidosNombres, NDocumeto, Talla
FROM            Estudiante
WHERE  NDocumeto = @parNumDoc
go

create proc usp_Pagos_Registrar
@parMonto smallmoney
as
insert into Pago
values
(@parMonto,GETDATE())
select top 1 Numero
from Pago
order by Numero desc
go

create proc usp_MultiplePago_Registrar
@parEstudiante_NDocumeto varchar(20),
@parMonto_Codigo   tinyint,
@parFechaPago_Codigo  tinyint,
@parPago_Numero    bigint,
@parMontoPagado    smallmoney
as
insert into MultiplePago
values
(@parEstudiante_NDocumeto,@parMonto_Codigo,@parFechaPago_Codigo,@parPago_Numero,@parMontoPagado)
declare @monto1 smallmoney
set @monto1 =(
SELECT        Monto
FROM            Monto
WHERE Codigo = @parMonto_Codigo
 )
declare @monto2 smallmoney
set @monto2 =(
 SELECT       SUM(MontoPagado)
 FROM            MultiplePago
 WHERE  MultiplePago.Monto_Codigo = @parMonto_Codigo 
  and MultiplePago.FechaPago_Codigo = @parFechaPago_Codigo
  and MultiplePago.Estudiante_NDocumeto = @parEstudiante_NDocumeto
 )
IF @monto2 = @monto1
BEGIN
 UPDATE Matricula_DiversoPago
 SET EstadoPago_Codigo = 2
 WHERE Estudiante_NDocumeto = @parEstudiante_NDocumeto and
   Monto_Codigo = @parMonto_Codigo and
    FechaPago_Codigo = @parFechaPago_Codigo
END
ELSE
BEGIN
 UPDATE Matricula_DiversoPago
 SET EstadoPago_Codigo = 3
 WHERE Estudiante_NDocumeto = @parEstudiante_NDocumeto and
   Monto_Codigo = @parMonto_Codigo and
    FechaPago_Codigo = @parFechaPago_Codigo
END
go

create proc usp_Matricula_DiversoPago_ReporteEspecifico
@parGrado char(1),
@parSeccion char(1)
as
SELECT        Estudiante.NDocumeto, Estudiante.ApellidosNombres,  DATEADD(DAY, Matricula_DiversoPago.Prorroga, FechaPago.FechaVenc) as FechaVenc, FechaPago.Codigo AS fecha_cod, SUM(MultiplePago.MontoPagado) AS pagado, Monto.Monto, EstadoPago.Codigo as estado_pago, EstadoPago.Detalle, GradoAcademico_Grado as Grado, GradoAcademico_Seccion as Seccion, Monto.Descripcion
FROM            Monto INNER JOIN
                         EstadoPago INNER JOIN
                         Matricula INNER JOIN
                         Estudiante ON Matricula.Estudiante_NDocumeto = Estudiante.NDocumeto INNER JOIN
                         Matricula_DiversoPago ON Matricula.PeriodoAcademico_Year = Matricula_DiversoPago.PeriodoAcademico_Year AND Matricula.Estudiante_NDocumeto = Matricula_DiversoPago.Estudiante_NDocumeto ON 
                         EstadoPago.Codigo = Matricula_DiversoPago.EstadoPago_Codigo ON Monto.Codigo = Matricula_DiversoPago.Monto_Codigo INNER JOIN
                         FechaPago ON Matricula_DiversoPago.FechaPago_Codigo = FechaPago.Codigo LEFT OUTER JOIN
                         MultiplePago ON Matricula_DiversoPago.Estudiante_NDocumeto = MultiplePago.Estudiante_NDocumeto AND Matricula_DiversoPago.Monto_Codigo = MultiplePago.Monto_Codigo AND 
                         Matricula_DiversoPago.FechaPago_Codigo = MultiplePago.FechaPago_Codigo
WHERE        (Matricula.PeriodoAcademico_Year = CONVERT(varchar(20), YEAR(GETDATE()))) and GradoAcademico_Grado = @parGrado and GradoAcademico_Seccion = @parSeccion
GROUP BY Monto.Monto, Estudiante.NDocumeto, Estudiante.ApellidosNombres, FechaPago.FechaVenc, FechaPago.Codigo, Estudiante.NDocumeto, EstadoPago.Codigo, EstadoPago.Detalle, Matricula_DiversoPago.Prorroga, GradoAcademico_Grado, GradoAcademico_Seccion, Monto.Descripcion
ORDER BY Grado, Seccion, NDocumeto, fecha_cod
go

create proc usp_GradoAcademico_verCantidadVacantes
@parGrado char
as
SELECT        Matricula.PeriodoAcademico_Year, GradoAcademico.Capacidad, COUNT(Matricula.Estudiante_NDocumeto) AS Matriculados, GradoAcademico.Grado+ ' "'+GradoAcademico.Seccion+'"' AS GradoSeccion
FROM            GradoAcademico LEFT OUTER JOIN
                         Matricula ON GradoAcademico.Grado = Matricula.GradoAcademico_Grado AND GradoAcademico.Seccion = Matricula.GradoAcademico_Seccion
WHERE Grado = @parGrado
GROUP BY GradoAcademico.Grado, GradoAcademico.Seccion,PeriodoAcademico_Year,Capacidad
go

create proc usp_FechaPago_listaractuales
as
SELECT        Codigo, FechaVenc
FROM            FechaPago
WHERE        (YEAR(FechaVenc) = YEAR(GETDATE()))
go

create proc usp_Matricula_DiversoPago_Asignarprorroga
@parEstudiante_NDocumeto varchar(20),
@parMonto_Codigo tinyint,
@parFechaPago_Codigo tinyint,
@parDias tinyint
as
UPDATE Matricula_DiversoPago
 SET Prorroga = @parDias
 WHERE Estudiante_NDocumeto = @parEstudiante_NDocumeto and
   Monto_Codigo = @parMonto_Codigo and
    FechaPago_Codigo = @parFechaPago_Codigo
go

create proc usp_Matricula_DiversoPago_ReporteporGrado
@parGrado char(1)
as
SELECT        Estudiante.NDocumeto, Estudiante.ApellidosNombres,  DATEADD(DAY, Matricula_DiversoPago.Prorroga, FechaPago.FechaVenc) as FechaVenc, FechaPago.Codigo AS fecha_cod, SUM(MultiplePago.MontoPagado) AS pagado, Monto.Monto, EstadoPago.Codigo as estado_pago, EstadoPago.Detalle, GradoAcademico_Grado as Grado, GradoAcademico_Seccion as Seccion, Monto.Descripcion
FROM            Monto INNER JOIN
                         EstadoPago INNER JOIN
                         Matricula INNER JOIN
                         Estudiante ON Matricula.Estudiante_NDocumeto = Estudiante.NDocumeto INNER JOIN
                         Matricula_DiversoPago ON Matricula.PeriodoAcademico_Year = Matricula_DiversoPago.PeriodoAcademico_Year AND Matricula.Estudiante_NDocumeto = Matricula_DiversoPago.Estudiante_NDocumeto ON 
                         EstadoPago.Codigo = Matricula_DiversoPago.EstadoPago_Codigo ON Monto.Codigo = Matricula_DiversoPago.Monto_Codigo INNER JOIN
                         FechaPago ON Matricula_DiversoPago.FechaPago_Codigo = FechaPago.Codigo LEFT OUTER JOIN
                         MultiplePago ON Matricula_DiversoPago.Estudiante_NDocumeto = MultiplePago.Estudiante_NDocumeto AND Matricula_DiversoPago.Monto_Codigo = MultiplePago.Monto_Codigo AND 
                         Matricula_DiversoPago.FechaPago_Codigo = MultiplePago.FechaPago_Codigo
WHERE        (Matricula.PeriodoAcademico_Year = CONVERT(varchar(20), YEAR(GETDATE()))) and GradoAcademico_Grado = @parGrado
GROUP BY Monto.Monto, Estudiante.NDocumeto, Estudiante.ApellidosNombres, FechaPago.FechaVenc, FechaPago.Codigo, Estudiante.NDocumeto, EstadoPago.Codigo, EstadoPago.Detalle, Matricula_DiversoPago.Prorroga, GradoAcademico_Grado, GradoAcademico_Seccion, Monto.Descripcion
ORDER BY Grado, Seccion, NDocumeto, fecha_cod
go

create proc usp_Matricula_DiversoPago_ReporteGeneral
as
SELECT        Estudiante.NDocumeto, Estudiante.ApellidosNombres,  DATEADD(DAY, Matricula_DiversoPago.Prorroga, FechaPago.FechaVenc) as FechaVenc, FechaPago.Codigo AS fecha_cod, SUM(MultiplePago.MontoPagado) AS pagado, Monto.Monto, EstadoPago.Codigo as estado_pago, EstadoPago.Detalle, GradoAcademico_Grado as Grado, GradoAcademico_Seccion as Seccion, Monto.Descripcion
FROM            Monto INNER JOIN
                         EstadoPago INNER JOIN
                         Matricula INNER JOIN
                         Estudiante ON Matricula.Estudiante_NDocumeto = Estudiante.NDocumeto INNER JOIN
                         Matricula_DiversoPago ON Matricula.PeriodoAcademico_Year = Matricula_DiversoPago.PeriodoAcademico_Year AND Matricula.Estudiante_NDocumeto = Matricula_DiversoPago.Estudiante_NDocumeto ON 
                         EstadoPago.Codigo = Matricula_DiversoPago.EstadoPago_Codigo ON Monto.Codigo = Matricula_DiversoPago.Monto_Codigo INNER JOIN
                         FechaPago ON Matricula_DiversoPago.FechaPago_Codigo = FechaPago.Codigo LEFT OUTER JOIN
                         MultiplePago ON Matricula_DiversoPago.Estudiante_NDocumeto = MultiplePago.Estudiante_NDocumeto AND Matricula_DiversoPago.Monto_Codigo = MultiplePago.Monto_Codigo AND 
                         Matricula_DiversoPago.FechaPago_Codigo = MultiplePago.FechaPago_Codigo
WHERE        (Matricula.PeriodoAcademico_Year = CONVERT(varchar(20), YEAR(GETDATE())))
GROUP BY Monto.Monto, Estudiante.NDocumeto, Estudiante.ApellidosNombres, FechaPago.FechaVenc, FechaPago.Codigo, Estudiante.NDocumeto, EstadoPago.Codigo, EstadoPago.Detalle, Matricula_DiversoPago.Prorroga, GradoAcademico_Grado, GradoAcademico_Seccion, Monto.Descripcion
ORDER BY Grado, Seccion, NDocumeto, fecha_cod
go

create proc usp_Estudiante_mostrar
@parNumDoc varchar(20)
as
SELECT        NDocumeto, ApellidosNombres, PadreAp_NDocumento AS Padre1, Padre_NDocumento AS Padre2, ColegioProcedencia, Peso, Talla, CondicionSalud, FechaNacimiento
FROM            Estudiante
WHERE NDocumeto = @parNumDoc
go

create proc usp_Padre_mostrar
@parNumDoc varchar(20)
as
SELECT        Padre.NombreCompleto, Padre.Direccion, Padre.Distrito, Padre.NumeroCelular, Padre.Trabajo, Padre.Correo, Padre.NDocumento, Distrito.Nombre as DNombre, Provincia.IdProvincia as IDProvincia, Provincia.Nombre AS PNombre, 
                         Departamento.IdDepartamento as IDDep, Departamento.Nombre AS DepNombre
FROM            Padre INNER JOIN
                         Distrito ON Padre.Distrito = Distrito.IdDistrito INNER JOIN
                         Provincia ON Distrito.IdProvincia = Provincia.IdProvincia INNER JOIN
                         Departamento ON Provincia.IdDepartamento = Departamento.IdDepartamento
WHERE NDocumento = @parNumDoc
go

create proc usp_Estudiante_Modificar
@parNdocumento      varchar(20),
@parApellidosNombres    varchar(200),
@parColegioProcedencia    varchar(150),
@parPeso       float,
@parTalla       smallint,
@parCondicionSalud     varchar(200),
@parFechaNacimineto     date,
@parNumeroCelular     varchar(50)
as
UPDATE Estudiante
 SET ApellidosNombres = @parApellidosNombres, ColegioProcedencia = @parColegioProcedencia, Peso = @parPeso, Talla = @parTalla, CondicionSalud = @parCondicionSalud, FechaNacimiento = @parFechaNacimineto, NumeroCelular = @parNumeroCelular
 WHERE NDocumeto = @parNdocumento
go

create proc usp_Padre_Modificar
@parNdocumento      varchar(20),
@parNombreCompleto     varchar(200),
@parDireccion      varchar(200),
@parDistrito      smallint,
@parNumeroCelular     varchar(50),
@parTrabajo       varchar(150),
@parCorreo       varchar(150)
as
UPDATE Padre
 SET NombreCompleto = @parNombreCompleto, Direccion = @parDireccion, Distrito = @parDistrito, NumeroCelular = @parNumeroCelular, Trabajo = @parTrabajo, Correo = @parCorreo
 WHERE NDocumento = @parNdocumento
go

create proc usp_GradoAcademico_confirmar
@parGrado char(1),
@parSeccion char(1)
as
SELECT        GradoAcademico.Capacidad - COUNT(Matricula.Estudiante_NDocumeto) AS Disponible
FROM            GradoAcademico LEFT OUTER JOIN
                         Matricula ON GradoAcademico.Grado = Matricula.GradoAcademico_Grado AND GradoAcademico.Seccion = Matricula.GradoAcademico_Seccion
WHERE Grado = @parGrado and Seccion = @parSeccion
GROUP BY GradoAcademico.Grado, GradoAcademico.Seccion,PeriodoAcademico_Year,Capacidad;

-- End of file.
