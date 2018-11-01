FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /src
COPY ["PoliticalAdministrativeDivisionApp/PoliticalAdministrativeDivisionApp.csproj", "PoliticalAdministrativeDivisionApp/"]
RUN dotnet restore "PoliticalAdministrativeDivisionApp/PoliticalAdministrativeDivisionApp.csproj"
COPY . .
WORKDIR /src/PoliticalAdministrativeDivisionApp
RUN dotnet build "PoliticalAdministrativeDivisionApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PoliticalAdministrativeDivisionApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PoliticalAdministrativeDivisionApp.dll"]