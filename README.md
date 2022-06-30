
# PotatoStore
This project was created by Avanade Team to study

Commands to create a project
> dotnet new globaljson --sdk-version 6.0.301
> 
> dotnet new webapi --name Potato.Product


To use in WSL for ELK warmup

```
sysctl -w vm.max_map_count=262144
```

References

1. To create a project:

https://docs.microsoft.com/en-us/dotnet/core/tools/

1. To create Application tier

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators

1. To create infra.database tier
 
https://docs.microsoft.com/en-us/ef/core/modeling/

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

https://www.npgsql.org/efcore

## Comandos

### Para efetivar a alteração no banco de dados pelo Migrations

```
dotnet ef migrations add InitDatabase --project Potato.Product.Infra.Database -c Potato.Product.Infra.Database.ProductContext --verbose
```

```
dotnet ef database update InitDatabase --project Potato.Product.Infra.Database -c Potato.Product.Infra.Database.ProductContext --verbose
```

```json
{
  "name": "Kleber Edson",
  "description": "dupla de dois",
  "url": "http://avanade-estudo.com.br",
  "sku": "$#RTGVDF",
  "price": 99.33
}
```
