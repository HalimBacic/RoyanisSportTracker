-- MySQL Script generated by MySQL Workbench
-- Thu May 23 21:26:54 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema SportTracker
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema SportTracker
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SportTracker` DEFAULT CHARACTER SET utf8 ;
USE `SportTracker` ;

-- -----------------------------------------------------
-- Table `SportTracker`.`Activity`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `SportTracker`.`Activity` ;

CREATE TABLE IF NOT EXISTS `SportTracker`.`Activity` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  `Description` VARCHAR(45) NULL,
  `Date` DATETIME NULL,
  `Duration` INT NULL,
  `ActivityType_Id` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Activity_ActivityType_idx` (`ActivityType_Id` ASC) VISIBLE,
  CONSTRAINT `fk_Activity_ActivityType`
    FOREIGN KEY (`ActivityType_Id`)
    REFERENCES `SportTracker`.`ActivityType` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportTracker`.`ActivityType`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `SportTracker`.`ActivityType` ;

CREATE TABLE IF NOT EXISTS `SportTracker`.`ActivityType` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportTracker`.`User`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `SportTracker`.`User` ;

CREATE TABLE IF NOT EXISTS `SportTracker`.`User` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(45) NULL,
  `Password` VARCHAR(45) NULL,
  `Email` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Username_UNIQUE` (`Username` ASC) VISIBLE,
  UNIQUE INDEX `Password_UNIQUE` (`Password` ASC) VISIBLE,
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportTracker`.`User_has_Activity`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `SportTracker`.`User_has_Activity` ;

CREATE TABLE IF NOT EXISTS `SportTracker`.`User_has_Activity` (
  `User_Id` INT NOT NULL,
  `Activity_Id` INT NOT NULL,
  PRIMARY KEY (`User_Id`, `Activity_Id`),
  INDEX `fk_User_has_Activity_Activity1_idx` (`Activity_Id` ASC) VISIBLE,
  INDEX `fk_User_has_Activity_User1_idx` (`User_Id` ASC) VISIBLE,
  CONSTRAINT `fk_User_has_Activity_User1`
    FOREIGN KEY (`User_Id`)
    REFERENCES `SportTracker`.`User` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_User_has_Activity_Activity1`
    FOREIGN KEY (`Activity_Id`)
    REFERENCES `SportTracker`.`Activity` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportTracker`.`User_has_target`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `SportTracker`.`User_has_target` ;

CREATE TABLE IF NOT EXISTS `SportTracker`.`User_has_target` (
  `User_Id` INT NOT NULL,
  `Activity_Id` INT NOT NULL,
  `Date` DATE NULL,
  `Type` ENUM('TimePerDay', 'DurationPerDay') NULL,
  PRIMARY KEY (`User_Id`, `Activity_Id`),
  INDEX `fk_User_has_Activity1_Activity1_idx` (`Activity_Id` ASC) VISIBLE,
  INDEX `fk_User_has_Activity1_User1_idx` (`User_Id` ASC) VISIBLE,
  CONSTRAINT `fk_User_has_Activity1_User1`
    FOREIGN KEY (`User_Id`)
    REFERENCES `SportTracker`.`User` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_User_has_Activity1_Activity1`
    FOREIGN KEY (`Activity_Id`)
    REFERENCES `SportTracker`.`Activity` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
