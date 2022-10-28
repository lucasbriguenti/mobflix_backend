FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mobflix_backend/Mobflix_backend.csproj", "Mobflix_backend/"]
RUN dotnet restore "Mobflix_backend/Mobflix_backend.csproj"
COPY . .
WORKDIR "/src/Mobflix_backend"
RUN dotnet build "Mobflix_backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mobflix_backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mobflix_backend.dll"]
