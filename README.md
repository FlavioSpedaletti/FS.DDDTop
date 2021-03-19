# Exemplo de arquitetura DDD (site + webapi)

[![Build status](https://ci.appveyor.com/api/projects/status/ft3vq72ldtkhtlwl?svg=true)](https://ci.appveyor.com/project/FlavioSpedaletti/fs-dddtop) [![Issues](https://img.shields.io/github/issues/FlavioSpedaletti/FS.DDDTop.svg)](https://huboard.com/FlavioSpedaletti/FS.DDDTop) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/9bf3916ab61a4ce8bdd93d4e1c1572d1)](https://www.codacy.com/manual/FlavioSpedaletti/FS.DDDTop?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=FlavioSpedaletti/FS.DDDTop&amp;utm_campaign=Badge_Grade) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=FlavioSpedaletti_FS.DDDTop&metric=alert_status)](https://sonarcloud.io/dashboard?id=FlavioSpedaletti_FS.DDDTop)

# Tecnologias usadas

- DDD
- Asp.Net Core
- EF Core
- Migrations
- Repository Pattern
- Unit of Work Pattern
- Injeção de dependências

- AutoMapper
- MiniProfiler

# Instruções para rodar

- O projeto usa uma base de dados SQL Server => (localdb)\mssqllocaldb;Database=DDDTop
- Para criá-lo já com a estrutura correta basta rodar as migrations:
	- No Package Manager Console: <code>Update-Database</code>, lembrando que o projeto web precisa ser o projeto startup para que a migrations encontre a connectionstring do contexto (EFContext); OU
	- No cmd, na pasta do projeto FS.DDDTop.Infra.Data: <code>dotnet ef database update -s ../FS.DDDTop.Web</code>

# Referências

- https://www.eduardopires.net.br/2014/10/tutorial-asp-net-mvc-5-ddd-ef-automapper-ioc-dicas-e-truques/ * 1h55m
- http://www.macoratti.net/17/05/aspcore_nvdb1.htm
- https://www.devmedia.com.br/entity-framework-core-criando-bases-de-dados-com-migrations/36776
- https://medium.com/jundevelopers/estruturando-arquitetura-api-net-core-2-2-32d99145a19d
- https://medium.com/@ericandrade_24404/parte-02-criando-arquitetura-em-camadas-com-ddd-inje%C3%A7%C3%A3o-de-dep-ef-defac0005667
- https://docs.microsoft.com/pt-br/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
- https://www.luisdev.com.br/2020/09/29/clean-architecture-com-asp-net-core-parte-1/
