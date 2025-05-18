# Build imajı
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Çözüm dosyasını kopyalayın
COPY *.sln ./

# Katman klasörlerini ve proje dosyalarını kopyalayın
COPY Core ./Core
COPY Infrastructure ./Infrastructure
COPY Presentation ./Presentation

# Bağımlılıkları geri yükleyin
RUN dotnet restore

# Tüm kaynak kodunu kopyalayın (restore işleminden sonra)
COPY . ./

# Web projesini yayınlayın
WORKDIR /app/Presentation/CQRS_Test_Project.Presentation.WebAPI
RUN dotnet publish -c Release -o /app/out

# Çalışma zamanı imajı
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "CQRS_Test_Project.Presentation.WebAPI.dll"]
