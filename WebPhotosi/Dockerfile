#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebPhotosi/WebPhotosi.csproj", "WebPhotosi/"]
COPY ["Business.Address/Business.Address.csproj", "Business.Address/"]
COPY ["Query.Infrastructure/Query.Infrastructure.csproj", "Query.Infrastructure/"]
COPY ["Business.Products/Business.Products.csproj", "Business.Products/"]
COPY ["Business.Users/Business.Users.csproj", "Business.Users/"]
COPY ["Business.Orders/Business.Orders.csproj", "Business.Orders/"]
RUN dotnet restore "WebPhotosi/WebPhotosi.csproj"
COPY . .
WORKDIR "/src/WebPhotosi"
RUN dotnet build "WebPhotosi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebPhotosi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebPhotosi.dll"]