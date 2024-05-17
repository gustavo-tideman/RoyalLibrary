FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RoyalLibraryAPI/RoyalLibrary.API.csproj", "."]
COPY ["RoyalLibrary.Repositories/RoyalLibrary.Repositories.csproj", "."]
COPY ["RoyalLibrary.Models/RoyalLibrary.Models.csproj", "."]
COPY ["RoyalLibrary.Models.Mapping/RoyalLibrary.Models.Mapping.csproj", "."]
COPY ["RoyalLibrary.Services/RoyalLibrary.Services.csproj", "."]
COPY ["RoyalLibrary.Infra/RoyalLibrary.Infra.csproj", "."]

RUN dotnet restore "./././RoyalLibrary.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./RoyalLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoyalLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoyalLibrary.API.dll"]