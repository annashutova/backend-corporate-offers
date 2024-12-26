FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY .env /app/.env
EXPOSE 8080

# Install PostgreSQL client tools in the base image
RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CorporateOffers.csproj", "./"]
RUN dotnet restore "CorporateOffers.csproj"
COPY . .

RUN dotnet tool install --global dotnet-ef --version 9.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR "/src/."
RUN dotnet build "CorporateOffers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CorporateOffers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY entrypoint.sh /app/entrypoint.sh
COPY . .

RUN dotnet tool install --global dotnet-ef --version 9.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN chmod +x /app/entrypoint.sh
ENTRYPOINT ["/app/entrypoint.sh", "dotnet", "CorporateOffers.dll"]