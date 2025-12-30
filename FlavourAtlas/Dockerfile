# ---------- BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy solution file
COPY FlavourAtlas.sln ./

# copy project files
COPY FlavourAtlas.Api/FlavourAtlas.Api.csproj FlavourAtlas.Api/
COPY FlavourAtlas.Application/FlavourAtlas.Application.csproj FlavourAtlas.Application/
COPY FlavourAtlas.Domain/FlavourAtlas.Domain.csproj FlavourAtlas.Domain/
COPY FlavourAtlas.Infrastructure/FlavourAtlas.Infrastructure.csproj FlavourAtlas.Infrastructure/

# restore dependencies
RUN dotnet restore FlavourAtlas.sln

# copy everything else
COPY . .

# build & publish api
RUN dotnet publish FlavourAtlas.Api/FlavourAtlas.Api.csproj -c Release -o /app/publish

# ---------- RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FlavourAtlas.Api.dll"]