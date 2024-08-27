FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/PiarServer/PiarServer.Domain/PiarServer.Domain.csproj", "src/PiarServer/PiarServer.Domain/"]
COPY ["src/PiarServer/PiarServer.Application/PiarServer.Application.csproj", "src/PiarServer/PiarServer.Application/"]
COPY ["src/PiarServer/PiarServer.Infrastructure/PiarServer.Infrastructure.csproj", "src/PiarServer/PiarServer.Infrastructure/"]
COPY ["src/PiarServer/PiarServer.Api/PiarServer.Api.csproj", "src/PiarServer/PiarServer.Api/"]
RUN dotnet restore "src/PiarServer/PiarServer.Api/PiarServer.Api.csproj"
COPY . .
WORKDIR "/src/src/PiarServer/PiarServer.Api"
RUN dotnet build "PiarServer.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PiarServer.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PiarServer.Api.dll"]
