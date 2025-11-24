# ---- Etapa 1: Build ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . ./
RUN dotnet restore MicroServicioMarketing.Backend.csproj
RUN dotnet build MicroServicioMarketing.Backend.csproj -c Release -o /App/build

# ---- Etapa 2: Publish ----
FROM build AS publish
RUN dotnet publish MicroServicioMarketing.Backend.csproj -c Release -o /App/out

# ---- Etapa 3: Final runtime ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /App

COPY --from=publish /App/out .

ENTRYPOINT ["dotnet", "MicroServicioMarketing.Backend.dll"]
