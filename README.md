Este projeto é uma API de exemplo construída usando .NET 5 e Entity Framework Core. Inclui um CRUD básico (Criar, Ler, Atualizar, Excluir) para gerenciamento de clientes.

## Pré-requisitos

- .NET 5 SDK
- PostgreSQL

### Configuração

1. **Clone o repositório:**

    ```sh
    git clone https://github.com/bmangilli/api_project_net5.git
    cd api_project_net5
    ```

2. **Crie `appsettings.Production.json`:**

    Crie um arquivo nomeado `appsettings.Production.json` no diretório raiz do projeto com sua configuração local do banco de dados:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=meu_servidor; Port=minha_porta; Database=meu_database; User Id=meu_usuario; Password=minha_senha; Pooling=true;"
      }
    }
    ```

### Executando a Aplicação

1. **Aplique as migrações:**

    ```sh
    dotnet ef database update
    ```

2. **Execute a aplicação:**

    ```sh
    dotnet run
    ```

### Endpoints da API

- **GET /api/clientes**: Obter todos os clientes
- **GET /api/clientes/{id}**: Obter um cliente pelo ID
- **POST /api/clientes**: Criar um novo cliente
- **PUT /api/clientes/{id}**: Atualizar um cliente pelo ID
- **DELETE /api/clientes/{id}**: Excluir um cliente pelo ID
