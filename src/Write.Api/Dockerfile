FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Write.Api/Write.Api.csproj", "Write.Api/"]
RUN dotnet restore "Write.Api/Write.Api.csproj"
COPY . .
WORKDIR "src/Write.Api"
RUN dotnet build "Write.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Write.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Write.Api.dll"]
