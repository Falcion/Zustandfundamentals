FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app

COPY source/*.csproj ./source/
RUN dotnet restore ./source/*.csproj

COPY . .
RUN dotnet build ./source/*.csproj -c Release -o /app/build

WORKDIR /app/source

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app

COPY --from=build-env /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "Zustandf.dll"]
