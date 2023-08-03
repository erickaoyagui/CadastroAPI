#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CadastroAPI/CadastroAPI.csproj", "CadastroAPI/"]
COPY ["CadastroAPI.Domain/CadastroAPI.Domain.csproj", "CadastroAPI.Domain/"]
COPY ["CadastroAPI.Infrastructure/CadastroAPI.Infrastructure.csproj", "CadastroAPI.Infrastructure/"]
RUN dotnet restore "CadastroAPI/CadastroAPI.csproj"
COPY . .
WORKDIR "/src/CadastroAPI"
RUN dotnet build "CadastroAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CadastroAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CadastroAPI.dll"]