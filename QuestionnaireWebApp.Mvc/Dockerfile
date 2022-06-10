FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QuestinaryWebApp/QuestinaryWebApp.csproj", "QuestinaryWebApp/"]
RUN dotnet restore "QuestinaryWebApp/QuestinaryWebApp.csproj"
COPY . .
WORKDIR "/src/QuestinaryWebApp"
RUN dotnet build "QuestinaryWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuestinaryWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuestinaryWebApp.dll"]
