📌 Task Manager

Task Manager, kullanıcıların görevlerini yönetmelerine yardımcı olan modern bir uygulamadır. .NET ve React teknolojileri ile geliştirilmiş olup, gerçek zamanlı senkronizasyon, kullanıcı bazlı görev yönetimi ve şık bir arayüz sunar.

🚀 Özellikler

✅ Görev ekleme, düzenleme ve silme
✅ Görevlerin durumunu değiştirme
✅ Kullanıcı bazlı görev yönetimi
✅ Modern UI tasarımı
✅ Gerçek zamanlı veri senkronizasyonu
✅ API ile güçlü backend desteği
🛠 Kullanılan Teknolojiler

Teknoloji	Açıklama
Backend	.NET Core, CQRS, MediatR, Entity Framework
Frontend	React, Tailwind CSS
Veritabanı	SQL Server
Authentication	JWT
Diğer	AutoMapper, Fluent Validation, Onion Architecture
📦 Kurulum

Projeyi yerel ortamınıza kurmak için aşağıdaki adımları takip edin.

1️⃣ Projeyi Klonla
git clone https://github.com/yasinerenkovalik/TaskManager.git
cd TaskManager
2️⃣ Backend Kurulumu
cd Backend
dotnet restore
dotnet build
dotnet run
3️⃣ Frontend Kurulumu
cd Frontend
npm install
npm start
🚀 Uygulama çalışıyor! Tarayıcınızda http://localhost:3000 adresine giderek test edebilirsiniz.

🎯 API Kullanımı

Projede yer alan API'yi test etmek için aşağıdaki örnek istekleri kullanabilirsiniz.

🔹 Tüm Görevleri Listele
GET /api/tasks
🔹 Yeni Görev Ekle
POST /api/tasks
Content-Type: application/json

{
"title": "Yeni Görev",
"description": "Görev açıklaması",
"status": "Pending"
}
👥 Katkıda Bulunma

Projeye katkıda bulunmak isterseniz:

Fork edin 🍴
Yeni bir branch oluşturun (git checkout -b feature-yeni-ozellik)
Değişikliklerinizi yapın ve commit atın (git commit -m "Yeni özellik eklendi")
Push edin (git push origin feature-yeni-ozellik)
Bir Pull Request açın! 🚀
📄 Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına göz atabilirsiniz.

💡 İletişim: Sorularınız için GitHub Issues üzerinden bildirim açabilir veya benimle iletişime geçebilirsiniz.

🛠 Mutlu Kodlamalar! 🚀

Bu README.md dosyanı direkt olarak projenin ana dizinine ekleyerek kullanabilirsin. Eğer ekstra bir şey eklemek istersen haber ver! 😎🚀