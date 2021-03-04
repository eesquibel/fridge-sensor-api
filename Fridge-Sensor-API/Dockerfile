#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
RUN apt-get update && apt-get dist-upgrade --yes
RUN apt-get install --yes curl
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get update && apt-get install --yes nodejs

WORKDIR /src
COPY ["Fridge-Sensor-API/Fridge-Sensor-API.csproj", "Fridge-Sensor-API/"]
RUN dotnet restore "Fridge-Sensor-API/Fridge-Sensor-API.csproj"
COPY . .

WORKDIR "/src/Fridge-Sensor-API/ClientApp"
RUN npm install && npm run ng -- build --prod

WORKDIR "/src/Fridge-Sensor-API"
RUN dotnet build "Fridge-Sensor-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fridge-Sensor-API.csproj" -c Release -o /app/publish

FROM base AS final
VOLUME /var/local/data
ENV DATABASE="/var/local/data/Records.db"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fridge-Sensor-API.dll"]