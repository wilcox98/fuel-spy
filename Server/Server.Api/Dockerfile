#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM --platform=$BUILDPLATFORM  mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim AS base

ARG TARGETARCH
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

# FROM base AS debug
FROM --platform=$BUILDPLATFORM  mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src

COPY ["Server.Api/Api.csproj", "."]
COPY ["Server.Api/LocalDatabase.db", "."]
RUN dotnet restore "Api.csproj"
COPY ["Server.Api/", "."]
WORKDIR "/src/."
# RUN dotnet new tool-manifest

RUN dotnet build "Api.csproj"  -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet tool install --global dotnet-ef --version 7
RUN export PATH="$PATH:/root/.dotnet/tools"
# RUN dotnet ef database update
FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "Api.csproj"  -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]