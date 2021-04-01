FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY SpotifyAuth/*.csproj ./SpotifyAuth/
COPY SpotifyAuth.Persistence/*.csproj ./SpotifyAuth.Persistence/
COPY SpotifyAuth.Domain/*.csproj ./SpotifyAuth.Domain/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY SpotifyAuth/. ./SpotifyAuth/
COPY SpotifyAuth.Persistence/. ./SpotifyAuth.Persistence/
COPY SpotifyAuth.Domain/. ./SpotifyAuth.Domain/
#
WORKDIR /app/SpotifyAuth
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app 
#
COPY --from=build /app/SpotifyAuth/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "SpotifyAuth.dll"]


