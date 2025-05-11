# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Çözüm dosyasını ve tüm içeriği kopyala
COPY . .

# Çözüm dosyasını geri yükle
RUN dotnet restore "CQRS_Test_Project.sln"

# WebAPI projesini yayınla
RUN dotnet publish "Presentation/CQRS_Test_Project.Presentation.WebAPI/CQRS_Test_Project.Presentation.WebAPI.csproj" -c Release -o /app/publish

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CQRS_Test_Project.Presentation.WebAPI.dll"]
