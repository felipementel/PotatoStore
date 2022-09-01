
# PotatoStore

[![.NET](https://github.com/felipementel/PotatoStore/actions/workflows/dotnet-estudo.yml/badge.svg?branch=main)](https://github.com/felipementel/PotatoStore/actions/workflows/dotnet-estudo.yml)

This project was created by Avanade Team to study

Commands to create a project
> dotnet new globaljson --sdk-version 6.0.301
> 
> dotnet new webapi --name Potato.Product

IP Tables to WSL-2
```
update-alternatives --config iptables
```

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

> Para executar os comandos, esteja na pasta <b>src</b>

```
dotnet ef migrations add InitDatabase --project Potato.Product.Infra.Database -s Potato.Product.Api -c Potato.Product.Infra.Database.ProductContext --verbose
```

```
dotnet ef database update InitDatabase --project Potato.Product.Infra.Database -s Potato.Product.Api -c Potato.Product.Infra.Database.ProductContext --verbose
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
### Generate Test Report
````
https://reportgenerator.io/
````

Add packages
````
dotnet add package coverlet.msbuild
````
Run tests

````
dotnet tool update -g dotnet-reportgenerator-globaltool
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=coverage.opencover.xml
reportgenerator -reports:**/coverage.opencover.xml -targetdir:coverage_report
#Abre o arquivo no browser padrão
coverage_report\index.html
````