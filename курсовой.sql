CREATE DATABASE SPACETRAVEL;

USE SPACETRAVEL;

drop table tours;
drop table spaceships;
drop table missions;
drop table service;
drop table users;
drop table booking;
drop table administrator;

CREATE TABLE TOURS(
	IDtours int not null CONSTRAINT PK_IDtours primary key(IDtours),
	Name nvarchar(30) not null,
	Description nvarchar(300) not null,
	Address nvarchar(30) not null, 
	Type nvarchar(15) not null,
	Date smalldatetime not null,
	Price real not null,
	Image nvarchar(30) not null,
	IsActive bit not null
)

CREATE TABLE SPACESHIPS(
	IDspaceships int not null CONSTRAINT PK_IDspaceships primary key(IDspaceships),
	Name nvarchar(30) not null,
	Description nvarchar(300) not null,
	Capacity smallint not null,
	Heigth float not null,
	Diameter float not null,
	PayloadCapacity float not null
)

CREATE TABLE MISSIONS(
	IDmissions int not null CONSTRAINT PK_IDmissions primary key(IDmissions),
	Name nvarchar(30) not null,
	Description nvarchar(300) not null,	
	Duration smallint not null,
	Altitude int not null,
	Price real not null,
	Spaceship int not null CONSTRAINT FK_IDSpaceship foreign key references SPACESHIPS(IDspaceships)
)

CREATE TABLE USERS(
	IDusers int not null CONSTRAINT PK_IDusers primary key(IDusers),
	Login nvarchar(20) not null,
	Password nvarchar(20) not null,
	Email nvarchar(30) not null,
	Fname nvarchar(20) not null,
	Sname nvarchar(20) not null
)

CREATE TABLE BOOKING(
	IDbooking int not null CONSTRAINT PK_IDbooking primary key(IDbooking),
	UserId int not null,
	Name varchar(30) not null,
	Tour int CONSTRAINT FK_IDtours foreign key references TOURS(IDtours),
	Mission int CONSTRAINT FK_IDmissions foreign key references MISSIONS(IDmissions),
	Date smalldatetime not null,
	Price real not null,
	IsActive bit not null,
	IsApproved bit not null
)

CREATE TABLE ADMINISTRATOR(
	IDadmin int not null CONSTRAINT PK_IDadmin primary key(IDadmin),
	Login nvarchar(20) not null,
	Password nvarchar(20) not null,
	Email nvarchar(30) not null,
	Fname nvarchar(20) not null,
	Sname nvarchar(20) not null
)