# OdontoFlow

Sistema de gestão para clínicas odontológicas desenvolvido em .NET 9 com C#, seguindo os princípios de Clean Architecture, DDD e CQRS.

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

- **Linguagem:** C# / .NET 9
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

## Regras regulatórias implementadas

- Prontuário nunca pode ser deletado (exigência CFO)
- Todo acesso ao prontuário é auditado com log de usuário, data e hora
- Retenção mínima de dados por 20 anos
- Consentimento LGPD para uso de imagens e comunicações
- Exportação de dados do paciente sob demanda (portabilidade)

## Status do projeto
🚧 Em desenvolvimento

- [x] Arquitetura e estrutura de pastas
- [x] Domain — entidades, value objects, enums, interfaces
- [x] Application — Pacientes, Anamnese, Agenda, Dentista, Usuário
- [x] Infrastructure — repositórios, EF Core, migrations, JWT, BCrypt
- [x] API — controllers, Swagger com JWT, autenticação completa
- [x] Módulo Pacientes — CRUD completo
- [x] Módulo Anamnese — com entidades separadas (Alergias, Medicamentos, Doenças)
- [x] Módulo Agenda — Consultas, Grade Horário, Lista de Espera
- [x] Autenticação — JWT com registro, login e rotas protegidas
- [ ] Módulo Prontuário
- [ ] Módulo Financeiro
- [ ] Módulo Convênios
- [ ] Módulo Estoque
- [ ] Exception Middleware global
- [ ] Testes automatizados

## Como executar

> Em breve — o projeto ainda está em fase de construção da camada de domínio.
