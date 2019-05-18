

Essa pasta foi construída pelo comando Scaffold a partir do modelo previamente criado por migração

Procedimento...
- criar pasta Scaffold (ou outro nome)
- Prompt de comando
- Acessar pasta do projeto
- Executei da seguionte forma:
dotnet ef dbcontext scaffold "server=.\SQLEXPRESS;database=LivrosDB;User Id=sa; Password=123456;"  Microsoft.EntityFrameworkCore.SqlServer -o Scaffold -f -c ScaffoldDbContext 


Onde:
----
dotnet ef dbcontext scaffold <string de conexão>  Provider -o Models -f -c DemoDbContext
----
dotnet ef dbcontext - comando 
<string de conexão> - a string de conexão do banco de dados usado
Provider -  o provedor do banco de dados
-o Models - a pasta de sáida das classes geradas
-f - sobrescreve um código anteriormente gerado
-c DemoDbContext - o nome do DbContext usado na aplicação


(fonte: http://www.macoratti.net/17/11/efcore_dbctxt1.htm )