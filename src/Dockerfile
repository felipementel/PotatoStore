#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Potato.Product.Api/Potato.Product.Api.csproj", "Potato.Product.Api/"]
COPY ["Potato.Product.Application/Potato.Product.Application.csproj", "Potato.Product.Application/"]
COPY ["Potato.Product.Domain/Potato.Product.Domain.csproj", "Potato.Product.Domain/"]
COPY ["Potato.Product.Infra.Database/Potato.Product.Infra.Database.csproj", "Potato.Product.Infra.Database/"]
RUN dotnet restore "Potato.Product.Api/Potato.Product.Api.csproj"
COPY . .
WORKDIR "/src/Potato.Product.Api"
RUN dotnet build "Potato.Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Potato.Product.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Potato.Product.Api.dll"]