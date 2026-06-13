# csharp-tutoriais

Tutoriais e atividades práticas de C#, .NET, Entity Framework, API REST e JWT.

## Conteúdo

- **03-EntityFramework** — Aplicação console com Entity Framework Core + MySQL (CRUD de estudantes).
- **04-05-LojaApi** — API REST com ASP.NET Core, Entity Framework e MySQL:
  - CRUD de Produtos
  - CRUD de Clientes (exercício)
  - Autenticação com JWT (login e proteção de rotas)
  - Atividades práticas de Entity Framework (relacionamentos 1:N, etc.)

## Tecnologias

- .NET / C#
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MySQL
- JWT (JSON Web Token)
- Swagger

## Como rodar

1. Tenha o MySQL rodando e crie os bancos: `escola` e `loja`.
2. Ajuste a connection string em cada projeto (`appsettings.json` ou `AppDbContext.cs`).
3. Em cada projeto, rode as migrations:
