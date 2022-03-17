#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FileSystem.GrcpServer/FileSystem.GrcpServer.csproj", "FileSystem.GrcpServer/"]
RUN dotnet restore "FileSystem.GrcpServer/FileSystem.GrcpServer.csproj"
COPY . .
WORKDIR "/src/FileSystem.GrcpServer"
RUN dotnet build "FileSystem.GrcpServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileSystem.GrcpServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileSystem.GrcpServer.dll"]