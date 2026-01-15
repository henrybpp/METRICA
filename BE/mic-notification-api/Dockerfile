# =========================
# BUILD (SDK)
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Cache restore
COPY src/mic-event-api/mic-notification-api.csproj ./EventApi/
RUN dotnet restore ./EventApi/mic-notification-api.csproj

# Copy full source
COPY src/EventApi ./EventApi
WORKDIR /src/EventApi

# Publicar
RUN dotnet publish -c Release -o /app/publish

# =========================
# RUNTIME (LINUX)
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EventApi.dll"]