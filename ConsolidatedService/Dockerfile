FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

 
COPY ["ConsolidatedService/ConsolidatedService.csproj", "ConsolidatedService/"]
RUN dotnet restore "ConsolidatedService/ConsolidatedService.csproj"
 
COPY . .
WORKDIR "/src/ConsolidatedService"
RUN dotnet build "ConsolidatedService.csproj" -c Release -o /app/build
 
WORKDIR /root
RUN dotnet tool install --global dotnet-ef --version 8.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

 
WORKDIR "/src/ConsolidatedService"
RUN dotnet publish "ConsolidatedService.csproj" -c Release -o /app/publish
 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
 
RUN apt-get update && apt-get install -y curl
ENTRYPOINT ["dotnet", "ConsolidatedService.dll"]
