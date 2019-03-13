FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["GABC2019Dock/GABC2019Dock.csproj", "GABC2019Dock/"]
RUN dotnet restore "GABC2019Dock/GABC2019Dock.csproj"
COPY . .
WORKDIR "/src/GABC2019Dock"
RUN dotnet build "GABC2019Dock.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GABC2019Dock.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GABC2019Dock.dll"]