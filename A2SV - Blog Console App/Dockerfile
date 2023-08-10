FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["A2SV - Blog Console App/A2SV - Blog Console App.csproj", "A2SV - Blog Console App/"]
RUN dotnet restore "A2SV - Blog Console App/A2SV - Blog Console App.csproj"
COPY . .
WORKDIR "/src/A2SV - Blog Console App"
RUN dotnet build "A2SV - Blog Console App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "A2SV - Blog Console App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "A2SV - Blog Console App.dll"]
