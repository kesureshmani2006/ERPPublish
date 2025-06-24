# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln ./
COPY ERP.API/ERP.API.csproj ERP.API/
COPY ERP.Models/ERP.Models.csproj ERP.Models/
COPY ERP.Database/ERP.Database.csproj ERP.Database/
COPY ERP.BusinessLogic/ERP.BusinessLogic.csproj ERP.BusinessLogic/
COPY ERP.BusinessRepository/ERP.BusinessRepository.csproj ERP.BusinessRepository/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Build and publish
WORKDIR /src/ERP.API
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (optional if Railway auto-detects)
EXPOSE 80

ENTRYPOINT ["dotnet", "ERP.API.dll"]
