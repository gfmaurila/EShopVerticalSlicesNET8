# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Register.Tests/API.Register.Tests.csproj", "backend/API.Register.Tests/"]
COPY ["backend/API.Register/API.Register.csproj", "backend/API.Register/"]
RUN dotnet restore "./backend/API.Register.Tests/API.Register.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Register.Tests"
RUN dotnet build "./API.Register.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Register.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Register.Tests.dll", "--logger:trx"]
