SELECT d.deptid 'Dept ID', d.name 'Dept', ISNULL(z.nre,0) '# Empl', ISNULL(z.nrm,0) '# Mgr' FROM Departments AS d CROSS JOIN (SELECT x.dept,x.nr nre,y.nr nrm FROM
	(SELECT dept, COUNT(empid) nr FROM Employees GROUP BY dept) AS x
	LEFT OUTER JOIN (SELECT dept, COUNT(empid) nr FROM Employees WHERE empid =ANY(SELECT DISTINCT mgr FROM Employees) GROUP BY dept) AS y ON x.dept = y.dept) AS z WHERE d.deptid = z.dept;

SELECT e.firstname 'First name',e.lastname 'Last name' FROM Employees AS e CROSS JOIN Departments AS d, Companies AS c WHERE e.dept = d.deptid AND d.company = c.companyid AND e.city <> c.city;

SELECT e.firstname 'First name',e.lastname 'Last name',s.skills '# of skills' FROM Employees AS e CROSS JOIN 
	(SELECT TOP(5) COUNT(*) skills,emp FROM SkillTable 
		WHERE skill =ANY(SELECT skillid FROM SkillSet WHERE name IN ('HTML','CSS','.NET','JavaScript','SQL')) GROUP BY emp ORDER BY 1 DESC) AS s WHERE s.emp = e.empid;

IF OBJECT_ID('GetEmpForMgr','IF') IS NOT NULL
	DROP FUNCTION GetEmpForMgr
GO
IF OBJECT_ID('GetAllEmp','IF') IS NOT NULL
	DROP FUNCTION GetAllEmp
GO

CREATE FUNCTION GetEmpForMgr
(
	@mgrid INT
)

RETURNS TABLE AS RETURN 
	(
	SELECT empid FROM Employees WHERE mgr = @mgrid
	)
GO

CREATE FUNCTION GetAllEmp (@mgrid INT)
	RETURNS TABLE AS RETURN
	(
		SELECT empid FROM GetEmpForMgr(@mgrid) UNION ALL SELECT x.empid FROM GetEmpForMgr(@mgrid) AS e CROSS APPLY GetEmpForMgr(e.empid) AS x
	)
GO

SELECT e.firstname 'First name', e.lastname 'Last name' FROM Employees AS e CROSS JOIN (SELECT * FROM GetAllEmp(1)) AS x WHERE e.empid = x.empid; 

SELECT e.firstname 'First name',e.lastname 'Last name',ISNULL(c.name,'- unemployed -') 'Company' FROM Employees AS e LEFT OUTER JOIN Departments AS d ON e.dept = d.deptid LEFT OUTER JOIN Companies c ON c.companyid = d.company;