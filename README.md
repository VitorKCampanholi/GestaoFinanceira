# 💰 GestãoFinanceira

Sistema web desenvolvido para **gestão financeira**, permitindo o controle e acompanhamento de informações financeiras de forma organizada, centralizada e intuitiva.

O projeto foi desenvolvido utilizando **C#, .NET e Blazor**, com persistência de dados através do **SQL Server** e **Entity Framework Core**.

---

## 📋 Sobre o projeto

O **GestãoFinanceira** é uma aplicação web criada com o objetivo de facilitar o gerenciamento das informações financeiras de uma empresa.

A aplicação permite centralizar diferentes tipos de informações financeiras em um único sistema, proporcionando uma visão mais organizada dos lançamentos e do saldo das contas.

O projeto também foi utilizado como forma de colocar em prática conceitos de desenvolvimento de aplicações web utilizando o ecossistema **.NET**, incluindo desenvolvimento de interfaces, acesso a banco de dados, arquitetura da aplicação, Entity Framework Core, migrations e integração entre as diferentes camadas do sistema.

---

## 🎯 Objetivos

O principal objetivo do projeto é desenvolver uma aplicação capaz de auxiliar no controle financeiro, permitindo:

* Gerenciar informações financeiras;
* Controlar contas e lançamentos;
* Organizar contas a pagar e receber;
* Acompanhar o saldo das contas;
* Visualizar informações através de um dashboard;
* Centralizar informações em uma única aplicação;
* Facilitar o acompanhamento da situação financeira.

---

## 🚀 Tecnologias utilizadas

### Backend

* **C#**
* **.NET**
* **Blazor**
* **Entity Framework Core**

### Banco de dados

* **Microsoft SQL Server**
* **Entity Framework Core Migrations**

### Frontend

* **Blazor**
* **HTML5**
* **CSS3**
* **Bootstrap**
* **JavaScript**

### Ferramentas

* **Visual Studio**
* **Git**
* **GitHub**
* **SQL Server Management Studio / SQL Server**

---

## 🏗️ Arquitetura

O projeto utiliza uma organização baseada na separação de responsabilidades entre as diferentes partes da aplicação.

A estrutura principal do projeto é organizada de forma semelhante a:

```text
GestaoFinanceira/
│
├── Gestao.Domain/
│   ├── Entities/
│   ├── Interfaces/
│   └── ...
│
├── Gestao.Application/
│   ├── Services/
│   ├── DTOs/
│   └── ...
│
├── Gestao.Infrastructure/
│   ├── Data/
│   ├── Repositories/
│   └── ...
│
└── GestaoFinanceira/
    ├── Components/
    ├── Pages/
    ├── Layout/
    ├── wwwroot/
    ├── Program.cs
    └── appsettings.json
```

> A estrutura acima pode ser ajustada de acordo com a estrutura final existente no repositório.

### Domain

Responsável pelas principais regras e entidades do domínio da aplicação.

### Application

Concentra serviços, regras de aplicação e operações utilizadas pela interface.

### Infrastructure

Responsável pela comunicação com recursos externos, principalmente o banco de dados e Entity Framework Core.

### GestaoFinanceira

Projeto responsável pela aplicação web e pela interface apresentada ao usuário.

---

# 📊 Funcionalidades

## Dashboard

O sistema possui um dashboard para apresentar uma visão geral das informações financeiras.

Entre as informações apresentadas estão:

* Contas a pagar;
* Contas a receber;
* Saldo das contas;
* Informações financeiras resumidas;
* Tabelas e indicadores.

O dashboard foi desenvolvido para permitir que o usuário tenha uma visão rápida da situação financeira.

---

## 💸 Contas a pagar

Permite o gerenciamento dos lançamentos relacionados a despesas e obrigações financeiras.

Entre as informações que podem ser controladas estão:

* Descrição;
* Valor;
* Data;
* Categoria;
* Conta;
* Situação do lançamento.

---

## 💰 Contas a receber

Permite o controle de valores que deverão ser recebidos.

O usuário pode acompanhar informações relacionadas aos recebimentos e seus respectivos lançamentos financeiros.

---

## 🏦 Contas

O sistema permite o gerenciamento das contas utilizadas na movimentação financeira.

As contas podem representar diferentes fontes ou destinos dos recursos financeiros.

---

## 🏢 Empresas

A aplicação possui suporte ao gerenciamento de empresas, permitindo trabalhar com diferentes contextos financeiros dentro do sistema.

A empresa selecionada pode ser armazenada e utilizada para determinar os dados apresentados pela aplicação.

---

## 📂 Categorias

As categorias permitem organizar os lançamentos financeiros de acordo com sua finalidade.

Essa organização facilita a consulta e análise das movimentações financeiras.

---

# 🗄️ Banco de dados

O projeto utiliza **Microsoft SQL Server** como banco de dados.

A comunicação entre a aplicação e o banco é realizada utilizando:

**Entity Framework Core**

O Entity Framework permite trabalhar com as entidades da aplicação utilizando uma abordagem orientada a objetos, reduzindo a necessidade de escrever consultas SQL manualmente em diversas operações.

---

## 🔄 Migrations

As alterações realizadas nas entidades do projeto são controladas utilizando **Entity Framework Core Migrations**.

Para criar uma nova migration:

```powershell
Add-Migration NomeDaMigration
```

Para aplicar as alterações ao banco:

```powershell
Update-Database
```

---

# ⚙️ Configuração do projeto

## Pré-requisitos

Antes de executar o projeto, é necessário possuir instalado:

* .NET SDK compatível com a versão utilizada pelo projeto;
* Visual Studio 2022 ou outra IDE compatível;
* SQL Server;
* Git.

---

## 📥 Clonando o projeto

Clone o repositório utilizando:

```bash
git clone https://github.com/VitorKCampanholi/GestaoFinanceira.git
```

Entre na pasta do projeto:

```bash
cd GestaoFinanceira
```

---

# 🔧 Configuração do banco

A aplicação utiliza uma connection string configurada no arquivo:

```text
appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS04;Database=GestaoFinanceira;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

> A connection string deve ser ajustada de acordo com a instância do SQL Server existente na máquina.

---

# 🗃️ Criando/atualizando o banco

Depois de configurar a conexão com o banco, execute as migrations do projeto:

```powershell
Update-Database
```

O Entity Framework Core irá aplicar as migrations existentes e criar/atualizar a estrutura do banco de dados.

---

# ▶️ Executando a aplicação

Após configurar o banco de dados:

1. Abra o projeto no Visual Studio;
2. Verifique a connection string;
3. Certifique-se de que o SQL Server está em execução;
4. Execute as migrations;
5. Inicie a aplicação através do Visual Studio.

Também é possível executar pelo terminal:

```bash
dotnet run
```

Após iniciar, a aplicação estará disponível no endereço informado pelo ASP.NET Core.

---

# 🌐 GitHub

O código-fonte do projeto está disponível no GitHub:

**VitorKCampanholi/GestaoFinanceira**

Repositório:

https://github.com/VitorKCampanholi/GestaoFinanceira

---

# 📸 Interface

A aplicação possui uma interface web desenvolvida utilizando Blazor, Bootstrap, HTML e CSS.

Entre as principais telas estão:

* Dashboard;
* Contas a pagar;
* Contas a receber;
* Contas;
* Empresas;
* Categorias;
* Lançamentos.

> Screenshots das principais telas podem ser adicionados posteriormente nesta seção.

---

# 🧠 Conhecimentos aplicados

Durante o desenvolvimento do projeto foram aplicados diversos conceitos de desenvolvimento de software, incluindo:

* Programação orientada a objetos;
* C#;
* Desenvolvimento web com Blazor;
* ASP.NET Core;
* Entity Framework Core;
* SQL Server;
* Migrations;
* HTML;
* CSS;
* Bootstrap;
* JavaScript;
* Git;
* GitHub;
* Separação de responsabilidades;
* Desenvolvimento de componentes reutilizáveis;
* Integração entre aplicação e banco de dados.

---

# 🔮 Melhorias futuras

Algumas funcionalidades podem ser adicionadas futuramente ao projeto, como:

* [ ] Relatórios financeiros avançados;
* [ ] Exportação de dados para Excel/PDF;
* [ ] Gráficos financeiros mais completos;
* [ ] Sistema de notificações;
* [ ] Controle de permissões por usuário;
* [ ] Melhorias na responsividade;
* [ ] Deploy em ambiente de produção;
* [ ] Testes automatizados;
* [ ] Melhorias de performance;
* [ ] Integração com serviços externos.

---

# 👨‍💻 Desenvolvedor

**Vitor Kaleu Campanholi**

Projeto desenvolvido como aplicação prática para estudo e aperfeiçoamento em desenvolvimento de software utilizando o ecossistema **C#/.NET**.

---

## 📄 Licença

Este projeto pode ser utilizado para fins de estudo e demonstração.

---

⭐ Se este projeto foi útil ou interessante para você, considere deixar uma estrela no repositório.
