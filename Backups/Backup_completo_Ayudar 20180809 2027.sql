-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.55-0+deb8u1


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema ayudardb
--

CREATE DATABASE IF NOT EXISTS ayudardb;
USE ayudardb;

--
-- Definition of table `articulo`
--

DROP TABLE IF EXISTS `articulo`;
CREATE TABLE `articulo` (
  `id_articulo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_tipo_articulo` int(10) unsigned NOT NULL,
  `nombre` char(254) NOT NULL,
  `descripcion` char(254) NOT NULL,
  PRIMARY KEY (`id_articulo`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `articulo`
--

/*!40000 ALTER TABLE `articulo` DISABLE KEYS */;
INSERT INTO `articulo` (`id_articulo`,`id_tipo_articulo`,`nombre`,`descripcion`) VALUES 
 (1,2,'REMERA T S','REMERA TALLE S'),
 (2,2,'REMERA T M','REMERA TALLE M'),
 (4,2,'REMERA T L','REMERA TALLE L'),
 (5,3,'DINERO','PESOS'),
 (6,1,'LECHE','LECHE SANCOR 1 LT.'),
 (7,2,'ZAPATILLA T 42','ZAPATILLA TALLE 42'),
 (8,1,'ARROZ','ARROZ 1 KG');
/*!40000 ALTER TABLE `articulo` ENABLE KEYS */;


--
-- Definition of table `barrio`
--

DROP TABLE IF EXISTS `barrio`;
CREATE TABLE `barrio` (
  `id_barrio` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre_barrio` char(254) NOT NULL,
  `ciudad` char(254) NOT NULL,
  PRIMARY KEY (`id_barrio`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `barrio`
--

/*!40000 ALTER TABLE `barrio` DISABLE KEYS */;
INSERT INTO `barrio` (`id_barrio`,`nombre_barrio`,`ciudad`) VALUES 
 (2,'CENTRO','RECREO'),
 (3,'RECREO SUR','RECREO');
/*!40000 ALTER TABLE `barrio` ENABLE KEYS */;


--
-- Definition of table `beneficiario`
--

DROP TABLE IF EXISTS `beneficiario`;
CREATE TABLE `beneficiario` (
  `id_beneficiario` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_barrio` int(10) unsigned NOT NULL,
  `nombre` char(254) NOT NULL,
  `documento` char(254) NOT NULL,
  `direccion` char(254) NOT NULL,
  `telefono` char(254) NOT NULL,
  `cuit_cuil` char(254) DEFAULT NULL,
  `fecha_nac` datetime DEFAULT NULL,
  PRIMARY KEY (`id_beneficiario`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `beneficiario`
--

/*!40000 ALTER TABLE `beneficiario` DISABLE KEYS */;
INSERT INTO `beneficiario` (`id_beneficiario`,`id_barrio`,`nombre`,`documento`,`direccion`,`telefono`,`cuit_cuil`,`fecha_nac`) VALUES 
 (1,2,'PABLO BONET','33468473','MITRE 1900','123456798','20-33468473-4','2000-01-01 00:00:00'),
 (2,2,'JUAN PEREZ','12345678','CALLE 1','2983874748','','1900-01-01 00:00:00'),
 (3,3,'TULIO ROSSI','46578912','CALLE2','123123','','1980-01-01 00:00:00'),
 (4,2,'PABLO MAGNAGO','33468474','MITRE 1900','4960494','','1988-04-09 00:00:00');
/*!40000 ALTER TABLE `beneficiario` ENABLE KEYS */;


--
-- Definition of table `beneficiario_beneficio`
--

DROP TABLE IF EXISTS `beneficiario_beneficio`;
CREATE TABLE `beneficiario_beneficio` (
  `id_benef_beneficio` int(10) unsigned NOT NULL,
  `id_beneficiario` int(10) unsigned NOT NULL,
  `id_beneficio` int(10) unsigned NOT NULL,
  `fechadesde` datetime NOT NULL,
  PRIMARY KEY (`id_benef_beneficio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `beneficiario_beneficio`
--

/*!40000 ALTER TABLE `beneficiario_beneficio` DISABLE KEYS */;
/*!40000 ALTER TABLE `beneficiario_beneficio` ENABLE KEYS */;


--
-- Definition of table `beneficiario_grupo`
--

DROP TABLE IF EXISTS `beneficiario_grupo`;
CREATE TABLE `beneficiario_grupo` (
  `id_benef_grupo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_beneficiario` int(10) unsigned NOT NULL,
  `id_gupo` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_benef_grupo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `beneficiario_grupo`
--

/*!40000 ALTER TABLE `beneficiario_grupo` DISABLE KEYS */;
INSERT INTO `beneficiario_grupo` (`id_benef_grupo`,`id_beneficiario`,`id_gupo`) VALUES 
 (1,1,1),
 (2,4,1),
 (3,4,2);
/*!40000 ALTER TABLE `beneficiario_grupo` ENABLE KEYS */;


--
-- Definition of table `beneficio`
--

DROP TABLE IF EXISTS `beneficio`;
CREATE TABLE `beneficio` (
  `id_beneficio` int(10) unsigned NOT NULL,
  `nombre` char(100) NOT NULL,
  `descripcion` char(250) NOT NULL,
  PRIMARY KEY (`id_beneficio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `beneficio`
--

/*!40000 ALTER TABLE `beneficio` DISABLE KEYS */;
/*!40000 ALTER TABLE `beneficio` ENABLE KEYS */;


--
-- Definition of table `funcion`
--

DROP TABLE IF EXISTS `funcion`;
CREATE TABLE `funcion` (
  `id_funcion` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_menu` int(10) unsigned NOT NULL,
  `nombre_funcion` char(254) NOT NULL,
  `nombre_menu` char(254) NOT NULL,
  PRIMARY KEY (`id_funcion`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funcion`
--

/*!40000 ALTER TABLE `funcion` DISABLE KEYS */;
INSERT INTO `funcion` (`id_funcion`,`id_menu`,`nombre_funcion`,`nombre_menu`) VALUES 
 (1,1,'btnAgregarOrden','tabOrdenesEntrega'),
 (2,1,'btnModificarOrden','tabOrdenesEntrega'),
 (3,1,'btnEliminarOrden','tabOrdenesEntrega'),
 (7,1,'btnBuscarOrden','tabOrdenesEntrega'),
 (8,1,'btnAbrirOrden','tabOrdenesEntrega'),
 (9,1,'btnAutorizarOrden','tabOrdenesEntrega'),
 (10,1,'btnEntregarOrden','tabOrdenesEntrega'),
 (11,1,'btnCancelarOrden','tabOrdenesEntrega'),
 (12,1,'btnReporteEstadosOrden','tabOrdenesEntrega'),
 (13,2,'btnNuevoBeneficiario','tabBeneficiarios'),
 (14,2,'btnAdministrarBeneficiario','tabBeneficiarios'),
 (15,2,'btnReporteEntregaBeneficiario','tabBeneficiarios'),
 (16,3,'btnNuevoArticulo','tabArticulos'),
 (17,3,'btnAdministrarArticulo','tabArticulos'),
 (18,3,'btnNuevoTipoArticulo','tabArticulos'),
 (19,3,'btnAdministrarTipoArticulo','tabArticulos'),
 (20,4,'btnAgregarBarrio','tabOtros'),
 (21,4,'btnAdministrarBarrios','tabOtros'),
 (22,5,'btnAgregarUsuario','tabAvanzado'),
 (23,5,'btnAdministrarUsuario','tabAvanzado'),
 (24,2,'btnNuevoGrupoBeneficiario','tabBeneficiario'),
 (25,2,'btnAdministrarGrupoBeneficiario','tabBeneficiario'),
 (26,6,'btnAgregarBeneficiario','tabConsultaOrden'),
 (27,6,'btnAutorizarOrden','tabConsultaOrden'),
 (28,6,'btnEntregarOrden','tabConsultaOrden'),
 (29,6,'btnCancelarOrden','tabConsultaOrden'),
 (30,6,'btnAgregarBeneficiario','tabConsultaOrden'),
 (31,6,'btnGuardarOrden','tabConsultaOrden'),
 (32,7,'btnEliminarBeneficiario','tabConsultaBeneficiario'),
 (33,7,'btnGuardarBeneficiario','tabConsultaBeneficiario'),
 (34,8,'btnEliminarArticulo','tabConsultaArticulo'),
 (35,8,'btnGuardarArticulo','tabConsultaArticulo'),
 (36,9,'btnEliminarBarrio','tabConsultaBarrio'),
 (37,9,'btnGuardarBarrio','tabConsultaBarrio'),
 (38,10,'btnEliminarGrupo','tabConsultaGrupo'),
 (39,10,'btnGuardarGrupo','tabConsultaGrupo'),
 (40,2,'btnReporteEntregaGrupo','tabBeneficiarios');
/*!40000 ALTER TABLE `funcion` ENABLE KEYS */;


--
-- Definition of table `grupo`
--

DROP TABLE IF EXISTS `grupo`;
CREATE TABLE `grupo` (
  `id_grupo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` char(254) NOT NULL,
  `descripcion` char(254) NOT NULL,
  PRIMARY KEY (`id_grupo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `grupo`
--

/*!40000 ALTER TABLE `grupo` DISABLE KEYS */;
INSERT INTO `grupo` (`id_grupo`,`nombre`,`descripcion`) VALUES 
 (1,'FLIA BONET','GRUPO DE BENEFICIARIOS DE LA FAMILIA BONET.'),
 (2,'FLIA MAGNAGO','GRUPO DE LA FLIA MAGNAGO');
/*!40000 ALTER TABLE `grupo` ENABLE KEYS */;


--
-- Definition of table `itemcompra`
--

DROP TABLE IF EXISTS `itemcompra`;
CREATE TABLE `itemcompra` (
  `id_item_compra` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_compra` int(10) unsigned NOT NULL,
  `id_articulo` int(10) unsigned NOT NULL,
  `cantidad` float NOT NULL,
  `precio_unitario` float NOT NULL,
  PRIMARY KEY (`id_item_compra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `itemcompra`
--

/*!40000 ALTER TABLE `itemcompra` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemcompra` ENABLE KEYS */;


--
-- Definition of table `itementrega`
--

DROP TABLE IF EXISTS `itementrega`;
CREATE TABLE `itementrega` (
  `id_item_entrega` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_orden` int(10) unsigned NOT NULL,
  `id_articulo` int(10) unsigned NOT NULL,
  `cantidad` float NOT NULL,
  PRIMARY KEY (`id_item_entrega`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `itementrega`
--

/*!40000 ALTER TABLE `itementrega` DISABLE KEYS */;
INSERT INTO `itementrega` (`id_item_entrega`,`id_orden`,`id_articulo`,`cantidad`) VALUES 
 (1,1,2,1),
 (2,2,5,1000),
 (3,2,6,2),
 (4,3,6,10),
 (5,4,5,1000),
 (6,4,6,2),
 (7,5,5,1000),
 (8,5,4,10),
 (9,6,5,1000),
 (10,7,5,10),
 (11,8,6,1);
/*!40000 ALTER TABLE `itementrega` ENABLE KEYS */;


--
-- Definition of table `ordenentrega`
--

DROP TABLE IF EXISTS `ordenentrega`;
CREATE TABLE `ordenentrega` (
  `id_orden` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_beneficiario` int(10) unsigned NOT NULL,
  `id_usuario` int(10) unsigned NOT NULL,
  `id_usu_autoriza` int(10) unsigned NOT NULL,
  `id_usu_entrega` int(10) unsigned NOT NULL,
  `descripcion` char(254) NOT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`id_orden`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenentrega`
--

/*!40000 ALTER TABLE `ordenentrega` DISABLE KEYS */;
INSERT INTO `ordenentrega` (`id_orden`,`id_beneficiario`,`id_usuario`,`id_usu_autoriza`,`id_usu_entrega`,`descripcion`,`fecha`) VALUES 
 (1,1,1,1,1,'ENTREGA DE REMERA','2018-07-19 17:26:33'),
 (2,2,1,1,1,'ENTREGA DE DINERO Y LECHE','2018-07-19 17:35:34'),
 (3,2,1,1,1,'ENTREGA DE LECHE','2018-07-19 17:38:22'),
 (4,1,1,1,1,'ENTREGA DE LECHE Y DINERO','2018-07-20 20:15:22'),
 (5,3,1,1,0,'ENTREGA DE DINERO Y ZAPATILLA','2018-07-21 12:03:16'),
 (6,2,1,1,1,'LASLDSO','2018-07-23 18:18:53'),
 (7,2,1,1,0,'SDAD','2018-07-25 21:46:21'),
 (8,2,1,0,0,'PRUEBA','2018-07-26 17:33:51');
/*!40000 ALTER TABLE `ordenentrega` ENABLE KEYS */;


--
-- Definition of table `ordenestado`
--

DROP TABLE IF EXISTS `ordenestado`;
CREATE TABLE `ordenestado` (
  `id_ordenestado` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_usuario` int(10) unsigned NOT NULL,
  `id_orden` int(10) unsigned NOT NULL,
  `estado` int(10) unsigned NOT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`id_ordenestado`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenestado`
--

/*!40000 ALTER TABLE `ordenestado` DISABLE KEYS */;
INSERT INTO `ordenestado` (`id_ordenestado`,`id_usuario`,`id_orden`,`estado`,`fecha`) VALUES 
 (1,1,1,1,'2018-07-19 17:26:33'),
 (2,1,1,2,'2018-07-19 17:27:21'),
 (3,1,1,3,'2018-07-19 17:29:38'),
 (4,1,2,1,'2018-07-19 17:35:34'),
 (5,1,2,2,'2018-07-19 17:36:41'),
 (6,1,3,1,'2018-07-19 17:38:22'),
 (7,1,4,1,'2018-07-20 20:15:22'),
 (8,1,4,2,'2018-07-20 20:17:35'),
 (9,1,4,3,'2018-07-20 20:17:58'),
 (10,1,5,1,'2018-07-21 12:03:16'),
 (11,1,5,2,'2018-07-21 12:13:01'),
 (12,1,5,5,'2018-07-21 12:13:46'),
 (13,1,2,3,'2018-07-21 12:13:57'),
 (14,1,3,2,'2018-07-23 17:42:28'),
 (15,1,3,3,'2018-07-23 17:50:37'),
 (16,1,6,1,'2018-07-23 18:18:53'),
 (17,1,6,2,'2018-07-23 18:19:33'),
 (18,1,6,3,'2018-07-23 20:24:15'),
 (19,1,7,1,'2018-07-25 21:46:21'),
 (20,1,7,2,'2018-07-25 21:46:42'),
 (21,1,8,1,'2018-07-26 17:33:51'),
 (22,1,8,5,'2018-07-26 17:39:59');
/*!40000 ALTER TABLE `ordenestado` ENABLE KEYS */;


--
-- Definition of table `permiso`
--

DROP TABLE IF EXISTS `permiso`;
CREATE TABLE `permiso` (
  `id_permiso` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_usuario` int(10) unsigned NOT NULL,
  `id_funcion` int(10) unsigned NOT NULL,
  `permitido` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_permiso`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `permiso`
--

/*!40000 ALTER TABLE `permiso` DISABLE KEYS */;
INSERT INTO `permiso` (`id_permiso`,`id_usuario`,`id_funcion`,`permitido`) VALUES 
 (1,1,1,1),
 (2,1,2,1),
 (3,1,3,1),
 (7,1,7,1),
 (8,1,8,1),
 (9,1,9,1),
 (10,1,10,1),
 (11,1,11,1),
 (12,1,12,1),
 (13,1,13,1),
 (14,1,14,1),
 (15,1,15,1),
 (16,1,16,1),
 (17,1,17,1),
 (18,1,18,1),
 (19,1,19,1),
 (20,1,20,1),
 (21,1,21,1),
 (22,1,22,1),
 (23,1,23,1),
 (44,3,8,1),
 (45,3,17,1),
 (46,3,21,1),
 (47,3,14,1),
 (48,3,19,1),
 (49,3,23,1),
 (50,3,20,1),
 (51,3,1,1),
 (52,3,22,1),
 (53,3,9,1),
 (54,3,7,1),
 (55,3,11,1),
 (56,3,3,1),
 (57,3,10,1),
 (58,3,2,1),
 (59,3,16,1),
 (60,3,13,1),
 (61,3,18,1),
 (62,3,15,1),
 (63,3,12,1),
 (64,1,24,1),
 (65,1,25,1),
 (66,3,24,0),
 (67,3,25,0),
 (68,1,40,1),
 (69,3,40,0);
/*!40000 ALTER TABLE `permiso` ENABLE KEYS */;


--
-- Definition of table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
CREATE TABLE `proveedor` (
  `id_proveedor` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` char(254) NOT NULL,
  `descripcion` char(254) NOT NULL,
  `direccion` char(254) NOT NULL,
  `telefono` char(254) NOT NULL,
  `email` char(254) NOT NULL,
  PRIMARY KEY (`id_proveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proveedor`
--

/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;


--
-- Definition of table `tipoarticulo`
--

DROP TABLE IF EXISTS `tipoarticulo`;
CREATE TABLE `tipoarticulo` (
  `id_tipo_articulo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre_tipo` char(254) NOT NULL,
  `es_dinero` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_tipo_articulo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipoarticulo`
--

/*!40000 ALTER TABLE `tipoarticulo` DISABLE KEYS */;
INSERT INTO `tipoarticulo` (`id_tipo_articulo`,`nombre_tipo`,`es_dinero`) VALUES 
 (1,'ALIMENTO',0),
 (2,'INDUMENTARIA',0),
 (3,'DINERO',1),
 (4,'ROPA',0);
/*!40000 ALTER TABLE `tipoarticulo` ENABLE KEYS */;


--
-- Definition of table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `id_usuario` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre_usuario` char(254) NOT NULL,
  `contrasenia` char(254) NOT NULL,
  `nombre_completo` char(254) NOT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usuario`
--

/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`id_usuario`,`nombre_usuario`,`contrasenia`,`nombre_completo`) VALUES 
 (1,'PABLO','7e4b64eb65e34fdfad79e623c44abd94','PABLO BONET'),
 (3,'ADMIN','0192023a7bbd73250516f069df18b500','ADMINISTRADOR');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
