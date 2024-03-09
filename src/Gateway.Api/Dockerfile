FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Gateway.Api/Gateway.Api.csproj", "Gateway.Api/"]
RUN dotnet restore "Gateway.Api/Gateway.Api.csproj"
COPY . .
WORKDIR "src/Gateway.Api"
RUN dotnet build "Gateway.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Gateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.Api.dll"]
