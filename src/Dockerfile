FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/IncidentManagement.Api/IncidentManagement.Api.csproj", "IncidentManagement.Api/"]
COPY ["src/IncidentManagement.Application/IncidentManagement.Application.csproj", "IncidentManagement.Application/"]
COPY ["src/IncidentManagement.Domain/IncidentManagement.Domain.csproj", "IncidentManagement.Domain/"]
COPY ["src/IncidentManagement.Infrastructure/IncidentManagement.Infrastructure.csproj", "IncidentManagement.Infrastructure/"]
RUN dotnet restore "IncidentManagement.Api/IncidentManagement.Api.csproj"
COPY . .
WORKDIR "/src/src/IncidentManagement.Api"
RUN dotnet build "IncidentManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IncidentManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentManagement.Api.dll"]