#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EjemploReal.Web/EjemploReal.Web.csproj", "EjemploReal.Web/"]
COPY ["EjemploReal.Api/EjemploReal.Api.csproj", "EjemploReal.Api/"]
RUN dotnet restore "EjemploReal.Web/EjemploReal.Web.csproj"
COPY . .
WORKDIR "/src/EjemploReal.Web"
RUN dotnet build "EjemploReal.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EjemploReal.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EjemploReal.Web.dll"]