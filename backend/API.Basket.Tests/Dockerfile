# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Basket.Tests/API.Basket.Tests.csproj", "backend/API.Basket.Tests/"]
COPY ["backend/API.Basket/API.Basket.csproj", "backend/API.Basket/"]
RUN dotnet restore "./backend/API.Basket.Tests/API.Basket.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Basket.Tests"
RUN dotnet build "./API.Basket.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Basket.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Basket.Tests.dll", "--logger:trx"]
