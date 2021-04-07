#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["NiCatApp_DONETCORE.csproj", ""]
RUN dotnet restore "./NiCatApp_DONETCORE.csproj"
COPY . .
WORKDIR "/src/."

ENV CONNECTIONSTRINGS__MYSQL="server=172.18.0.2;port=3306;database=NiCatBT;user id=root;password=chenni0427" 

# RUN dotnet build "NiCatApp_DONETCORE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NiCatApp_DONETCORE.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./appsettings_docker.json /app/appsettings.json
ENTRYPOINT ["dotnet", "NiCatApp_DONETCORE.dll"]