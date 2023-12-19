<!-- Criar as migrations -->
dotnet ef migrations add NomeDaMigracao

<!-- remove a ultima migration -->
dotnet ef migrations remove

<!-- Persistir no Banco de dado as migrations -->
dotnet ef database update
