#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_12.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_12.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
# Copy csproj and restore as distinct layers
COPY . ./

RUN dotnet restore "AspnetCore.React.Redux.Web.csproj"

RUN dotnet build AspnetReactReduxTemplate.sln -c Release -o out

RUN npm i

RUN npm run build:prod


CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/AspnetCore.React.Redux.Web.dll