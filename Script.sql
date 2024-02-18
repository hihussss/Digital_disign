create table if not exists Department (
	id SERIAL primary key,
	name varchar(100) 
);

create table if not exists Employee (
	id SERIAL primary key,
	department_id integer references Department(id),
	chief_id integer references Employee(id),
	name varchar(100),
	salary integer
);

insert into Department(name)
Values('Marketing'),
('Storage');

insert into Employee(department_id,chief_if,name,salary) values
(3,null,'Зинаида',45000),
(3,7,'Потап',25000),
(3,7,'Анатолий',25000);

--Сотрудника с максимальной заработной платой.
select * from employee 
order by salary desc 
limit 1;

--Вывести одно число: максимальную длину цепочки руководителей по таблице сотрудников (вычислить глубину дерева).
select max(count_s) from(
select s.name,count(s.name) count_s from employee s
inner join employee b on s.id = b.chief_if
group by s.name )




--Отдел, с максимальной суммарной зарплатой сотрудников
select d.name, sum(salary)  from department d
inner join employee e on d.id = e.department_id 
group by d.name
order by sum(salary) desc 
limit 1;

--Сотрудника, чье имя начинается на «Р» и заканчивается на «н».
select e.name from employee e 
where name ilike 'р%н'



