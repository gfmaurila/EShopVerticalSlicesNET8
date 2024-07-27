# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Identity.Tests/API.Identity.Tests.csproj", "backend/API.Identity.Tests/"]
COPY ["backend/API.Identity/API.Identity.csproj", "backend/API.Identity/"]
RUN dotnet restore "./backend/API.Identity.Tests/API.Identity.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Identity.Tests"
RUN dotnet build "./API.Identity.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Identity.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Identity.Tests.dll", "--logger:trx"]
