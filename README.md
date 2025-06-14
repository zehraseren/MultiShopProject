# 🛒 MultiShop (.NET CORE 8.0 MICROSERVICE ARCHITECTURE)

Bu repository, Murat Yücedağ’ın Udemy üzerindeki [.Net Core MultiShop Mikroservis E-Ticaret](https://www.udemy.com/course/aspnet-core-multishop-mikroservis-e-ticaret-kursu/) kursu kapsamında, eğitim sürecim boyunca geliştirdiğim MultiShop projesini içermektedir. Bu proje, kursta edinilen teorik bilgilerin uygulamaya dökülmesini sağlamak amacıyla yapılandırılmış, gerçek dünya senaryolarına uygun şekilde, mikroservis mimarisi temel alınarak geliştirilmiştir.

## 🎯Proje Hakkında
MultiShop projesi, modern yazılım mimarilerine uygun olarak geliştirilmiş, mikroservis mimarisi ile çalışan ölçeklenebilir bir e-ticaret platformudur. Kullanıcılar sisteme ziyaretçi ya da kayıtlı kullanıcı olarak giriş yapabilir, ürünleri inceleyebilir, sepetine ekleyebilir, sipariş verebilir ve bu siparişleri takip edebilir.

Proje, hem frontend hem de backend tarafında farklı teknolojileri ve veritabanlarını entegre ederek yüksek erişilebilirlik, modülerlik, bağımsız geliştirme ve kolay ölçeklenebilirlik gibi mikroservislerin temel avantajlarını sunar.

## Proje Görselleri
![Localization](https://github.com/user-attachments/assets/8aab52de-b7c6-4d20-8d27-fc289fa32eb7)
![Introduction](https://github.com/user-attachments/assets/d0dd1e38-e3b5-4b49-be6d-d7aa696f9e00)
![Ekran görüntüsü 2025-06-15 012518](https://github.com/user-attachments/assets/7d0a2cff-e9f8-4d83-8106-4e87d89fdbd1)
![Ekran görüntüsü 2025-06-15 012541](https://github.com/user-attachments/assets/99dcc9cc-7f12-46c1-9b3f-17988067f760)
![Ekran görüntüsü 2025-06-15 012452](https://github.com/user-attachments/assets/7ac93d41-e28a-4af5-927d-060ed83b5655)




## 🧱 Mimari Yapı
Proje aşağıdaki gibi katmanlı bir mimariye sahiptir:

```
ApiGateway
   ├── MS.OcelotGateway
Frontends
   ├── MS.UI.DtoLayer
   └── MS.WebUI
IdentityServer
   └── MS.IdentityServer
RapidApi
   └── MS.RapidApiWebUI
Services
   ├── Basket
   ├── Cargo
   ├── Catalog
   ├── Comment
   ├── Discount
   ├── Image
   ├── Message
   ├── Order
   ├── Payment
   ├── RabbitMQMessage
   └── SignalRRealTimeApi
```
Aşağıdaki diyagram, projenin katmanlarını ve servisler arası iletişimi göstermektedir.
![diagram](https://github.com/user-attachments/assets/e0c1f284-7414-43fd-81f6-3c02e15f15fe)



## 🛠 Kullanılan Teknolojiler ve Araçlar
### 🧠 Backend & API Teknolojileri
+ 🤖 ASP.NET Core 8.0 Web Application
+ 🌐 ASP.NET Core Web API
+ 💾 Entity Framework Core
+ 💾 Dapper
+ 🚀 RapidAPI

### 🏗️ Mimari & Tasarım Desenleri
+ 🏛️ Onion Architecture
+ 🏛️ N-Tier Architecture
+ 📜 CQRS Design Pattern
+ 📜 Mediator Design Pattern
+ 📜 Repository Design Pattern

### 🔐 Kimlik Doğrulama & Güvenlik
+ 🔒 IdentityServer4
+ 🪙 Json Web Token (JWT)
+ 📧 MailKit

### 🚪 API Yönlendirme ve Gateway
+ 🌀 Ocelot API Gateway
+ 🔍 Discovery
 
### 💾 Veritabanları & Veri Yönetimi
+ 🗃️ MSSQL
+ 🐘 PostgreSQL
+ 🍃 MongoDB
+ 🚀 Redis
+ ☁️ Google Cloud Storage
+ 🐇 RabbitMQ

### 📡 Gerçek Zamanlı İletişim
+ 🔄 SignalR

### ⚙️ Geliştirme ve Test Araçları
+ 🐳 Docker
+ 🛠️ Postman
+ 🛠️ Swagger
+ 🖥️ DBeaver

### 🎨 Frontend Teknolojileri
+ 📝 HTML
+ 🖌️ CSS
+ ⚡ JavaScript
+ 📐 Bootstrap

### 🌍 Uluslararasılaştırma
+ 🌐 Localization


## 🚀 Nasıl Çalıştırılır?
### ✅ Gereksinimler
Aşağıdaki yazılımların sisteminizde kurulu olması gerekir:
+ .NET 8.0 SDK
+ Docker
+ Visual Studio 2022+ veya Rider
+ DBeaver (Opsiyonel - Veritabanı kontrolü için)

1. Projeyi Klonlayın
```
git clone https://github.com/zehraseren/MultiShopProject
cd multishopproject
```

2. Docker Servislerini Başlatın
```
docker-compose up -d
```
> Docker ile birlikte şunlar ayağa kalkacaktır:
> + MSSQL, MongoDB, Redis, PostgreSQL
> + RabbitMQ
> + Ocelot Gateway
> + IdentityServer
> + Mikroservislerin bağlı olduğu veritabanları

3. Veritabanlarını Oluşturun ve Migrationları Uygulayın
Visual Studio üzerinde aşağıdaki servis projelerine sağ tıklayıp ```Set as Startup Project``` seçin ve migrationları çalıştırın:
> Komut satırından çalıştırmak isterseniz:
```
cd Services/Catalog/MS.Catalog
dotnet ef database update
```
> (Tüm servisler için bu işlemi tekrarlayın.)

🧠 4. Servisleri Çalıştırın
Servisleri sırasıyla aşağıdaki sırayla çalıştırmanız önerilir:
 1. MS.IdentityServer
 2. MS.OcelotGateway
 3. MS.WebUI
 4. Mikroservisler (Basket, Catalog, Order, Payment, vb.)
> Visual Studio'da Solution Items altındaki ```.sln``` dosyasını açarak çoklu başlatmayı da ayarlayabilirsiniz.

5. Uygulamaya Erişim
+ WebUI (Kullanıcı Arayüzü): http://localhost:5000
+ Ocelot Gateway: http://localhost:5001
+ [Swagger (API Dokümantasyonları):](https://github.com/zehraseren/MultiShopProject/blob/master/PortNumbers.txt) -> http://localhost:7070/swagger/index.html (örnek: Catalog API)
  > Diğer servislerin portlarına göre değişkenlik gösterebilir. 

6. Test Araçları (Opsiyonel)
+ API testleri için Postman veya Swagger UI kullanılabilir.
+ Geliştirme sırasında log takibi için Docker loglarını izleyebilirsiniz:
```
docker logs -f ms.catalog
```

*** 
### Geliştirici

📌 Zehra Şeren  
📧 fatmazehraseren@gmail.com  
🔗 [LinkedIn](https://www.linkedin.com/in/zehraseren/)  

***
### Lisans

Bu proje açık kaynak değildir ve yalnızca eğitim amaçlı kullanılabilir.
