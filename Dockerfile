FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/SupplyChainDemo.Api/SupplyChainDemo.Api.csproj", "src/SupplyChainDemo.Api/"]
RUN dotnet restore "src/SupplyChainDemo.Api/SupplyChainDemo.Api.csproj"
COPY . .
WORKDIR "/src/src/SupplyChainDemo.Api"
RUN dotnet publish "SupplyChainDemo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SupplyChainDemo.Api.dll"]
