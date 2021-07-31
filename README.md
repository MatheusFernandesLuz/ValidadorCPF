# ValidadorCPF

Olá! Este é o projeto backend do desafio proposto. Resolvi fazer ele em .NET ao invés de typescript como o projeto frontend pois eu estou estudando mais .NET nos últimos dias e queria ver como eu me sairia.

# Informaçõe sobre o projeto

## Tecnologias utilizadas

- .NET Core
- EntityFramework Core
- MySQL

## Estrutura

Apesar do projeto ser pequeno, eu dividi a estrutura em algumas partes, que no visual studio são projetos diferentes, mas que estão dentro da mesma solution. São os projetos:

- **ValidadorCPF.Dominio:** Classes de modelo para o projeto.
- **ValidadorCPF.Repo:** Projeto onde está tudo relacionado ao banco de dados, o contexto do banco, migrations, etc.
- **ValidadorCPF.Suporte:** Projeto para criar classes úteis e que serão comum em toda o solução.
- **ValidadorCPF.WebAPI:** Projeto da API em si, onde ficam os controladores e as configurações da API.

## Requisitos

Não utilizei o docker no projeto pois ainda estou estudando ele e não tenho tanta franqueza para utilizá-lo ainda. Então, para conseguir rodar o projeto você vai precisar:

1. Ter o .NET Core 3.1 instalado, você pode baixar e instalar no site ofical da microsoft [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
2. Ter o MySQL instalado [https://dev.mysql.com/downloads/installer/](https://dev.mysql.com/downloads/installer/)

## Instruções para executar o projeto

```csharp
1. git clone https://github.com/MatheusFernandesLuz/ValidadorCPF.git
2. cd ValidadorCPF
```

Infelizmente ainda não consigui descobrir como obter a connection string do aquivo de configuração do projeto. Então será necessário alterar a connection string no método onConfigure, para colocar os dados de usuário e senha do seu banco de dados. 

Loca para alterar a connection string: `ValidadorCPF.Repo/AppContext.cs, linha 16`

```csharp
3. dotnet restore
4. dotnet ef database update --project ValidadorCPF.Repo
5. dotnet run --project ValidadorCPF.WebAPI
```

## Considerações finais

Como disse, anda estou aprendendo a mexer com .NET, e por isso mesmo que resolvi faze a atividade com ele! Qualquer dúvida estou a disposição.
