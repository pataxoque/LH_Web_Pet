#LH_PET_WEB - Gestão de Clínica Veterinária

Projeto desenvolvido para a disciplina de Desenvolvimento de Sistemas (SENAI). O foco principal é a implementação do padrão MVC no ASP.NET Core, integrando o back-end em C# com banco de dados MySQL.

## 🛠️ Tecnologias e Dependências
* **Framework:** .NET 9.0 (ASP.NET Core MVC)
* **Banco de Dados:** MySQL 8.0
* **ORM:** Entity Framework Core (Pomelo)
* **Segurança:** Autenticação via Cookies e Hashing de senhas com BCrypt.Net

## 📂 Estrutura do Repositório
* `Controllers/`: Lógica de rotas e regras de negócio.
* `Models/`: Definições das entidades e persistência de dados.
* `Data/`: Contexto do EF Core e configuração do banco.
* `Services/`: Implementação de envio de e-mail (SMTP) e validações extras.
* `Views/`: Interface Razor (HTML/C#) - *Em desenvolvimento*.

## 🚀 Como rodar o projeto
1.  Configure sua string de conexão no `appsettings.json`.
2.  Certifique-se de que o MySQL está rodando e execute o script de criação das tabelas (conforme os PDFs de documentação).
3.  No terminal da raiz do projeto, execute:
    ```bash
    dotnet restore
    ```
    ```bash
    dotnet run
    ```

## 📝 Notas de Implementação
O sistema conta com validações customizadas de CPF, sistema de recuperação de senha via e-mail e upload de imagens para o cadastro de produtos e pets. A autenticação bloqueia o acesso a rotas sensíveis (como relatórios) para usuários não autorizados.