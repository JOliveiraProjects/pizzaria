FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
RUN apt-get update && apt-get install -y iputils-ping
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Pizzaria.Gateway/Pizzaria.Gateway.csproj Pizzaria.Gateway/
RUN dotnet restore Pizzaria.Gateway/Pizzaria.Gateway.csproj
COPY . .
WORKDIR /src/Pizzaria.Gateway
RUN dotnet build Pizzaria.Gateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Pizzaria.Gateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pizzaria.Gateway.dll"]
