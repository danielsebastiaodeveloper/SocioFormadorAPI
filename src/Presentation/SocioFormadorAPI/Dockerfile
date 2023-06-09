FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ARG dbhost
ARG dbport
ARG dbname
ARG dbuser
ARG dbpassword

ARG runenv

ENV DBHOST=$dbhost
ENV DBPORT=$dbport
ENV DBNAME=$dbname
ENV DBUSER=$dbuser
ENV DBPASSWORD=$dbpassword

ENV ASPNETCORE_ENVIRONMENT=$runenv

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /project
COPY ["src/", "src"]

RUN dotnet restore "src/Presentation/SocioFormadorAPI/SocioFormadorAPI.csproj"

COPY . .

WORKDIR "/project/src/Presentation/SocioFormadorAPI"

RUN dotnet build "SocioFormadorAPI.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "SocioFormadorAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SocioFormadorAPI.dll"]
