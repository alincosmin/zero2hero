DELETE FROM SkillTable;
DELETE FROM SkillSet;
DELETE FROM Employees;
DELETE FROM Departments;
DELETE FROM Companies;
DELETE FROM Cities;

DBCC CHECKIDENT('Employees',RESEED,0);
DBCC CHECKIDENT('Departments',RESEED,0);
DBCC CHECKIDENT('Companies',RESEED,0);
DBCC CHECKIDENT('Cities',RESEED,0);
DBCC CHECKIDENT('SkillSet',RESEED,0);
DBCC CHECKIDENT('SkillTable',RESEED,0);

INSERT INTO Cities(name) VALUES('Iasi');
INSERT INTO Cities(name) VALUES('Bucharest');
INSERT INTO Cities(name) VALUES('Cluj');
INSERT INTO Cities(name) VALUES('Bacau');
INSERT INTO Cities(name) VALUES('Focsani');
INSERT INTO Cities(name) VALUES('Timisoara');

INSERT INTO Companies(name,city) VALUES('TeamNet',1);
INSERT INTO Companies(name,city) VALUES('TeamNet',2);
INSERT INTO Companies(name,city) VALUES('Kaspersky',2);
INSERT INTO Companies(name,city) VALUES('Bitdefender',3);
INSERT INTO Companies(name,city) VALUES('Centric',1);

INSERT INTO Departments(name,company) VALUES('Testing',1);
INSERT INTO Departments(name,company) VALUES('Testing',2);
INSERT INTO Departments(name,company) VALUES('Testing',3);
INSERT INTO Departments(name,company) VALUES('Testing',4);
INSERT INTO Departments(name,company) VALUES('Testing',5);
INSERT INTO Departments(name,company) VALUES('Web',1);
INSERT INTO Departments(name,company) VALUES('Web',2);
INSERT INTO Departments(name,company) VALUES('Web',5);
INSERT INTO Departments(name,company) VALUES('Sales',3);
INSERT INTO Departments(name,company) VALUES('Sales',4);

INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Andrei','Popescu',1,6);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Alex','Radu',4,3);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Cristina','Marcu',4,1);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('George','Zbantu',2,4);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Mihaela','Cristea',3,5);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Mihaela','Popovici',3,9);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Ioana','Bulai',1,9);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Mihai','Ajudeanu',2,10);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Alin','Damaceanu',6,7);
INSERT INTO Employees(firstname,lastname,city,dept) VALUES('Ionut','Lazar',3,5);
INSERT INTO Employees(firstname,lastname,city) VALUES('John','Doe',3);

UPDATE Employees SET mgr = 1 WHERE empid = 2;
UPDATE Employees SET mgr = 1 WHERE empid = 3;
UPDATE Employees SET mgr = 2 WHERE empid = 4;
UPDATE Employees SET mgr = 2 WHERE empid = 5;
UPDATE Employees SET mgr = 3 WHERE empid = 6;
UPDATE Employees SET mgr = 3 WHERE empid = 7;

INSERT INTO SkillSet(name) VALUES('HTML');
INSERT INTO SkillSet(name) VALUES('CSS');
INSERT INTO SkillSet(name) VALUES('JavaScript');
INSERT INTO SkillSet(name) VALUES('.NET');
INSERT INTO SkillSet(name) VALUES('PHP');
INSERT INTO SkillSet(name) VALUES('C++');
INSERT INTO SkillSet(name) VALUES('Java');

INSERT INTO SkillTable(skill,emp) VALUES(1,1);
INSERT INTO SkillTable(skill,emp) VALUES(2,2);
INSERT INTO SkillTable(skill,emp) VALUES(3,1);
INSERT INTO SkillTable(skill,emp) VALUES(2,3);
INSERT INTO SkillTable(skill,emp) VALUES(4,4);
INSERT INTO SkillTable(skill,emp) VALUES(1,4);
INSERT INTO SkillTable(skill,emp) VALUES(4,3);
INSERT INTO SkillTable(skill,emp) VALUES(5,7);
INSERT INTO SkillTable(skill,emp) VALUES(6,9);
INSERT INTO SkillTable(skill,emp) VALUES(1,6);
INSERT INTO SkillTable(skill,emp) VALUES(2,4);
INSERT INTO SkillTable(skill,emp) VALUES(3,3);
INSERT INTO SkillTable(skill,emp) VALUES(4,2);
INSERT INTO SkillTable(skill,emp) VALUES(1,7);
INSERT INTO SkillTable(skill,emp) VALUES(4,8);
INSERT INTO SkillTable(skill,emp) VALUES(5,1);
INSERT INTO SkillTable(skill,emp) VALUES(6,3);
