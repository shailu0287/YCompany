#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Claims/Claims.API/Claims.API.csproj", "Services/Claims/Claims.API/"]
COPY ["Services/Claims/Claims.Infrastructure/Claims.Infrastructure.csproj", "Services/Claims/Claims.Infrastructure/"]
COPY ["Services/Claims/Claims.Application/Claims.Application.csproj", "Services/Claims/Claims.Application/"]
COPY ["Services/Claims/Claims.Domain/Claims.Domain.csproj", "Services/Claims/Claims.Domain/"]
COPY ["EventBus.Messages/EventBus.Messages.csproj", "EventBus.Messages/"]
RUN dotnet restore "Services/Claims/Claims.API/Claims.API.csproj"
COPY . .
WORKDIR "/src/Services/Claims/Claims.API"
RUN dotnet build "Claims.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Claims.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Claims.API.dll"]