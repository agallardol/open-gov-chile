FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51080
EXPOSE 44331

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["open-gob/open-gob.csproj", "open-gob/"]
RUN dotnet restore "open-gob/open-gob.csproj"
COPY . .
WORKDIR "/src/open-gob"
RUN dotnet build "open-gob.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "open-gob.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "open-gob.dll"]