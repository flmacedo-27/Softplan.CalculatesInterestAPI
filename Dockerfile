FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CalculatesInterest/CalculatesInterest.csproj", "CalculatesInterest/"]
COPY ["CalculatesInterest.API/CalculatesInterest.API.csproj", "CalculatesInterest.API/"]
RUN dotnet restore "CalculatesInterest.API/CalculatesInterest.API.csproj"
RUN dotnet restore "CalculatesInterest/CalculatesInterest.csproj"

COPY . .
WORKDIR "/src/CalculatesInterest.API"
RUN dotnet build "CalculatesInterest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculatesInterest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatesInterest.API.dll"]
