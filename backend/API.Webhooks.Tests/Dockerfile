# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Webhooks.Tests/API.Webhooks.Tests.csproj", "backend/API.Webhooks.Tests/"]
COPY ["backend/API.Webhooks/API.Webhooks.csproj", "backend/API.Webhooks/"]
RUN dotnet restore "./backend/API.Webhooks.Tests/API.Webhooks.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Webhooks.Tests"
RUN dotnet build "./API.Webhooks.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Webhooks.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Webhooks.Tests.dll", "--logger:trx"]
