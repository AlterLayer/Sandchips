-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-07-2018 a las 07:46:38
-- Versión del servidor: 10.1.32-MariaDB
-- Versión de PHP: 7.2.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdsandchips`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdetdetallelocal`
--

CREATE TABLE `tbdetdetallelocal` (
  `IdDetalleLocal` int(11) NOT NULL,
  `Descripcion` varchar(200) DEFAULT NULL,
  `IdLocales` int(11) NOT NULL,
  `TipoEventos` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdetestadoreservacion`
--

CREATE TABLE `tbdetestadoreservacion` (
  `IdEstadoReservacion` int(11) NOT NULL,
  `Estado` varchar(45) NOT NULL,
  `resevacionHotelId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdetestadoreservacionrestaurante`
--

CREATE TABLE `tbdetestadoreservacionrestaurante` (
  `IdEstadoRestaurante` int(11) NOT NULL,
  `Estado` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdetgenero`
--

CREATE TABLE `tbdetgenero` (
  `IdGenero` int(11) NOT NULL,
  `Genero` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdetreservacionhotel`
--

CREATE TABLE `tbdetreservacionhotel` (
  `IdReservacionHotel` int(11) NOT NULL,
  `FechaIngreso` datetime DEFAULT NULL,
  `FechaSalida` datetime DEFAULT NULL,
  `IdClientes` int(11) NOT NULL,
  `Precio` double DEFAULT NULL,
  `IdHabitaciones` int(11) NOT NULL,
  `IdDetalleLocal` int(11) NOT NULL,
  `IdEstadoReservacion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdetreservacionrestaurante`
--

CREATE TABLE `tbdetreservacionrestaurante` (
  `IdReservacionRestaurante` int(11) NOT NULL,
  `FechaHoraIngreso` datetime DEFAULT NULL,
  `NumeroPersonas` int(11) DEFAULT NULL,
  `IdCliente` int(11) NOT NULL,
  `IdEstadoRestaurante` int(11) NOT NULL,
  `IdRestaurante` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdettipodocumento`
--

CREATE TABLE `tbdettipodocumento` (
  `IdTipoDocumento` int(11) NOT NULL,
  `Documento` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdettipoempresa`
--

CREATE TABLE `tbdettipoempresa` (
  `IdTipoEmpresa` int(11) NOT NULL,
  `TipoEmpresa` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdettipoeventos`
--

CREATE TABLE `tbdettipoeventos` (
  `IdTipoEventos` int(11) NOT NULL,
  `Evento` varchar(45) DEFAULT NULL,
  `DescripcionEvento` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdettipohabitacion`
--

CREATE TABLE `tbdettipohabitacion` (
  `IdTipoHabitacion` int(11) NOT NULL,
  `TipoHabitacion` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdettipolocal`
--

CREATE TABLE `tbdettipolocal` (
  `IdTipoLocal` int(11) NOT NULL,
  `TipoLocal` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbdettipousuarios`
--

CREATE TABLE `tbdettipousuarios` (
  `IdTipoUsuarios` int(11) NOT NULL,
  `TipoUsuario` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbmaeclientes`
--

CREATE TABLE `tbmaeclientes` (
  `IdClientes` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellidos` varchar(45) NOT NULL,
  `Documento` tinytext NOT NULL,
  `Telefono` tinytext,
  `IdGenero` int(11) NOT NULL,
  `IdEstado` int(11) NOT NULL,
  `IdUsuario` int(11) NOT NULL,
  `IdTipoDocumento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbmaeempresa`
--

CREATE TABLE `tbmaeempresa` (
  `IdEmpresa` int(11) NOT NULL,
  `Empresa` varchar(100) NOT NULL,
  `NCR` tinytext,
  `NIT` tinytext,
  `Direccion` varchar(200) DEFAULT NULL,
  `Correo` text,
  `IdTipoEmpresa` int(11) DEFAULT NULL,
  `RegistroIVA` varchar(11) DEFAULT NULL,
  `RegistroAuditor` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbmaeestado`
--

CREATE TABLE `tbmaeestado` (
  `IdEstado` int(11) NOT NULL,
  `Estado` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbmaehabitaciones`
--

CREATE TABLE `tbmaehabitaciones` (
  `IdHabitaciones` int(11) NOT NULL,
  `CodigoHabitacion` int(11) DEFAULT NULL,
  `IdTipoHabitacion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbmaelocales`
--

CREATE TABLE `tbmaelocales` (
  `IdLocales` int(11) NOT NULL,
  `CodigoLocal` int(11) DEFAULT NULL,
  `NombreLocal` varchar(100) DEFAULT NULL,
  `IdTipoLocal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbmaerestaurante`
--

CREATE TABLE `tbmaerestaurante` (
  `IdRestaurante` int(11) NOT NULL,
  `Restaurante` varchar(100) DEFAULT NULL,
  `NRC` tinytext,
  `IdEstado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbmaeusuarios`
--

CREATE TABLE `tbmaeusuarios` (
  `IdUsuarios` int(11) NOT NULL,
  `Usuario` varchar(45) NOT NULL,
  `Clave` varchar(45) NOT NULL,
  `Nombres` varchar(45) NOT NULL,
  `Apellidos` varchar(45) NOT NULL,
  `Correo` varchar(150) NOT NULL,
  `NumeroDocumento` varchar(26) DEFAULT NULL,
  `Direccion` varchar(200) DEFAULT NULL,
  `Telefono` varchar(24) DEFAULT NULL,
  `Nacimiento` date DEFAULT NULL,
  `IdTipoDocumento` int(11) NOT NULL,
  `IdGenero` int(11) NOT NULL,
  `IdEstado` int(11) NOT NULL,
  `IdTipoUsuarios` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tbdetdetallelocal`
--
ALTER TABLE `tbdetdetallelocal`
  ADD PRIMARY KEY (`IdDetalleLocal`),
  ADD KEY `fk_detalleLocal_locales1_idx` (`IdLocales`),
  ADD KEY `fk_detalleLocal_tipoEventos1_idx` (`TipoEventos`);

--
-- Indices de la tabla `tbdetestadoreservacion`
--
ALTER TABLE `tbdetestadoreservacion`
  ADD PRIMARY KEY (`IdEstadoReservacion`),
  ADD UNIQUE KEY `estado_UNIQUE` (`Estado`),
  ADD KEY `sss` (`resevacionHotelId`) USING BTREE;

--
-- Indices de la tabla `tbdetestadoreservacionrestaurante`
--
ALTER TABLE `tbdetestadoreservacionrestaurante`
  ADD PRIMARY KEY (`IdEstadoRestaurante`);

--
-- Indices de la tabla `tbdetgenero`
--
ALTER TABLE `tbdetgenero`
  ADD PRIMARY KEY (`IdGenero`),
  ADD UNIQUE KEY `genero_UNIQUE` (`Genero`);

--
-- Indices de la tabla `tbdetreservacionhotel`
--
ALTER TABLE `tbdetreservacionhotel`
  ADD PRIMARY KEY (`IdReservacionHotel`),
  ADD KEY `fk_resevacionHotel_clientes1_idx` (`IdClientes`),
  ADD KEY `fk_resevacionHotel_Habitaciones1_idx` (`IdHabitaciones`),
  ADD KEY `fk_resevacionHotel_detalleLocal1_idx` (`IdDetalleLocal`),
  ADD KEY `IdEstadoReservacion` (`IdEstadoReservacion`),
  ADD KEY `IdEstadoReservacion_2` (`IdEstadoReservacion`);

--
-- Indices de la tabla `tbdetreservacionrestaurante`
--
ALTER TABLE `tbdetreservacionrestaurante`
  ADD PRIMARY KEY (`IdReservacionRestaurante`),
  ADD KEY `fk_resevacionHotel_clientes1_idx` (`IdCliente`),
  ADD KEY `fk_resevacionRestaurante_estadoRestaurante1_idx` (`IdEstadoRestaurante`),
  ADD KEY `fk_resevacionRestaurante_Restaurante1_idx` (`IdRestaurante`);

--
-- Indices de la tabla `tbdettipodocumento`
--
ALTER TABLE `tbdettipodocumento`
  ADD PRIMARY KEY (`IdTipoDocumento`),
  ADD UNIQUE KEY `documento_UNIQUE` (`Documento`);

--
-- Indices de la tabla `tbdettipoempresa`
--
ALTER TABLE `tbdettipoempresa`
  ADD PRIMARY KEY (`IdTipoEmpresa`);

--
-- Indices de la tabla `tbdettipoeventos`
--
ALTER TABLE `tbdettipoeventos`
  ADD PRIMARY KEY (`IdTipoEventos`),
  ADD UNIQUE KEY `Evento_UNIQUE` (`Evento`);

--
-- Indices de la tabla `tbdettipohabitacion`
--
ALTER TABLE `tbdettipohabitacion`
  ADD PRIMARY KEY (`IdTipoHabitacion`),
  ADD UNIQUE KEY `tipoHabitacion_UNIQUE` (`TipoHabitacion`);

--
-- Indices de la tabla `tbdettipolocal`
--
ALTER TABLE `tbdettipolocal`
  ADD PRIMARY KEY (`IdTipoLocal`),
  ADD UNIQUE KEY `tipoLocal_UNIQUE` (`TipoLocal`);

--
-- Indices de la tabla `tbdettipousuarios`
--
ALTER TABLE `tbdettipousuarios`
  ADD PRIMARY KEY (`IdTipoUsuarios`);

--
-- Indices de la tabla `tbmaeclientes`
--
ALTER TABLE `tbmaeclientes`
  ADD PRIMARY KEY (`IdClientes`),
  ADD KEY `fk_clientes_genero1_idx` (`IdGenero`),
  ADD KEY `fk_clientes_estados1_idx` (`IdEstado`),
  ADD KEY `fk_clientes_usuarios1_idx` (`IdUsuario`),
  ADD KEY `fk_clientes_tipoDocumento1_idx` (`IdTipoDocumento`);

--
-- Indices de la tabla `tbmaeempresa`
--
ALTER TABLE `tbmaeempresa`
  ADD PRIMARY KEY (`IdEmpresa`),
  ADD KEY `IdTipoEmpresa` (`IdTipoEmpresa`);

--
-- Indices de la tabla `tbmaeestado`
--
ALTER TABLE `tbmaeestado`
  ADD PRIMARY KEY (`IdEstado`);

--
-- Indices de la tabla `tbmaehabitaciones`
--
ALTER TABLE `tbmaehabitaciones`
  ADD PRIMARY KEY (`IdHabitaciones`),
  ADD KEY `fk_Habitaciones_tipoHabitacion1_idx` (`IdTipoHabitacion`);

--
-- Indices de la tabla `tbmaelocales`
--
ALTER TABLE `tbmaelocales`
  ADD PRIMARY KEY (`IdLocales`),
  ADD KEY `fk_locales_tipoLocal1_idx` (`IdTipoLocal`);

--
-- Indices de la tabla `tbmaerestaurante`
--
ALTER TABLE `tbmaerestaurante`
  ADD PRIMARY KEY (`IdRestaurante`),
  ADD KEY `IdEstado` (`IdEstado`);

--
-- Indices de la tabla `tbmaeusuarios`
--
ALTER TABLE `tbmaeusuarios`
  ADD PRIMARY KEY (`IdUsuarios`),
  ADD UNIQUE KEY `usuario_UNIQUE` (`Usuario`),
  ADD KEY `fk_usuarios_tipoDocumento_idx` (`IdTipoDocumento`),
  ADD KEY `fk_usuarios_genero1_idx` (`IdGenero`),
  ADD KEY `fk_usuarios_estados1_idx` (`IdEstado`),
  ADD KEY `fk_usuarios_tipoUsuarios1_idx` (`IdTipoUsuarios`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tbdetdetallelocal`
--
ALTER TABLE `tbdetdetallelocal`
  MODIFY `IdDetalleLocal` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdetestadoreservacion`
--
ALTER TABLE `tbdetestadoreservacion`
  MODIFY `IdEstadoReservacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdetestadoreservacionrestaurante`
--
ALTER TABLE `tbdetestadoreservacionrestaurante`
  MODIFY `IdEstadoRestaurante` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdetgenero`
--
ALTER TABLE `tbdetgenero`
  MODIFY `IdGenero` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdettipodocumento`
--
ALTER TABLE `tbdettipodocumento`
  MODIFY `IdTipoDocumento` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdettipoempresa`
--
ALTER TABLE `tbdettipoempresa`
  MODIFY `IdTipoEmpresa` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdettipoeventos`
--
ALTER TABLE `tbdettipoeventos`
  MODIFY `IdTipoEventos` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdettipohabitacion`
--
ALTER TABLE `tbdettipohabitacion`
  MODIFY `IdTipoHabitacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdettipolocal`
--
ALTER TABLE `tbdettipolocal`
  MODIFY `IdTipoLocal` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbdettipousuarios`
--
ALTER TABLE `tbdettipousuarios`
  MODIFY `IdTipoUsuarios` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbmaeclientes`
--
ALTER TABLE `tbmaeclientes`
  MODIFY `IdClientes` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbmaeestado`
--
ALTER TABLE `tbmaeestado`
  MODIFY `IdEstado` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbmaehabitaciones`
--
ALTER TABLE `tbmaehabitaciones`
  MODIFY `IdHabitaciones` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbmaelocales`
--
ALTER TABLE `tbmaelocales`
  MODIFY `IdLocales` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbmaerestaurante`
--
ALTER TABLE `tbmaerestaurante`
  MODIFY `IdRestaurante` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbmaeusuarios`
--
ALTER TABLE `tbmaeusuarios`
  MODIFY `IdUsuarios` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tbdetdetallelocal`
--
ALTER TABLE `tbdetdetallelocal`
  ADD CONSTRAINT `fk_detalleLocal_locales1` FOREIGN KEY (`IdLocales`) REFERENCES `tbmaelocales` (`idlocales`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_detalleLocal_tipoEventos1` FOREIGN KEY (`TipoEventos`) REFERENCES `tbdettipoeventos` (`idtipoEventos`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbdetestadoreservacion`
--
ALTER TABLE `tbdetestadoreservacion`
  ADD CONSTRAINT `fk_estadoReservacion_resevacionHotel1` FOREIGN KEY (`resevacionHotelId`) REFERENCES `tbdetreservacionhotel` (`idreservacionHotel`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbdetreservacionhotel`
--
ALTER TABLE `tbdetreservacionhotel`
  ADD CONSTRAINT `fk_resevacionHotel_Habitaciones1` FOREIGN KEY (`IdHabitaciones`) REFERENCES `tbmaehabitaciones` (`idHabitaciones`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_resevacionHotel_clientes1` FOREIGN KEY (`IdClientes`) REFERENCES `tbmaeclientes` (`idclientes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_resevacionHotel_detalleLocal1` FOREIGN KEY (`IdDetalleLocal`) REFERENCES `tbdetdetallelocal` (`iddetalleLocal`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `tbdetreservacionhotel_ibfk_1` FOREIGN KEY (`IdEstadoReservacion`) REFERENCES `tbdetestadoreservacion` (`idestadoReservacion`);

--
-- Filtros para la tabla `tbdetreservacionrestaurante`
--
ALTER TABLE `tbdetreservacionrestaurante`
  ADD CONSTRAINT `fk_resevacionHotel_clientes10` FOREIGN KEY (`IdCliente`) REFERENCES `tbmaeclientes` (`idclientes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_resevacionRestaurante_Restaurante1` FOREIGN KEY (`IdRestaurante`) REFERENCES `tbmaerestaurante` (`idRestaurante`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_resevacionRestaurante_estadoRestaurante1` FOREIGN KEY (`IdEstadoRestaurante`) REFERENCES `tbdetestadoreservacionrestaurante` (`idestadoRestaurante`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbmaeclientes`
--
ALTER TABLE `tbmaeclientes`
  ADD CONSTRAINT `fk_clientes_estados1` FOREIGN KEY (`IdEstado`) REFERENCES `tbmaeestado` (`Idestado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_clientes_genero1` FOREIGN KEY (`IdGenero`) REFERENCES `tbdetgenero` (`idgenero`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_clientes_tipoDocumento1` FOREIGN KEY (`IdTipoDocumento`) REFERENCES `tbdettipodocumento` (`IdTipoDocumento`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_clientes_usuarios1` FOREIGN KEY (`IdUsuario`) REFERENCES `tbmaeusuarios` (`idusuarios`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbmaeempresa`
--
ALTER TABLE `tbmaeempresa`
  ADD CONSTRAINT `tbmaeempresa_ibfk_1` FOREIGN KEY (`IdTipoEmpresa`) REFERENCES `tbdettipoempresa` (`IdTipoEmpresa`);

--
-- Filtros para la tabla `tbmaehabitaciones`
--
ALTER TABLE `tbmaehabitaciones`
  ADD CONSTRAINT `fk_Habitaciones_tipoHabitacion1` FOREIGN KEY (`IdTipoHabitacion`) REFERENCES `tbdettipohabitacion` (`idtipoHabitacion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbmaelocales`
--
ALTER TABLE `tbmaelocales`
  ADD CONSTRAINT `fk_locales_tipoLocal1` FOREIGN KEY (`IdTipoLocal`) REFERENCES `tbdettipolocal` (`idtipoLocal`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbmaerestaurante`
--
ALTER TABLE `tbmaerestaurante`
  ADD CONSTRAINT `tbmaerestaurante_ibfk_1` FOREIGN KEY (`IdEstado`) REFERENCES `tbmaeestado` (`Idestado`);

--
-- Filtros para la tabla `tbmaeusuarios`
--
ALTER TABLE `tbmaeusuarios`
  ADD CONSTRAINT `fk_usuarios_estados1` FOREIGN KEY (`IdEstado`) REFERENCES `tbmaeestado` (`Idestado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_usuarios_genero1` FOREIGN KEY (`IdGenero`) REFERENCES `tbdetgenero` (`idgenero`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_usuarios_tipoDocumento` FOREIGN KEY (`IdTipoDocumento`) REFERENCES `tbdettipodocumento` (`IdTipoDocumento`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_usuarios_tipoUsuarios1` FOREIGN KEY (`IdTipoUsuarios`) REFERENCES `tbdettipousuarios` (`idtipoUsuarios`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
