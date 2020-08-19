#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY recipe_guru.WebAPI/recipe_guru.WebAPI.csproj recipe_guru.WebAPI/
COPY recipe_guru.Model/recipe_guru.Model.csproj recipe_guru.Model/
RUN dotnet restore "recipe_guru.WebAPI/recipe_guru.WebAPI.csproj"
COPY . .
WORKDIR "/src/recipe_guru.WebAPI"
RUN dotnet build "recipe_guru.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "recipe_guru.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "recipe_guru.WebAPI.dll"]
