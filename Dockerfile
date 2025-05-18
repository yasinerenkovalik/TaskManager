# Bu, .NET SDK'sının en son sürümünü içeren bir build imajıdır.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Çözüm dosyasını kopyalayın ve bağımlılıkları geri yükleyin
COPY *.sln ./
COPY */*.csproj ./
RUN dotnet restore

# Tüm kaynak kodunu kopyalayın
COPY . ./

# Web projesini yayınlayın (Presentation katmanınızın olduğu dizin)
WORKDIR /app/Presentation/CQRS_Test_Project.Presentation
RUN dotnet publish -c Release -o /app/out

# Bu, yalnızca çalışma zamanını içeren daha küçük bir imajdır.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "CQRS_Test_Project.Presentation.dll"]
