# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Catalog.Tests/API.Catalog.Tests.csproj", "backend/API.Catalog.Tests/"]
COPY ["backend/API.Catalog/API.Catalog.csproj", "backend/API.Catalog/"]
RUN dotnet restore "./backend/API.Catalog.Tests/API.Catalog.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Catalog.Tests"
RUN dotnet build "./API.Catalog.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Catalog.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Catalog.Tests.dll", "--logger:trx"]
