FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Demo/GitDC3/GitDC3.csproj", "Demo/GitDC3/"]
RUN dotnet restore "Demo/GitDC3/GitDC3.csproj"
COPY . .
WORKDIR "/src/Demo/GitDC3"
RUN dotnet build "GitDC3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitDC3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitDC3.dll"]