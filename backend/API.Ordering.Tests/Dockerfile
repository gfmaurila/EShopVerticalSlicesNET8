# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Ordering.Tests/API.Ordering.Tests.csproj", "backend/API.Ordering.Tests/"]
COPY ["backend/API.Ordering/API.Ordering.csproj", "backend/API.Ordering/"]
RUN dotnet restore "./backend/API.Ordering.Tests/API.Ordering.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Ordering.Tests"
RUN dotnet build "./API.Ordering.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Ordering.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Ordering.Tests.dll", "--logger:trx"]
