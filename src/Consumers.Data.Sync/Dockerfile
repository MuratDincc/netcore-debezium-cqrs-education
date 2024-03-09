FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Consumers.Data.Sync/Consumers.Data.Sync.csproj", "Consumers.Data.Sync/"]
RUN dotnet restore "Consumers.Data.Sync/Consumers.Data.Sync.csproj"
COPY . .
WORKDIR "src/Consumers.Data.Sync"
RUN dotnet build "Consumers.Data.Sync.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Consumers.Data.Sync.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consumers.Data.Sync.dll"]