FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore FlavourAtlas.Api/FlavourAtlas.Api.csproj
RUN dotnet publish FlavourAtlas.Api/FlavourAtlas.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FlavourAtlas.Api.dll"]