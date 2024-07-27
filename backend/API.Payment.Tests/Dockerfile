# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Payment.Tests/API.Payment.Tests.csproj", "backend/API.Payment.Tests/"]
COPY ["backend/API.Payment/API.Payment.csproj", "backend/API.Payment/"]
RUN dotnet restore "./backend/API.Payment.Tests/API.Payment.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Payment.Tests"
RUN dotnet build "./API.Payment.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Payment.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Payment.Tests.dll", "--logger:trx"]
