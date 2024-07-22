 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

 
COPY ["TransactionService/TransactionService.csproj", "TransactionService/"]
RUN dotnet restore "TransactionService/TransactionService.csproj"

 
COPY . .
WORKDIR "/src/TransactionService"
RUN dotnet build "TransactionService.csproj" -c Release -o /app/build


 
WORKDIR "/src/TransactionService"
RUN dotnet publish "TransactionService.csproj" -c Release -o /app/publish

 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=build /root/.dotnet /app/.dotnet
COPY --from=build /root/.nuget /app/.nuget
COPY --from=build /root/.local /app/.local
 

 

# Install curl
RUN apt-get update && apt-get install -y curl

ENTRYPOINT ["dotnet", "ConsolidatedService.dll"]
