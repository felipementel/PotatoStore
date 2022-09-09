
# PotatoStore

[![.NET](https://github.com/felipementel/PotatoStore/actions/workflows/dotnet-estudo.yml/badge.svg?branch=main)](https://github.com/felipementel/PotatoStore/actions/workflows/dotnet-estudo.yml)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=felipementel_PotatoStore&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=felipementel_PotatoStore)

This project was created by Avanade Team to study

Commands to create a project
> dotnet new globaljson --sdk-version 6.0.400
> 
> dotnet new webapi --name Potato.Product

## WSL2

````
https://docs.microsoft.com/en-us/windows/wsl/install
````

IP Tables to WSL-2
```
update-alternatives --config iptables
```

To use in WSL for ELK warmup

```
sysctl -w vm.max_map_count=262144
```

Packages

```
dotnet tool install --global dotnet-reportgenerator-globaltool
```
```
dotnet tool install --global dotnet-ef
```
```
dotnet tool install --global dotnet-sonarscanner
```
```
dotnet tool install --global dotnet-coverage
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

Run tests

## Using CMD

````
$>src> dotnet test Potato.Product.sln /p:CollectCoverage=true /p:CoverletOutput=Results\Coverage /p:CoverletOutputFormat=cobertura
````
````
$>src> reportgenerator -reports:**/coverage.cobertura.xml -targetdir:Tests\results\WebResult
````
````
#Abre o arquivo no browser padrão
$>src> Tests\results\WebResult\index.html
````

# SonarQube Local
````
dotnet sonarscanner begin /k:"PotatoStore" /d:sonar.host.url="http://localhost:9044" /d:sonar.login="YOUR_KEY" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml 

dotnet build --no-incremental

dotnet-coverage collect 'dotnet test' -f xml  -o 'coverage.xml'

dotnet sonarscanner end /d:sonar.login="YOUR_KEY"
````

refs: https://docs.sonarqube.org/latest/analysis/test-coverage/dotnet-test-coverage/

# SonarCloud
