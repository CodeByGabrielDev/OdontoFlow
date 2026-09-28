# OdontoFlow

Sistema de gestão para clínicas odontológicas desenvolvido em .NET 10 com C#, seguindo os princípios de Clean Architecture, DDD e CQRS.

## Sobre o projeto

O OdontoFlow é um sistema completo de gestão odontológica, cobrindo desde o agendamento de consultas até o controle financeiro da clínica. O projeto foi desenvolvido com foco em conformidade regulatória (CFO e LGPD) e boas práticas de arquitetura de software.

## Módulos

- **Pacientes** — cadastro, anamnese, responsável legal para menores
- **Agenda** — grade de horários, detecção de conflitos, lista de espera
- **Prontuário Eletrônico** — odontograma, evolução clínica, prescrições digitais
- **Financeiro** — orçamentos, contas a receber, parcelamento
- **Convênios** — guias de autorização, tabela de procedimentos por operadora
- **Estoque** — controle de materiais, validade, alertas de estoque mínimo
- **Funcionários** — dentistas, perfis de acesso, controle de ausências

## Stack tecnológica

- **Linguagem:** C# / .NET 10
- **Framework:** ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Banco de dados:** SQL Server
- **Padrões:** Clean Architecture + DDD + CQRS
- **Mediator:** MediatR
- **Validações:** FluentValidation
- **Autenticação:** JWT

## Arquitetura

O projeto é dividido em quatro camadas com dependências unidirecionais:

```
Domain          → núcleo do negócio, zero dependências externas
Application     → casos de uso, Commands, Queries, DTOs
Infrastructure  → EF Core, repositórios, banco de dados
API             → Controllers, Middleware, autenticação
```
OdontoFlow/

├── Domain/

│   ├── Entities/

│   ├── ValueObjects/

│   ├── Enums/

│   ├── Interfaces/

│   ├── DomainEvents/

│   └── Exceptions/

├── Application/

│   ├── Pacientes/

│   ├── Agenda/

│   ├── Prontuario/

│   ├── Financeiro/

│   ├── Funcionarios/

│   └── Common/

├── Infrastructure/

│   ├── Persistence/

│   ├── Identity/

│   └── Audit/

└── API/

├── Controllers/

└── Middleware/

## Regras regulatórias

Objetivos de conformidade do projeto (CFO/LGPD). Nem todos estão implementados ainda — status real:

- [x] Prontuário nunca pode ser deletado pelo fluxo normal da aplicação
- [ ] Auditoria de acesso ao prontuário (log de usuário, data e hora) — evento de domínio existe mas ainda não é despachado
- [ ] Retenção mínima de dados por 20 anos
- [ ] Consentimento LGPD para uso de imagens e comunicações
- [ ] Exportação de dados do paciente sob demanda (portabilidade)

## Status do projeto
🚧 Em desenvolvimento

- [x] Arquitetura e estrutura de pastas
- [x] Domain — entidades, value objects, enums, interfaces
- [x] Application — Pacientes, Anamnese, Agenda, Dentista, Usuário, Prontuário, Financeiro, Convênios, Estoque, Funcionários
- [x] Infrastructure — repositórios, EF Core, migrations, JWT, BCrypt
- [x] API — controllers, Swagger com JWT, autenticação completa, autorização por perfil (Role) nos endpoints sensíveis
- [x] Módulo Pacientes — CRUD completo
- [x] Módulo Anamnese — com entidades separadas (Alergias, Medicamentos, Doenças)
- [x] Módulo Agenda — Consultas, Grade Horário, Lista de Espera
- [x] Autenticação — JWT com registro, login e rotas protegidas
- [x] Módulo Prontuário — odontograma (32 dentes), evolução clínica, plano de tratamento, prescrição
- [x] Módulo Financeiro — procedimentos, orçamentos, contas a receber, parcelamento
- [x] Módulo Convênios — convênios, vínculo paciente-convênio, guias de autorização
- [x] Módulo Estoque — itens, movimentações, alerta de estoque mínimo
- [x] Módulo Funcionários — CRUD básico
- [x] Exception Middleware global
- [x] Testes automatizados — cobertura unitária das regras críticas de domínio (`Tests/`)
- [ ] Migration mais recente (`FinalizaBackend`) aplicada ao banco (gerada, falta rodar `dotnet ef database update`)

## Como executar

1. Configure a connection string em `API/appsettings.json` (`ConnectionStrings:DefaultConnection`) apontando para uma instância SQL Server acessível.
2. Aplique as migrations: `dotnet ef database update --project Infrastructure --startup-project API`.
3. Rode a API: `dotnet run --project API`.
4. Abra o Swagger (ambiente de desenvolvimento) para autenticar via `/api/auth/register` + `/api/auth/login` e testar os demais endpoints com o token JWT retornado.
5. Rode os testes automatizados: `dotnet test`.
