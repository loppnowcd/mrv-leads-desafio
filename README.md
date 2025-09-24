# MRV Leads Management System

*[English](#english) | [Português](#português)*

---

## Português

### Visão Geral

Uma aplicação full-stack para gerenciamento de leads construída com .NET Core 6 Web API e frontend React.

Esta aplicação permite aos usuários gerenciar leads de serviços através de uma interface limpa com duas visualizações principais:
- **Convidados**: Mostra leads com status "New" que podem ser aceitos ou recusados
- **Aceitos**: Mostra leads que foram aceitos

### Funcionalidades

- Visualizar leads em layouts de cards organizados
- Aceitar leads (aplica desconto de 10% para preços > $500)
- Recusar leads
- Atualizações de dados em tempo real
- Design responsivo
- Arquitetura de API RESTful

### Stack Tecnológica

**Backend**
- **.NET Core 6** - Framework Web API
- **Entity Framework Core** - ORM para operações de banco de dados
- **SQL Server** - Banco de dados
- **Swagger** - Documentação da API

**Frontend**
- **React 18** - Framework frontend
- **JavaScript (ES6+)** - Linguagem de programação
- **CSS3** - Estilização
- **Fetch API** - Cliente HTTP

### Como Começar

#### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/sql-server) ou SQL Server Express
- [Node.js](https://nodejs.org/) (v14 ou superior)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

#### Configuração do Backend

1. **Clonar o repositório**
   ```bash
   git clone https://github.com/loppnowcd/mrv-leads-desafio/
   cd MRV.Leads
   ```

2. **Restaurar pacotes NuGet**
   ```bash
   dotnet restore
   ```

3. **Atualizar conexão do banco de dados** 
   - Verificar `appsettings.json` e atualizar connection string se necessário

4. **Criar e popular banco de dados**
   ```bash
   dotnet ef database update
   ```

5. **Executar a API**
   ```bash
   dotnet run
   ```
   - API estará disponível em `https://localhost:7013`
   - Documentação Swagger em `https://localhost:7013/swagger`

#### Configuração do Frontend

1. **Navegar para o diretório frontend**
   ```bash
   cd Frontend
   ```

2. **Instalar dependências**
   ```bash
   npm install
   ```

3. **Atualizar URL da API**
   - Verificar `App.js` e garantir que `API_BASE` aponta para a URL do seu backend

4. **Iniciar servidor de desenvolvimento**
   ```bash
   npm start
   ```
   - Frontend estará disponível em `http://localhost:3000`

### Endpoints da API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/Leads/invited` | Obter leads com status "New" |
| GET | `/api/Leads/accepted` | Obter leads com status "Accepted" |
| POST | `/api/Leads/{id}/accept` | Aceitar um lead (aplica desconto se > $500) |
| POST | `/api/Leads/{id}/decline` | Recusar um lead |

### Regras de Negócio

- **Desconto Automático**: Ao aceitar um lead com preço > $500, um desconto de 10% é automaticamente aplicado
- **Notificação por Email**: Sistema registra notificações por email para leads aceitos (saída no console)
- **Gerenciamento de Status**: Leads podem ter status "New", "Accepted", ou "Declined"

### Dados de Exemplo

A aplicação inclui leads de serviços de exemplo:
- Pintura de casa ($450)
- Reforma de cozinha ($650) 
- Trabalho de encanamento ($320)
- Reparo de telhado ($720)
- Trabalho elétrico ($850)
- Paisagismo ($280)
- Reforma residencial ($980)

### Estrutura do Projeto

```
MRV.Leads/
├── Backend/
│   ├── Controllers/
│   │   └── LeadsController.cs
│   ├── ApplicationDbContext.cs
│   ├── Lead.cs
│   ├── DataSeeder.cs
│   └── Program.cs
├── Frontend/
│   ├── public/
│   ├── src/
│   │   ├── App.js
│   │   ├── App.css
│   │   └── index.js
│   └── package.json
└── README.md
```

### Melhorias Futuras

- Padrão CQRS com MediatR
- Implementação Domain Driven Design (DDD)
- Event Sourcing
- Notificações reais por email
- Autenticação de usuário
- Filtros e busca de leads
- Funcionalidade de exportação

---


## English

### Overview

A full-stack lead management application built with .NET Core 6 Web API and React frontend.

This application allows users to manage service leads through a clean interface with two main views:
- **Invited**: Shows leads with "New" status that can be accepted or declined
- **Accepted**: Shows leads that have been accepted

### Features

- View leads in organized card layouts
- Accept leads (applies 10% discount for prices > $500)
- Decline leads
- Real-time data updates
- Responsive design
- RESTful API architecture

### Tech Stack

**Backend**
- **.NET Core 6** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database
- **Swagger** - API documentation

**Frontend**
- **React 18** - Frontend framework
- **JavaScript (ES6+)** - Programming language
- **CSS3** - Styling
- **Fetch API** - HTTP client

### Getting Started

#### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/sql-server) or SQL Server Express
- [Node.js](https://nodejs.org/) (v14 or higher)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

#### Backend Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/loppnowcd/mrv-leads-desafio/
   cd MRV.Leads
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection** 
   - Check `appsettings.json` and update connection string if needed

4. **Create and seed database**
   ```bash
   dotnet ef database update
   ```

5. **Run the API**
   ```bash
   dotnet run
   ```
   - API will be available at `https://localhost:7013`
   - Swagger documentation at `https://localhost:7013/swagger`

#### Frontend Setup

1. **Navigate to frontend directory**
   ```bash
   cd Frontend
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Update API URL**
   - Check `App.js` and ensure `API_BASE` points to your backend URL

4. **Start development server**
   ```bash
   npm start
   ```
   - Frontend will be available at `http://localhost:3000`

### API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Leads/invited` | Get leads with "New" status |
| GET | `/api/Leads/accepted` | Get leads with "Accepted" status |
| POST | `/api/Leads/{id}/accept` | Accept a lead (applies discount if > $500) |
| POST | `/api/Leads/{id}/decline` | Decline a lead |

### Business Rules

- **Automatic Discount**: When accepting a lead with price > $500, a 10% discount is automatically applied
- **Email Notification**: System logs email notifications for accepted leads (console output)
- **Status Management**: Leads can be in "New", "Accepted", or "Declined" status


## License / Licença

This project is for educational/interview purposes.  
*Este projeto é para fins educacionais/entrevista.*
