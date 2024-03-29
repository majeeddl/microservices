#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Ordering/Ordering.API/Ordering.API.csproj", "src/Ordering/Ordering.API/"]
COPY ["src/Ordering/Ordering.Application/Ordering.Application.csproj", "src/Ordering/Ordering.Application/"]
COPY ["src/Ordering/Ordering.Domain/Ordering.Domain.csproj", "src/Ordering/Ordering.Domain/"]
COPY ["src/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "src/Ordering/Ordering.Infrastructure/"]
COPY ["src/BuildingBlocks/EventBus.Messages.csproj", "src/BuildingBlocks/EventBus.Messages/"]

RUN dotnet restore "src/Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/Ordering/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]