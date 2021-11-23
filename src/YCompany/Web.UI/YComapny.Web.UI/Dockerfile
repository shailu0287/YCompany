#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Web.UI/YComapny.Web.UI/YComapny.Web.UI.csproj", "Web.UI/YComapny.Web.UI/"]
RUN dotnet restore "Web.UI/YComapny.Web.UI/YComapny.Web.UI.csproj"
COPY . .
WORKDIR "/src/Web.UI/YComapny.Web.UI"
RUN dotnet build "YComapny.Web.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YComapny.Web.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YComapny.Web.UI.dll"]