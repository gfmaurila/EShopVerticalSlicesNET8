FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5060

ENV ASPNETCORE_URLS=http://+:5060
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN adduser -u 5660 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /backend

# Copia o arquivo .csproj para o diretorio de trabalho atual no container
COPY backend/API.Gateway/API.Gateway.csproj .

# Restaura as dependencias do projeto
RUN dotnet restore API.Gateway.csproj

# Copia o restante dos arquivos do projeto para o container
COPY . .

# Define o diretorio de trabalho e constroi o projeto
WORKDIR /backend
RUN dotnet build backend/API.Gateway/API.Gateway.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish src/poc.cqrs.api.gateway.net8/src/API.Gateway.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Gateway.dll"]
