#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["GABC2019Dock/GABC2019Dock.csproj", "GABC2019Dock/"]
RUN dotnet restore "GABC2019Dock/GABC2019Dock.csproj"
COPY . .
WORKDIR "/src/GABC2019Dock"
RUN dotnet build "GABC2019Dock.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GABC2019Dock.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GABC2019Dock.dll"]