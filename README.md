# CafeStore - Sistema de E-commerce com Arquitetura Baseada em Microserviços

Este projeto utiliza uma arquitetura baseada em microserviços para construir um sistema de e-commerce escalável e modular. Cada funcionalidade principal do sistema é representada por um microserviço independente que se comunica através de um barramento de eventos utilizando RabbitMQ.

## 📦 Estrutura da Arquitetura

A arquitetura do sistema é composta por:

### 1. **Aplicação Cliente/Servidor**

- **WebApp MVC**: Interface principal para interação com os usuários, hospedada em IIS/Docker, com suporte para Azure e AWS.

### 2. **Serviços de API**

Microserviços desenvolvidos para gerenciar diferentes partes do sistema:

- **API Pagamento**: Processamento de pagamentos.
- **API Cliente**: Gerenciamento de informações de clientes.
- **API Pedido**: Gestão de pedidos do sistema.
- **API Catálogo**: Gerenciamento dos produtos no catálogo.
- **API Autenticação**: Gerenciamento de autenticação e autorização de usuários.
- **API Carrinho**: Gestão do carrinho de compras.

Cada API comunica-se com as outras ou com o barramento de eventos conforme necessário.

### 3. **Event Bus (RabbitMQ)**

Responsável por gerenciar a comunicação assíncrona entre os microserviços utilizando eventos.

### 4. **Bancos de Dados**

- **SQL Server**: Persistência principal dos dados do sistema.
- **Event Store**: Registro de eventos importantes para auditoria e histórico.

## 🚀 Tecnologias Utilizadas

- **.NET**: Framework principal para desenvolvimento de APIs e WebApp.
- **RabbitMQ**: Para mensageria e comunicação entre serviços.
- **SQL Server**: Banco de dados relacional.
- **Docker**: Conteinerização para fácil implantação e escalabilidade.
- **Azure/AWS**: Opções de hospedagem em nuvem.

## 📑 Funcionamento

1. A **WebApp MVC** interage com os microserviços para fornecer uma interface de usuário.
2. Cada microserviço é independente, com sua própria lógica de negócios.
3. O **RabbitMQ** é utilizado para:
   - Enviar eventos entre os microserviços.
   - Garantir comunicação desacoplada.
4. Os dados são armazenados e gerenciados pelo **SQL Server** e, quando necessário, pelo **Event Store** para event sourcing.

## 🔧 Pré-requisitos

- Docker instalado.
- Ambiente .NET configurado.
- RabbitMQ em execução.
- SQL Server configurado.

## ⚙️ Configuração e Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```
2. Suba os containers:
   ```bash
   docker-compose up
   ```
3. Acesse a aplicação:
   - Frontend: [http://localhost:5000](http://localhost:5000)
