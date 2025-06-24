# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and restore
COPY *.sln ./
COPY ERP.API/ERP.API.csproj ERP.API/
COPY ERP.Models/ERP.Models.csproj ERP.Models/
COPY ERP.Database/ERP.Database.csproj ERP.Database/
COPY ERP.BusinessLogic/ERP.BusinessLogic.csproj ERP.BusinessLogic/
COPY ERP.BusinessRepository/ERP.BusinessRepository.csproj ERP.BusinessRepository/

RUN dotnet restore

# Copy everything else and publish
COPY . .
WORKDIR /src/ERP.API
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ERP.API.dll"]
