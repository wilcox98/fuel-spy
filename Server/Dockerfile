#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM --platform=$BUILDPLATFORM  mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim AS base

ARG TARGETARCH
WORKDIR /app
EXPOSE 80
EXPOSE 443
# EXPOSE 5001

FROM base AS debug
RUN apt install procps-ng -y


FROM --platform=$BUILDPLATFORM  mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim AS build

WORKDIR /src
COPY ["Server.csproj", "."]
RUN dotnet restore "Server.csproj"

COPY . .
WORKDIR "/src/."
RUN dotnet build "Server.csproj"  -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server.csproj"  -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
RUN dotnet dev-certs https --trust
RUN  dotnet dev-certs https -ep /usr/local/share/ca-certificates/aspnet/https.crt --format PEM
RUN  update-ca-certificates
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]