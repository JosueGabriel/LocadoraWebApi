# :memo: Projeto LocadoraWebApi
## :rocket: Tecnologias utilizadas
Esse projeto foi desenvolvido por meio das seguintes tecnologias:
-   [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)  - Backend
-   [.NET CORE 6](https://docs.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-6)  - Backend(Framework)
-   [Entity Framework](https://docs.microsoft.com/pt-br/ef/)  - Banco de dados(Framework/ORM)
-   [MySQL](https://www.mysql.com)  - Banco de dados
## :package: Instalação
Para executar esse repositório baixe-o para sua maquina ou de um `Git Clone`
### :computer:  Backend
-   abra a pasta do Projeto no Terminal/Prompt de Comando.
-   `dotnet restore`  esse comando ira restaurar todas as dependencias do projeto
-   Configure a instancia do seu Banco de Dados no arquivo appsettings.json
-   `dotnet ef database update`  esse comando ira criar o banco de dados do projeto 
-   `dotnet run`  esse comando ira rodar o projeto
### :rocket:  Metodos disponiveis
Ao rodar o projeto ele abrira o `Swagger`.
**Swagger:** `https://localhost:7260/swagger`

-----
###### Cliente

-   **GET:**  `https://localhost:7260/api/Cliente`
-   **POST:**  `https://localhost:7260/api/Cliente`  
-   **PUT:**  `https://localhost:7260/api/Cliente`
O POST e PUT espera a seguinte entrada no body:
```
{
  "id": 0,
  "nome": "string",
  "cpf": "stringstrin",
  "dataNascimento": "2022-04-11T13:23:42.812Z"
}
```
-   **GET:**  `https://localhost:7260/api/Cliente/{id}`
-  **DELETE:**  `https://localhost:7260/api/Cliente/{id}`
	 > Retorna os Clientes com locações em atraso:
 -   **GET:**  `https://localhost:7260/api/Cliente/ClientesComAtraso` 
	 > Retorna o segundo Cliente mais realizou locações:
-   **GET:**  `https://localhost:7260/api/Cliente/SegundoClienteMaisAlugou`
-----
###### Filme

-   **GET:**  `https://localhost:7260/api/Filme`
-   **POST:**  `https://localhost:7260/api/Filme`  
-   **PUT:**  `https://localhost:7260/api/Filme`
O POST e PUT espera a seguinte entrada no body:
```
{
  "id": 0,
  "titulo": "string",
  "classificacaoIndicativa": 0,
  "lancamento": true
}
```
-   **GET:**  `https://localhost:7260/api/Cliente/{id}`
-  **DELETE:**  `https://localhost:7260/api/Cliente/{id}`
	> Retorna os Filmes que nunca foram alugados:
- **GET:**  `https://localhost:7260/api/Cliente/FilmesNucaAlugados`
	> Retorna o Top 5 Filmes mais alugados do ano passado:
- **GET:**  `https://localhost:7260/api/Cliente/Top5Filmes`
	> Retorna o Top 3 Filmes menos alugados da semana passada:
- **GET:**  `https://localhost:7260/api/Cliente/Top3FilmesMenos`
---
###### Locacao

-   **GET:**  `https://localhost:7260/api/Locacao`
-   **POST:**  `https://localhost:7260/api/Locacao`  
-   **PUT:**  `https://localhost:7260/api/Locacao`
O POST e PUT espera a seguinte entrada no body:
```
{
  "id": 0,
  "clienteId": 0,
  "filmeId": 0,
  "dataLocacao": "2022-04-11T13:42:48.397Z",
  "dataDevolucao": "2022-04-11T13:42:48.397Z"
}
```
-   **GET:**  `https://localhost:7260/api/Locacao/{id}`
-  **DELETE:**  `https://localhost:7260/api/Locacao/{id}`
