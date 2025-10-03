<h1 align="center">🚀 Minimal API - Sistema de Administração e Veículos</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white" alt=".NET">
  <img src="https://img.shields.io/badge/C%23-Developer-239120?logo=c-sharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/Entity%20Framework-Core-512BD4" alt="Entity Framework">
  <img src="https://img.shields.io/badge/MySQL-Database-4479A1?logo=mysql&logoColor=white" alt="MySQL">
  <img src="https://img.shields.io/badge/Tests-MSTest-009688" alt="MSTest">
</p>

---

## 📌 Sobre o Projeto
Este projeto é uma **API minimalista em .NET 9.0** para gerenciamento de **Administradores** e **Veículos**, construída com **Entity Framework Core**, **MySQL** e testes automatizados com **MSTest**.  

✅ Separação em camadas (Domínio, Infra, Serviços, API)  
✅ Injeção de dependência  
✅ Testes unitários e de integração  
✅ Banco de dados relacional com EF Core + Migrations  

---

## ⚙️ Funcionalidades
### 👨‍💼 Administradores
- Cadastro de administradores  
- Login com autenticação  
- Perfis de acesso (Administrador, Editor, etc.)  
- Listagem de administradores (paginada)  

### 🚘 Veículos
- Cadastro de veículos  
- Edição e exclusão  
- Listagem de veículos (paginada)  

---

## 📂 Estrutura do Projeto
<details>
  <summary><b>📦 API</b></summary>
  API/
├── Dominio/<br>
│ ├── DTOs/ (AdministradorDTO, LoginDTO, VeiculoDTO)<br>
│ ├── Entidades/ (Administrador, Veiculo)<br>
│ ├── Enuns/ (Perfil)<br>
│ ├── Interfaces/ (IAdministradorServico, IVeiculoServico)<br>
│ └── ModelViews/ (AdministradorLogado, AdministradorModelView, ErrosDeValidacao, Home)<br>
├── Servicos/ (AdministradorServico, VeiculoServico)<br>
├── Infraestrutura/<br>
│ └── DbContexto.cs<br>
├── Migrations/<br>
├── Startup.cs<br>
├── Program.cs<br>
└── appsettings.json<br>
</details>

<details>
  <summary><b>🧪 TEST</b></summary>

TEST/<br>
├── Domain/<br>
│ ├── Entidades/ (AdministradorTest, VeiculoTest)<br>
│ └── Servicos/ (AdministradorServicoTest)<br>
├── Helpers/ (Setup.cs)<br>
├── Mocks/ (AdministradorServicoMock)<br>
├── Requests/ (AdministradorRequestTest)<br>
├── appsettings.json<br>
├── MSTestSettings.cs<br>
└── Test.csproj<br>

</details>

---

## 📑 Endpoints Principais

### 🔑 Login de Administrador
```http
POST /administradores/login
REQUEST
{
  "email": "adm@teste.com",
  "senha": "123456"
}

RESPONSE

{
  "email": "adm@teste.com",
  "perfil": "Administrador",
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
```

👨‍💼 Administradores

GET /administradores → lista administradores (paginado)



POST /administradores → cadastra um novo administrador

🚘 Veículos

GET /veiculos → lista veículos

POST /veiculos → cadastra veículo

PUT /veiculos/{id} → atualiza veículo

DELETE /veiculos/{id} → remove veículo

<h3 align="center">👨‍💻 Autor: Carlos Eduardo</h3> <p align="center">📚 Projeto de estudo e prática em .NET Minimal APIs, Entity Framework Core e Testes Automatizados</p>


