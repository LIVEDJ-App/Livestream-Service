FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5040

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src

COPY ["Livestream.Api/Livestream.Api.csproj", "Livestream.Api/"]
COPY ["Livestream.Application/Livestream.Application.csproj", "Livestream.Application/"]
COPY ["Livestream.Domain/Livestream.Domain.csproj", "Livestream.Domain/"]
COPY ["Livestream.Infrastructure/Livestream.Infrastructure.csproj", "Livestream.Infrastructure/"]
COPY ["Livestream.Persistence/Livestream.Persistence.csproj", "Livestream.Persistence/"]

RUN dotnet restore "Livestream.Api/Livestream.Api.csproj"

COPY . .
WORKDIR "/src/Livestream.Api"
RUN dotnet build "Livestream.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "Livestream.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Livestream.Api.dll"]
