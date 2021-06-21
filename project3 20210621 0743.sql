﻿--
-- Script was generated by Devart dbForge Studio 2019 for MySQL, Version 8.2.23.0
-- Product home page: http://www.devart.com/dbforge/mysql/studio
-- Script date 6/21/2021 7:43:04 AM
-- Server version: 5.5.5-10.4.19-MariaDB
-- Client version: 4.1
--

-- 
-- Disable foreign keys
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Set SQL mode
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE project3;

--
-- Drop procedure `ChangePassword`
--
DROP PROCEDURE IF EXISTS ChangePassword;

--
-- Drop procedure `DeleteEmployee`
--
DROP PROCEDURE IF EXISTS DeleteEmployee;

--
-- Drop procedure `GetEmployeeByID`
--
DROP PROCEDURE IF EXISTS GetEmployeeByID;

--
-- Drop procedure `InsertEmployee`
--
DROP PROCEDURE IF EXISTS InsertEmployee;

--
-- Drop procedure `LoginEmployee`
--
DROP PROCEDURE IF EXISTS LoginEmployee;

--
-- Drop procedure `UpdateEmployee`
--
DROP PROCEDURE IF EXISTS UpdateEmployee;

--
-- Drop table `employee`
--
DROP TABLE IF EXISTS employee;

--
-- Drop procedure `GetBillByID`
--
DROP PROCEDURE IF EXISTS GetBillByID;

--
-- Drop procedure `InsertBill`
--
DROP PROCEDURE IF EXISTS InsertBill;

--
-- Drop procedure `UpdateBill`
--
DROP PROCEDURE IF EXISTS UpdateBill;

--
-- Drop table `bill`
--
DROP TABLE IF EXISTS bill;

--
-- Drop procedure `GetProductByID`
--
DROP PROCEDURE IF EXISTS GetProductByID;

--
-- Drop procedure `InsertProduct`
--
DROP PROCEDURE IF EXISTS InsertProduct;

--
-- Drop procedure `UpdateProduct`
--
DROP PROCEDURE IF EXISTS UpdateProduct;

--
-- Drop table `product`
--
DROP TABLE IF EXISTS product;

--
-- Drop procedure `InsertCustomer`
--
DROP PROCEDURE IF EXISTS InsertCustomer;

--
-- Drop table `customer`
--
DROP TABLE IF EXISTS customer;

--
-- Set default database
--
USE project3;

--
-- Create table `customer`
--
CREATE TABLE customer (
  id char(36) DEFAULT NULL,
  customerName varchar(255) DEFAULT NULL,
  phoneNumber varchar(20) DEFAULT NULL,
  address varchar(255) DEFAULT NULL,
  createDate datetime DEFAULT NULL,
  modifiedDate datetime DEFAULT NULL,
  createBy varchar(255) DEFAULT NULL,
  modifiedBy varchar(255) DEFAULT NULL,
  gender varchar(5) DEFAULT NULL,
  isDelete tinyint(1) DEFAULT NULL
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

DELIMITER $$

--
-- Create procedure `InsertCustomer`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE InsertCustomer (IN customerName nvarchar(255), IN address nvarchar(255), IN phoneNumber varchar(20), IN createBy nvarchar(255), IN gender varchar(5))
BEGIN
  INSERT customer (id, customerName, address, phoneNumber, createDate, modifiedDate, createBy, modifiedBy, gender, isDelete)
    VALUES (UUID(), customerName, address, phoneNumber, NOW(), NOW(), createBy, createBy, gender, 0);

END
$$

DELIMITER ;

--
-- Create table `product`
--
CREATE TABLE product (
  id char(36) NOT NULL,
  productName varchar(255) DEFAULT NULL,
  category varchar(10) DEFAULT NULL,
  productCode varchar(20) DEFAULT NULL,
  priceOut int(11) DEFAULT NULL,
  priceIn int(11) DEFAULT NULL,
  quantity int(11) DEFAULT NULL,
  image varchar(255) DEFAULT NULL,
  createBy varchar(255) DEFAULT NULL,
  createDate datetime DEFAULT NULL,
  modifiedBy varchar(255) DEFAULT NULL,
  modifiedDate datetime DEFAULT NULL,
  isDelete tinyint(1) DEFAULT 0,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 2730,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

DELIMITER $$

--
-- Create procedure `UpdateProduct`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE UpdateProduct (IN id char(36), IN productName nvarchar(255), IN category varchar(10), IN priceOut int, IN priceIn int, IN quantity int, IN image varchar(255), IN createBy nvarchar(255))
BEGIN
  UPDATE product p
  SET p.category = category,
      p.productName = productName,
      p.priceOut = priceOut,
      p.priceIn = priceIn,
      p.quantity = quantity,
      p.image = image,
      p.modifiedBy = p.modifiedBy,
      p.modifiedDate = NOW()
  WHERE p.id = id;
END
$$

--
-- Create procedure `InsertProduct`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE InsertProduct (IN productName nvarchar(255), IN category varchar(10), IN productCode varchar(20), IN priceOut int, IN priceIn int, IN quantity int, IN image varchar(255), IN createBy nvarchar(255))
BEGIN

  INSERT product (id, productName, category, productCode, priceOut, priceIn, quantity, image, createBy, createDate, modifiedBy, modifiedDate, isDelete)
    VALUES (UUID(), productName, category, productCode, priceOut, priceIn, quantity, image, createBy, NOW(), createBy, NOW(), 0);


END
$$

--
-- Create procedure `GetProductByID`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE GetProductByID (IN ID char(36))
BEGIN
  SELECT
    *
  FROM product p
  WHERE p.id = ID;
END
$$

DELIMITER ;

--
-- Create table `bill`
--
CREATE TABLE bill (
  id char(36) DEFAULT NULL,
  product varchar(255) DEFAULT NULL,
  customerID char(36) DEFAULT NULL,
  amount int(11) DEFAULT NULL,
  promotion int(11) DEFAULT NULL,
  createBy varchar(255) DEFAULT NULL,
  createDate datetime DEFAULT NULL,
  modifiedBy varchar(255) DEFAULT NULL,
  modifiedDate datetime DEFAULT NULL,
  isDelete tinyint(1) DEFAULT 0,
  billCode varchar(20) DEFAULT NULL,
  customerName varchar(255) DEFAULT NULL,
  status varchar(10) DEFAULT NULL,
  description varchar(255) DEFAULT NULL
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 2730,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

DELIMITER $$

--
-- Create procedure `UpdateBill`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE UpdateBill (IN id char(36), IN status varchar(10), IN description varchar(255))
BEGIN
  UPDATE bill b
  SET b.status = status,
      b.description = description
  WHERE b.id = id;
END
$$

--
-- Create procedure `InsertBill`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE InsertBill (IN BillCode varchar(20), IN CustomerID char(36), IN CustomerName varchar(255), IN Amount int, IN Promotion int, IN Product varchar(255), IN CreateBy varchar(255), IN id char(36))
BEGIN
  INSERT bill (id, product, customerID, amount, promotion, createBy, createDate, modifiedBy, modifiedDate, isDelete, billCode, customerName, status)
    VALUES (id, Product, CustomerID, Amount, Promotion, CreateBy, NOW(), CreateBy, NOW(), 0, BillCode, CustomerName, '1');
END
$$

--
-- Create procedure `GetBillByID`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE GetBillByID (IN ID char(36))
BEGIN
  SELECT
    *
  FROM bill b
  WHERE b.id = ID;
END
$$

DELIMITER ;

--
-- Create table `employee`
--
CREATE TABLE employee (
  id char(36) DEFAULT NULL,
  employeeCode varchar(20) DEFAULT NULL,
  fullName varchar(255) DEFAULT NULL,
  `position` varchar(10) DEFAULT NULL,
  status varchar(10) DEFAULT NULL,
  address varchar(255) DEFAULT NULL,
  phoneNumber varchar(20) DEFAULT NULL,
  image varchar(255) DEFAULT NULL,
  dateOfBirth datetime DEFAULT NULL,
  gender varchar(5) DEFAULT NULL,
  email varchar(100) DEFAULT NULL,
  identityCardNumber varchar(20) DEFAULT NULL,
  issuePlace varchar(255) DEFAULT NULL,
  issueDate datetime DEFAULT NULL,
  taxcode varchar(20) DEFAULT NULL,
  joinDate datetime DEFAULT NULL,
  basicSalary int(11) DEFAULT NULL,
  isDelete tinyint(1) DEFAULT NULL,
  createDate datetime DEFAULT NULL,
  modifiedDate datetime DEFAULT NULL,
  createBy varchar(255) DEFAULT NULL,
  modifiedBy varchar(255) DEFAULT NULL,
  password varchar(255) DEFAULT NULL
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 1024,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

DELIMITER $$

--
-- Create procedure `UpdateEmployee`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE UpdateEmployee (IN id char(36), IN fullName nvarchar(255), IN `position` varchar(10), IN status varchar(10), IN address nvarchar(255), IN phoneNumber varchar(20), IN image varchar(255), IN dateOfBirth datetime, IN gender varchar(5), IN email varchar(100), IN identityCardNumber varchar(20), IN issuePlace nvarchar(255), IN issueDate datetime, IN taxcode varchar(20), IN joinDate datetime, IN basicSalary int, IN modifiedBy nvarchar(255))
BEGIN
  UPDATE employee e
  SET e.fullName = fullName,
      e.`position` = `position`,
      e.status = status,
      e.address = address,
      e.phoneNumber = phoneNumber,
      e.image = image,
      e.dateOfBirth = dateOfBirth,
      e.gender = gender,
      e.email = email,
      e.identityCardNumber = identityCardNumber,
      e.issuePlace = issuePlace,
      e.issueDate = issueDate,
      e.taxcode = taxcode,
      e.joinDate = joinDate,
      e.basicSalary = basicSalary,
      e.modifiedDate = NOW(),
      e.modifiedBy = e.modifiedBy
  WHERE e.id = id;
END
$$

--
-- Create procedure `LoginEmployee`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE LoginEmployee (IN email varchar(100), IN password varchar(255))
BEGIN
  SELECT
    *
  FROM employee e
  WHERE e.isDelete = 0
  AND e.email = email
  AND e.password = password;
END
$$

--
-- Create procedure `InsertEmployee`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE InsertEmployee (IN employeeCode varchar(20), IN fullName nvarchar(255), IN `position` varchar(10), IN status varchar(10), IN address nvarchar(255), IN phoneNumber varchar(20), IN image varchar(255), IN dateOfBirth datetime, IN gender varchar(5), IN email varchar(100), IN identityCardNumber varchar(20), IN issuePlace nvarchar(255), IN issueDate datetime, IN taxcode varchar(20), IN joinDate datetime, IN basicSalary int, IN createBy nvarchar(255))
BEGIN
  INSERT employee (id, employeeCode, fullName, `position`, status, address, phoneNumber, image, dateOfBirth, gender, email, identityCardNumber, issuePlace, issueDate, taxcode, joinDate, basicSalary, createDate, modifiedDate, createBy, modifiedBy, isDelete, password)
    VALUES (UUID(), employeeCode, fullName, `position`, status, address, phoneNumber, image, dateOfBirth, gender, email, identityCardNumber, issuePlace, issueDate, taxcode, NOW(), basicSalary, NOW(), NOW(), createBy, createBy, 0, 'e10adc3949ba59abbe56e057f20f883e');

END
$$

--
-- Create procedure `GetEmployeeByID`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE GetEmployeeByID (IN ID char(36))
BEGIN
  SELECT
    *
  FROM employee e
  WHERE e.id = ID;
END
$$

--
-- Create procedure `DeleteEmployee`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE DeleteEmployee (IN id char(36))
BEGIN
  UPDATE employee e
  SET e.isDelete = 1
  WHERE e.id = id;
END
$$

--
-- Create procedure `ChangePassword`
--
CREATE DEFINER = 'root'@'localhost'
PROCEDURE ChangePassword (IN email varchar(100), IN password varchar(255))
BEGIN
  UPDATE employee e
  SET e.password = password
  WHERE e.email = email;
END
$$

DELIMITER ;

-- 
-- Dumping data for table product
--
INSERT INTO product VALUES
('3716227b-cc1d-11eb-99d4-f48e38e77fbf', 'Quần nữ', '1', 'SP0005', 300000, 40000, 155, 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/default.jpg?alt=media&token=07b6997c-7186-45d3-923b-84211832140a', NULL, '2021-06-13 14:58:58', NULL, '2021-06-13 14:58:58', 0),
('7b80a11c-cc1d-11eb-99d4-f48e38e77fbf', 'Mũ cối', '3', 'SP0006', 32000, 12000, 109, 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/default.jpg?alt=media&token=07b6997c-7186-45d3-923b-84211832140a', NULL, '2021-06-13 15:00:52', NULL, '2021-06-13 15:00:52', 0),
('b0601f1d-c956-11eb-9a69-f48e38e77fbf', 'Áo dài nam', '2', 'SP0001', 500000, 50000, 182, 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=095b48b0-3172-4483-8054-be0002add8a8', NULL, '2021-06-10 02:12:34', NULL, '2021-06-10 02:12:34', 0),
('c144f215-c956-11eb-9a69-f48e38e77fbf', 'Mũ len hiệu XX', '3', 'SP0002', 250000, 25000, 241, 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/mu.jpg?alt=media&token=64bcef30-a02d-41a5-9026-5c24a11ceeba', NULL, '2021-06-10 02:13:03', NULL, '2021-06-10 02:13:03', 0),
('ce5648c3-c956-11eb-9a69-f48e38e77fbf', 'Quần hiệu con bò 2', '1', 'SP0003', 150000, 110000, 213, 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/quan.jpg?alt=media&token=d776de20-148d-4323-b8d0-db8b79996e1b', NULL, '2021-06-10 02:13:24', NULL, '2021-06-11 00:13:33', 0),
('ce59df4b-cc1c-11eb-99d4-f48e38e77fbf', 'Áo len nam', '2', 'SP0004', 30000, 15000, 222, 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/default.jpg?alt=media&token=07b6997c-7186-45d3-923b-84211832140a', NULL, '2021-06-13 14:56:02', NULL, '2021-06-13 14:56:02', 0);

-- 
-- Dumping data for table employee
--
INSERT INTO employee VALUES
('96bae817-c878-11eb-9a69-f48e38e77fbf', 'NV0001', 'Trần quốc An', '2', '1', 'test vui là chính', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-16 00:00:00', '0', 'tranquocanh1999@gmail.com', '184366429', 'Hà Tĩnh', '2021-06-01 00:00:00', '03622666', '2021-06-08 23:42:53', 10000000, 0, '2021-06-08 23:42:53', '2021-06-10 01:19:40', NULL, NULL, 'D2F2E904888ADD0D66789B7CB4F4D7C3'),
('9f3f4320-c947-11eb-9a69-f48e38e77fbf', 'NV0002', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a1@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:24:43', 100000, 0, '2021-06-10 00:24:43', '2021-06-10 00:24:43', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('a4d22d18-c947-11eb-9a69-f48e38e77fbf', 'NV0003', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a2@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:24:52', 100000, 0, '2021-06-10 00:24:52', '2021-06-10 00:24:52', NULL, NULL, 'FCEA920F7412B5DA7BE0CF42B8C93759'),
('b1d6394d-c947-11eb-9a69-f48e38e77fbf', 'NV0004', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a3@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:14', 100000, 0, '2021-06-10 00:25:14', '2021-06-10 00:25:14', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('b5b77eaa-c947-11eb-9a69-f48e38e77fbf', 'NV0005', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a4@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:21', 100000, 0, '2021-06-10 00:25:21', '2021-06-10 00:25:21', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('b98cbe39-c947-11eb-9a69-f48e38e77fbf', 'NV0006', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a5@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:27', 100000, 0, '2021-06-10 00:25:27', '2021-06-10 00:25:27', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('bd449c7a-c947-11eb-9a69-f48e38e77fbf', 'NV0007', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a6@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:33', 100000, 0, '2021-06-10 00:25:33', '2021-06-10 00:25:33', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('c09375ab-c947-11eb-9a69-f48e38e77fbf', 'NV0008', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a7@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:39', 100000, 0, '2021-06-10 00:25:39', '2021-06-10 00:25:39', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('c3c248b6-c947-11eb-9a69-f48e38e77fbf', 'NV0009', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a8@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:44', 100000, 0, '2021-06-10 00:25:44', '2021-06-10 00:25:44', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('c72fa775-c947-11eb-9a69-f48e38e77fbf', 'NV0010', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a9@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:50', 100000, 0, '2021-06-10 00:25:50', '2021-06-10 00:25:50', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('ca68355e-c947-11eb-9a69-f48e38e77fbf', 'NV0011', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a10@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:25:55', 100000, 0, '2021-06-10 00:25:55', '2021-06-10 00:25:55', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('cd8d6163-c947-11eb-9a69-f48e38e77fbf', 'NV0012', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a11@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:26:01', 100000, 0, '2021-06-10 00:26:01', '2021-06-10 00:26:01', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('d148b9af-c947-11eb-9a69-f48e38e77fbf', 'NV0013', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a12@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:26:07', 100000, 0, '2021-06-10 00:26:07', '2021-06-10 00:26:07', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('d4db725d-c947-11eb-9a69-f48e38e77fbf', 'NV0014', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a13@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:26:13', 100000, 0, '2021-06-10 00:26:13', '2021-06-10 00:26:13', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('d8787a63-c947-11eb-9a69-f48e38e77fbf', 'NV0015', 'Trần Quốc Anh', '1', '1', '98 Khâm Thiên, Đống Đa , Hà Nội', '0369556805', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/ao.jpg?alt=media&token=9d844ac9-0d05-412d-be3c-4f61f632da3e', '2021-06-01 00:24:08', '1', 'a14@gmail.com', '184366428', 'Hà Tĩnh', '2021-06-07 00:24:27', '123456789', '2021-06-10 00:26:19', 100000, 0, '2021-06-10 00:26:19', '2021-06-10 00:26:19', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e'),
('c837c5d9-c950-11eb-9a69-f48e38e77fbf', 'NV0016', 'Trần Thị B', '2', '1', 'Tố Hữu, Hà Đông, Hà Nội', '0369556807', 'https://firebasestorage.googleapis.com/v0/b/project3-9450a.appspot.com/o/blank-profile-picture-973460_640.png?alt=media&token=9a1c847b-fc0c-4594-8c7f-54ac21115c37', '2021-07-01 00:00:00', '0', 'b@gmail.com', '131414141', 'Hà Tiên', '2021-06-03 00:00:00', '62122', '2021-06-10 01:30:17', 13131233, 0, '2021-06-10 01:30:17', '2021-06-10 01:30:17', NULL, NULL, 'e10adc3949ba59abbe56e057f20f883e');

-- 
-- Dumping data for table customer
--
INSERT INTO customer VALUES
('ed746146-cc4b-11eb-99d4-f48e38e77fbf', 'Trần Quốc Anh', '0369556805', NULL, '2021-06-13 20:33:20', '2021-06-13 20:33:20', NULL, NULL, '0', 0),
('f5a6ca6b-cc4b-11eb-99d4-f48e38e77fbf', 'Trần Quốc Bảo', '0369556806', NULL, '2021-06-13 20:33:34', '2021-06-13 20:33:34', NULL, NULL, '0', 0),
('4ac99626-cc60-11eb-99d4-f48e38e77fbf', 'Trần Quốc Chiến', '0369556807', NULL, '2021-06-13 22:59:07', '2021-06-13 22:59:07', NULL, NULL, NULL, 0),
('244aed00-cc6e-11eb-99d4-f48e38e77fbf', 'Nguyễn Thị C', '036958682', NULL, '2021-06-14 00:38:15', '2021-06-14 00:38:15', NULL, NULL, NULL, 0),
('cd67506d-cc6e-11eb-99d4-f48e38e77fbf', 'Cao Thị D', '036956852', NULL, '2021-06-14 00:42:59', '2021-06-14 00:42:59', NULL, NULL, NULL, 0),
('00b8ef28-cc6f-11eb-99d4-f48e38e77fbf', 'Thái Thị H', '0325685245', NULL, '2021-06-14 00:44:25', '2021-06-14 00:44:25', NULL, NULL, NULL, 0);

-- 
-- Dumping data for table bill
--
INSERT INTO bill VALUES
('8bba41d2-4113-4919-a703-4ac24d185009', '{"ce5648c3-c956-11eb-9a69-f48e38e77fbf":{"price":150000,"quantity":1}}', 'f5a6ca6b-cc4b-11eb-99d4-f48e38e77fbf', 150000, 0, NULL, '2021-06-14 05:45:09', NULL, '2021-06-14 05:45:09', 0, 'RB0002', 'Trần Quốc Bảo', '1', NULL),
('a2a8e072-4ecc-41fe-9029-7040e7164a73', '{"c144f215-c956-11eb-9a69-f48e38e77fbf":{"price":250000,"quantity":1}}', 'f5a6ca6b-cc4b-11eb-99d4-f48e38e77fbf', 250000, 249500, NULL, '2021-06-14 23:33:53', NULL, '2021-06-14 23:33:53', 0, 'RB0003', 'Trần Quốc Bảo', '1', NULL),
('d6ffa317-b934-47db-b6d6-baad95096ffb', '{"3716227b-cc1d-11eb-99d4-f48e38e77fbf":{"price":300000,"quantity":1}}', 'f5a6ca6b-cc4b-11eb-99d4-f48e38e77fbf', 300000, 0, NULL, '2021-06-21 00:13:49', NULL, '2021-06-21 00:13:49', 0, 'RB0004', 'Trần Quốc Bảo', '1', NULL),
('6bece2db-d194-407c-8b29-38ad2521a1ba', '{"3716227b-cc1d-11eb-99d4-f48e38e77fbf":{"price":300000,"quantity":1}}', 'f5a6ca6b-cc4b-11eb-99d4-f48e38e77fbf', 300000, 0, NULL, '2021-06-21 00:14:56', NULL, '2021-06-21 00:14:56', 0, 'RB0005', 'Trần Quốc Bảo', '1', NULL),
('e52eb217-20b7-40a8-a043-bb9a80915bde', '{"3716227b-cc1d-11eb-99d4-f48e38e77fbf":{"price":300000,"quantity":1}}', 'ed746146-cc4b-11eb-99d4-f48e38e77fbf', 300000, 0, NULL, '2021-06-21 02:30:27', NULL, '2021-06-21 02:30:27', 0, 'RB0006', 'Trần Quốc Anh', '2', 'Đơn hàng đã bị huỷ bỏ');

-- 
-- Restore previous SQL mode
-- 
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Enable foreign keys
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;