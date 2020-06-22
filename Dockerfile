#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
WORKDIR /src
COPY ["ModMyFactoryServer.csproj", ""]
RUN dotnet restore "./ModMyFactoryServer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ModMyFactoryServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModMyFactoryServer.csproj" -c Release -o /app/publish
RUN dotnet ef database update --configuration Release --no-build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /src/users.db .
ENTRYPOINT ["dotnet", "ModMyFactoryServer.dll"]
