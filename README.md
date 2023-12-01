# Projeto CRUD em C# e ASP.NET

## Descrição
Este é um projeto simples de CRUD desenvolvido como parte do meu treinamento em C# e ASP.NET. O objetivo principal é praticar conceitos básicos de desenvolvimento web e da linguagem CSharp.

## Requisitos
- Visual Studio (ou outra IDE de sua escolha)
- SQL Server (ou outro banco de dados compatível)

## Dependências
- Este projeto utiliza o gerenciador de pacotes NuGet para gerenciar suas dependências. Antes de executar o projeto, certifique-se de ter as dependências instaladas. Abra o Console do Gerenciador de Pacotes no Visual Studio ou o Terminal na linha de comando e navegue até o diretório do projeto.

Execute o seguinte comando para restaurar todas as dependências:

```bash
dotnet restore
```

- Isso baixará e instalará as dependências listadas no arquivo .csproj. Certifique-se de ter uma conexão com a internet ativa durante este processo.

### As dependências utilizadas no projeto são:
- Microsoft.EntityFrameworkCore: Versão 8.0.0

- Microsoft.EntityFrameworkCore.SqlServer: Versão 8.0.0

- Microsoft.EntityFrameworkCore.Tools: Versão 8.0.0

### Certifique-se de que essas versões são compatíveis com o seu ambiente de desenvolvimento.

## Configuração do Banco de Dados

1. Abra o SQL Server Management Studio e conecte-se ao seu servidor.
2. Crie um novo banco de dados chamado com um nome de sua preferencia.
3. Abra o arquivo `appsettings.json` no projeto e atualize a string de conexão com os detalhes do seu servidor e banco de dados.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SeuServidor;Database=NomeDoBanco;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

## Rodando Migrations

- No Console do Gerenciador de Pacotes, execute os seguintes comandos:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Isso aplicará as migrações e configurará o banco de dados.

## Rodando o Projeto

### Caso esteja utilizando o Visual Studio: 

1- Abra a solução no Visual Studio. Certifique-se de que o projeto está definido como o projeto de inicialização.

2- Pressione F5 ou clique em "Iniciar" para rodar o projeto.
Agora você deverá conseguir acessar o CRUD em http://localhost:porta.

### Caso esteja em outro ambiente:
1- Abra o terminal e digite o seguinte comando:

```bash
    dotnet run
```
2- Feito isso, você deverá conseguir acessar o CRUD em http://localhost:porta.

## Observações
Este projeto é apenas para fins de aprendizado. Sinta-se à vontade para explorar, modificar e melhorar conforme necessário.

Certifique-se de substituir NomeDoProjeto, NomeDoBanco, e SeuServidor pelos nomes reais do seu projeto, banco de dados e servidor. Espero que isso seja claro e útil! Caso tenha mais dúvidas ou precise de mais ajustes, estou à disposição. 😊