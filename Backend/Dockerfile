# Estágio de compilação
FROM mcr.microsoft.com/dotnet/aspnet:latest AS build
WORKDIR /app

# Copia e restaura os arquivos do projeto
COPY *.csproj .
RUN dotnet restore

# Copia todo o código-fonte e compila a aplicação
COPY . .
RUN dotnet publish -c Release -o out

# Estágio de produção
FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Backend.API.dll"]