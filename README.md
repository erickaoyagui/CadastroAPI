# CadastroAPI

Bem-vindo ao projeto CadastroAPI! Esta é uma API de cadastro desenvolvida em .NET Core utilizando Docker para a criação de containeres para a integração com banco de dados.

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br) (opcional)

## Como Rodar a Aplicação via Docker e Terminal

1. Clone este repositório e acesse o diretório do projeto;
```
git clone https://github.com/erickaoyagui/CadastroAPI.git
```
2. Acesse a pasta do projeto:
```
cd CadastroAPI
```
3. Construa e execute os containers Docker para a API e o banco de dados:
```
docker compose up
```
4. Acesse a documentação Swagger da API em seu navegador:
 
   - http://localhost:5000/swagger ou https://localhost:5000/swagger

## Como Rodar a Aplicação via Visual Studio

1. Clone este repositório e acesse o diretório do projeto;
```
git clone https://github.com/erickaoyagui/CadastroAPI.git
```

2. Abra a solução no Visual Studio:

   - Inicie a solução "docker-compose" caso queira utilizar os containeres da API e do banco de dados;
  
   - Inicie a solução "CadastroAPI" caso queira apenas a API;

3. Realize as chamadas através do Swagger aberto ou Postman/Insomnia;

## Como Rodar os Testes

1. Clone este repositório e acesse o diretório do projeto;
```
git clone https://github.com/erickaoyagui/CadastroAPI.git
```
2. Abra a solução no Visual Studio:

3. Aperte Ctrl+R,A ou clique em Test/Run All Tests para chamar o TestProject.
