# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and csproj files
COPY *.sln ./
COPY ERP.API/*.csproj ERP.API/
COPY ERP.Models/*.csproj ERP.Models/
COPY ERP.BusinessRepository/*.csproj ERP.BusinessRepository/
COPY ERP.Database/*.csproj ERP.Database/
COPY ERP.BusinessLogic/*.csproj ERP.BusinessLogic/

# Restore dependencies
RUN dotnet restore

# Copy everything else and publish
COPY . .
WORKDIR /src/ERP.API
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ERP.API.dll"]
