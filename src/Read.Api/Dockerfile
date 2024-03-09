FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Read.Api/Read.Api.csproj", "Read.Api/"]
RUN dotnet restore "Read.Api/Read.Api.csproj"
COPY . .
WORKDIR "src/Read.Api"
RUN dotnet build "Read.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Read.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Read.Api.dll"]
