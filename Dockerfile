# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ImportantStuff.API/*.csproj ./ImportantStuff.API/
COPY ImportantStuff.Data/*.csproj ./ImportantStuff.Data/
COPY ImportantStuff.Model/*.csproj ./ImportantStuff.Model/
RUN dotnet restore

# copy everything else and build app
COPY ImportantStuff.API/. ./ImportantStuff.API/
COPY ImportantStuff.Data/. ./ImportantStuff.Data/
COPY ImportantStuff.Model/. ./ImportantStuff.Model/
WORKDIR /source/ImportantStuff.API
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ImportantStuff.Api.dll"]
