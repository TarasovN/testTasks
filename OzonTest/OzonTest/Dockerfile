FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["OzonTest/OzonTest.csproj", "OzonTest/"]
RUN dotnet restore "OzonTest/OzonTest.csproj"
COPY . .
WORKDIR "/src/OzonTest"
RUN dotnet build "OzonTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OzonTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OzonTest.dll"]
