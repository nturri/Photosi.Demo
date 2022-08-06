#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base


WORKDIR /app

EXPOSE 80

#ENV ASPNETCORE_URLS=http://+:5000 
#ENV ASPNETCORE_URLS = http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#FROM bitnami/aspnet-core:latest AS build

WORKDIR /src
COPY ["UserAPI/UserAPI.csproj", "UserAPI/"]
COPY ["Business.Users/Business.Users.csproj", "Business.Users/"]
COPY ["Data.Users/Data.Users.csproj", "Data.Users/"]
RUN dotnet restore "UserAPI/UserAPI.csproj"
COPY . .
WORKDIR "/src/UserAPI"
RUN dotnet build "UserAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAPI.dll"]

 #--urls http://localhost:5000