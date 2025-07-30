# CSE.Clientes.API - Microserviço de Clientes

Este microserviço é responsável pela gestão de dados e regras de negócio relacionados aos clientes no sistema CafeStore.

## 📂 Estrutura Interna

A estrutura do projeto segue uma organização em camadas, separando claramente as responsabilidades e promovendo a manutenibilidade.

---

### 🧱 Camadas e Responsabilidades

#### 📁 `Application` — Camada de Aplicação

Contém a lógica orquestradora da aplicação, conectando o domínio com as interfaces externas (ex: controllers).

**Responsabilidades:**

- Commands e CommandHandlers: Executam ações que modificam o estado da aplicação.
- Events e EventHandlers: Propagam e tratam eventos de domínio.
- Queries: Responsáveis por leitura e consultas (usando EF Core ou Dapper).

---

#### 📁 `Data` — Camada de Dados

Camada de infraestrutura para acesso e manipulação de dados persistentes.

**Responsabilidades:**

- DbContext: Contexto principal do Entity Framework.
- Repositórios: Implementações de acesso a dados.
- Mappings: Mapeamentos ORM (via Fluent API).
- Migrations: Controle de versão do banco.

---

#### 📁 `Models` — Camada de Domínio

Contém os conceitos essenciais do domínio de clientes, isolados de tecnologias externas.

**Responsabilidades:**

- Entidades: Representações dos objetos principais do negócio.
- Agregações: Estruturas que encapsulam regras e consistência.
- Objetos de Valor: Imutáveis, representam conceitos de negócio.
- Interfaces: Contratos para repositórios e serviços.

---

#### 📁 `Controllers`

Camada de apresentação que expõe os endpoints REST da API.

---

#### 📁 `Configuration`

Classes auxiliares para configuração de:

- Injeção de dependência
- Swagger
- Versionamento da API
- Middlewares

---

#### 📁 `Services`

Serviços internos que encapsulam regras específicas, integrações e validações adicionais.

---

## 🧩 Observações Arquiteturais

- Suporte à abordagem **DDD (Domain-Driven Design)**.
- Aplicação do padrão **CQRS** para separação de comandos e consultas.
- Organização alinhada com os princípios de **Clean Architecture** e **SOLID**.
