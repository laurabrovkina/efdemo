FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["efdemo/efdemo.csproj", "efdemo/"]
RUN dotnet restore "efdemo/efdemo.csproj"
COPY . .
WORKDIR "/src/efdemo"
RUN dotnet build "efdemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "efdemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "efdemo.dll"]