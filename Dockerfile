FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BookListMVC/. ./BookListMVC/
COPY BookListMVC.UnitTests/. ./BookListMVC.UnitTests/
RUN dotnet restore

# copy everything else and build app

WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal
WORKDIR /app
COPY --from=build /app ./

#EXPOSE 5000

ENTRYPOINT ["dotnet", "BookListMVC.dll"]