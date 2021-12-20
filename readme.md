# <img width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" /> Medical Clinic Rest Api

<hr>

## About the project

<hr>

<p>    This project is originally from my data base class in the university. Its a work where we had to make a system with a graphic interface to manager the one of the data bases that was used along of the class. I arealdy did this work with some partners in TypeScript and its already here in my GitHub(<a src="https://github.com/posccis/medical-clinica-project">link</a>)</p>

## Goals

<hr>

<p>    Recently i finished a Resp API course with Asp.Net and i get truly excited to pratice what i learned. So my goal with this project don't include develop a view but just the Rest API of the system. I'm a back-end developer and i got to improve my back-end techniques so by now i'll only develop the API but in a near future i pretend to study a lil more about Angular to develop a MVC system.</p>

### So what's include in the project?

- Create Models Classes for each Table in the DB

- Create controllers for each Model

- Insid of each controllers create CRUD functions

- Create also functions with more complexity operations

- Lean how to connect the <img width="45" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mysql/mysql-original-wordmark.svg" /> Db to the Visual Studio 

- Learn how to manipulate the data from the MySql from the Visual Studio 

### Medico Controller

<hr>

##### Get - Return all the doctors
```
/api/Medico
```

##### Post - Create a doctor
```
/api/Medico
```
```Get
{
	"CodMed": 145,
	"NomeMed": "Joao",
	"Genero":"M",
	"Telefone": "81 999172990",
	"CodEspec": 2
}
```