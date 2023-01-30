#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ConfigurationService/Presentation/API/API.csproj", "Services/ConfigurationService/Presentation/API/"]
COPY ["BuildingBlocks/MessageBus/EventBus.csproj", "BuildingBlocks/MessageBus/"]
COPY ["Services/ConfigurationService/Core/Application.Queries/Application.Queries.csproj", "Services/ConfigurationService/Core/Application.Queries/"]
COPY ["Services/ConfigurationService/Core/Domain/Domain.csproj", "Services/ConfigurationService/Core/Domain/"]
COPY ["Services/ConfigurationService/Infrastructure/Persistence.Commands/Persistence.Commands.csproj", "Services/ConfigurationService/Infrastructure/Persistence.Commands/"]
COPY ["Services/ConfigurationService/Core/Application.Commands/Application.Commands.csproj", "Services/ConfigurationService/Core/Application.Commands/"]
COPY ["Services/ConfigurationService/Infrastructure/Persistence.Queries/Persistence.Queries.csproj", "Services/ConfigurationService/Infrastructure/Persistence.Queries/"]
RUN dotnet restore "Services/ConfigurationService/Presentation/API/API.csproj"
COPY . .
WORKDIR "/src/Services/ConfigurationService/Presentation/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]