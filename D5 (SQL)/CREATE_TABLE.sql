IF OBJECT_ID('SkillTable') IS NOT NULL
	DROP TABLE SkillTable

IF OBJECT_ID('SkillSet') IS NOT NULL
	DROP TABLE SkillSet

IF OBJECT_ID('Employees') IS NOT NULL
	DROP TABLE Employees

IF OBJECT_ID('Departments') IS NOT NULL
	DROP TABLE Departments

IF OBJECT_ID('Companies') IS NOT NULL
	DROP TABLE Companies

IF OBJECT_ID('Cities') IS NOT NULL
	DROP TABLE Cities


CREATE TABLE SkillSet
(
	skillid INT IDENTITY(1,1) NOT NULL,
	name NVARCHAR(10) NOT NULL DEFAULT('')
	CONSTRAINT PK_SkillSet PRIMARY KEY(skillid)
)

CREATE TABLE Cities
(
	cityid INT IDENTITY(1,1) NOT NULL,
	name NVARCHAR(100) NOT NULL DEFAULT('')
	CONSTRAINT PK_Cities PRIMARY KEY(cityid)
)

CREATE TABLE Companies
(
	companyid INT IDENTITY(1,1) NOT NULL,
	name NVARCHAR(100) NOT NULL DEFAULT(''),
	city INT NOT NULL,
	CONSTRAINT PK_Companies PRIMARY KEY(companyid),
	CONSTRAINT FK_Cities_Companies FOREIGN KEY(city) REFERENCES Cities(cityid)
)

CREATE TABLE Departments
(
	deptid INT IDENTITY(1,1) NOT NULL,
	name NVARCHAR(100) NOT NULL DEFAULT(''),
	company INT NOT NULL,
	CONSTRAINT PK_Departments PRIMARY KEY(deptid),
	CONSTRAINT FK_Companies_Departments FOREIGN KEY(company) REFERENCES Companies(companyid)
)

CREATE TABLE Employees
(
	empid INT IDENTITY(1,1) NOT NULL,
	firstname NVARCHAR(50) NOT NULL DEFAULT(''),
	lastname NVARCHAR(50) NOT NULL DEFAULT(''),
	city INT NOT NULL,
	dept INT,
	mgr INT,
	CONSTRAINT PK_Employees PRIMARY KEY(empid),
	CONSTRAINT FK_Cities_Employees FOREIGN KEY(city) REFERENCES Cities(cityid),
	CONSTRAINT FK_Departments_Employees FOREIGN KEY(dept) REFERENCES Departments(deptid),
	CONSTRAINT FK_Employees_Employees FOREIGN KEY(mgr) REFERENCES Employees(empid)
) 

CREATE TABLE SkillTable
(
	listid INT IDENTITY(1,1) NOT NULL,
	skill INT NOT NULL,
	emp INT NOT NULL,
	CONSTRAINT PK_SkillTable PRIMARY KEY(listid),
	CONSTRAINT FK_SkillSet_SkillTable FOREIGN KEY(skill) REFERENCES SkillSet(skillid),
	CONSTRAINT FK_Employees_SkillTable FOREIGN KEY(emp) REFERENCES Employees(empid)
)
