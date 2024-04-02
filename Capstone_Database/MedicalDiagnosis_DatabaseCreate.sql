-- Capstone - Group 9
-- Created by: Justin Collier | 100345263
-- Date 2024-03-11
-- Purpose: Table creation script for TB patient detection database
USE master;

-- Database Create
DROP DATABASE IF EXISTS MD_DATABASE_TuberculosisDetection;
GO

CREATE DATABASE MD_DATABASE_TuberculosisDetection;
GO

-- 
-- Drop tables if they have already been instantiated in the DB. (Drop order matters due to dependencies)
DROP TABLE IF EXISTS tblDatabasePatient;
DROP TABLE IF EXISTS tblHospitalPatient;
DROP TABLE IF EXISTS tblDiagnosisCase;

-- Patient Table
CREATE TABLE tblPatient 
(
	-- ID with required range validation
	Patient_No		INT		UNIQUE  NOT NULL		CHECK(Patient_No BETWEEN 00001 AND 99999),
	-- Non-range constricted parameters
	Patient_Gender	VARCHAR(20)		NOT NULL,
	Date_Registered	DATE		        NOT NULL,
	-- Declaring the primary key
	PRIMARY KEY (Patient_No)
);

-- Dataset Patient Table
CREATE TABLE tblDatabasePatient 
(
	-- ID with required range validation
	Ds_Patient_No		INT		UNIQUE NOT NULL		CHECK(Ds_Patient_No BETWEEN 00001 AND 99999),
	-- Non-range constricted parameters
	Ds_Patient_Name	VARCHAR(20)		NOT NULL,	-- NOT NULL designates a required field
	-- Declaring the primary key
	PRIMARY KEY (Ds_Patient_No)
);

-- Hospital Patient Table
CREATE TABLE tblHospitalPatient 
(
	-- ID with required range validation
	H_Patient_No	    INT		UNIQUE NOT NULL		CHECK(H_Patient_No BETWEEN 00001 AND 99999),
	-- Non-range constricted parameters
	H_Patient_LName	    VARCHAR(20)		NOT NULL,	-- NOT NULL designates a required field
	H_Patient_FName	    VARCHAR(20)		NOT NULL,
	H_Patient_Address   VARCHAR(40)		NOT NULL,
	H_Patient_Phone	    VARCHAR(20)		NOT NULL,
	H_Date_Admitted	    DATE		        NOT NULL,
	-- Declaring the primary key
	PRIMARY KEY (H_Patient_No)
);

-- Diagnosis Case Table
CREATE TABLE tblDiagnosisCase 
(
	-- ID with required range validation
	D_Diagnosis_Id	    INT		UNIQUE NOT NULL		CHECK(D_Diagnosis_Id BETWEEN 00001 AND 99999),

	-- Non-range constricted parameters
	D_Fever_Two_Weeks   INT		NOT NULL CHECK(D_Fever_Two_Weeks BETWEEN 0 AND 1),	-- Check if value is a valid boolean (0 or 1)
	D_Coughing_Blood    INT		NOT NULL CHECK(D_Coughing_Blood BETWEEN 0 AND 1),	
	D_Bloody_Sputum	    INT		NOT NULL CHECK(D_Bloody_Sputum BETWEEN 0 AND 1),	
	D_Night_Sweats	    INT		NOT NULL CHECK(D_Night_Sweats BETWEEN 0 AND 1),	
	D_Chest_Pain	    INT		NOT NULL CHECK(D_Chest_Pain BETWEEN 0 AND 1),	
	D_Back_Pain	    INT		NOT NULL CHECK(D_Back_Pain BETWEEN 0 AND 1),
	D_Breath_Shortnes   INT		NOT NULL CHECK(D_Breath_Shortness BETWEEN 0 AND 1),	
	D_Weight_Loss	    INT		NOT NULL CHECK(D_Weight_Loss BETWEEN 0 AND 1),	
	D_Tiredness	    INT		NOT NULL CHECK(D_Tiredness BETWEEN 0 AND 1),	
	D_Neck_Pit_Lumps    INT		NOT NULL CHECK(D_Neck_Pit_Lumps BETWEEN 0 AND 1),	
	D_Cough_Phlegm	    INT		NOT NULL CHECK(D_Cough_Phlegm BETWEEN 0 AND 1),	
	D_Swollen_Lymph	    INT		NOT NULL CHECK(D_Swollen_Lymph BETWEEN 0 AND 1),	
	D_Apetite_Loss	    INT		NOT NULL CHECK(D_Apetite_Loss BETWEEN 0 AND 1),	
	D_Patient_No	    INT		UNIQUE NOT NULL		CHECK(D_Diagnosis_Id BETWEEN 00001 AND 99999),	
	-- Declaring the primary key
	PRIMARY KEY (D_Diagnosis_Id),
	-- Foreign key definition
	FOREIGN KEY (D_Patient_No) REFERENCES tblPatient (Patient_No)
);