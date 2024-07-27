# Usar a imagem do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Employee.Tests/API.Employee.Tests.csproj", "backend/API.Employee.Tests/"]
COPY ["backend/API.Employee/API.Employee.csproj", "backend/API.Employee/"]
RUN dotnet restore "./backend/API.Employee.Tests/API.Employee.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Employee.Tests"
RUN dotnet build "./API.Employee.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Employee.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem do SDK do .NET 8.0 para executar os testes
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "API.Employee.Tests.dll", "--logger:trx"]
