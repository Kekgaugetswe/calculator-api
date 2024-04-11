#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Calculator.API/Calculator.API.csproj", "Calculator.API/"]
COPY ["Calculator.Domain/Calculator.Domain.csproj", "Calculator.Domain/"]
COPY ["Calculator.Infrastructure/Calculator.Infrastructure.csproj", "Calculator.Infrastructure/"]
RUN dotnet restore "./Calculator.API/./Calculator.API.csproj"
COPY . .
WORKDIR "/src/Calculator.API"
RUN dotnet build "./Calculator.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Calculator.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calculator.API.dll", "--environment"]