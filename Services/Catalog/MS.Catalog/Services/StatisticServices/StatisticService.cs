using MongoDB.Bson;
using MongoDB.Driver;
using MS.Catalog.Entities;

namespace MS.Catalog.Services.StatisticServices;

public class StatisticService : IStatisticService
{
    private readonly IMongoCollection<Brand> _brandCollection;
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;

    public StatisticService(IMongoCollection<Brand> brandCollection, IMongoCollection<Product> productCollection, IMongoCollection<Category> categoryCollection)
    {
        _brandCollection = brandCollection;
        _productCollection = productCollection;
        _categoryCollection = categoryCollection;
    }

    public async Task<long> GetBrandCount()
    {
        var result = await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        return result;
    }

    public Task<long> GetCategoryCount()
    {
        var result = _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        return result;
    }

    public async Task<string> GetMaxPriceProductName()
    {
        // Tüm dökümanları hedefleyen boş bir filtre tanımlanır (koleksiyon taraması yapılır)
        var filter = Builders<Product>.Filter.Empty;

        // Ürünleri ProductPrice alanına göre artan şekilde sıralamak için sıralama kriteri belirlenir
        var sort = Builders<Product>.Sort
            .Descending(p => p.ProductPrice);

        // Sorgu sonucunda yalnızca ProductName alanı dahil edilir, ProductId dışlanır
        // Bu işlem, ağ trafiğini azaltmak ve sadece ihtiyaç duyulan alanı elde etmek için yapılır (projection)
        var projection = Builders<Product>.Projection
            .Include(p => p.ProductName)
            .Exclude(nameof(Product.ProductId));

        // Belirtilen filtre, sıralama ve projeksiyon ile sorgu çalıştırılır
        // En yğksek fiyatlı ilk ürün döndürülür
        var product = await _productCollection.Find(filter)
            .Sort(sort)
            .Project<Product>(projection)
            .FirstOrDefaultAsync();

        // Ürün bulunduysa adı döndürülür, aksi halde null değeri döner
        return product?.ProductName;
    }

    public async Task<string> GetMinPriceProductName()
    {
        // Tüm dökümanları hedefleyen boş bir filtre tanımlanır (koleksiyon taraması yapılır)
        var filter = Builders<Product>.Filter.Empty;

        // Ürünleri ProductPrice alanına göre artan şekilde sıralamak için sıralama kriteri belirlenir
        var sort = Builders<Product>.Sort
            .Ascending(p => p.ProductPrice);

        // Sorgu sonucunda yalnızca ProductName alanı dahil edilir, ProductId dışlanır
        // Bu işlem, ağ trafiğini azaltmak ve sadece ihtiyaç duyulan alanı elde etmek için yapılır (projection)
        var projection = Builders<Product>.Projection
            .Include(p => p.ProductName)
            .Exclude(nameof(Product.ProductId));

        // Belirtilen filtre, sıralama ve projeksiyon ile sorgu çalıştırılır
        // En düşük fiyatlı ilk ürün döndürülür
        var product = await _productCollection.Find(filter)
            .Sort(sort)
            .Project<Product>(projection)
            .FirstOrDefaultAsync();

        // Ürün bulunduysa adı döndürülür, aksi halde null değeri döner
        return product?.ProductName;
    }

    public async Task<decimal> GetProductAvgPrice()
    {
        // Aggregation pipeline tanımı yapılır:
        // 1. $match aşaması: ProductPrice >= 0 olan ürünler filtrelenir
        // 2. $group aşaması: tüm dokümanlar tek bir grupta toplanarak ortalama fiyat (avgPrice) hesaplanır
        var pipeline = new BsonDocument[]
        {
            new BsonDocument("$match", new BsonDocument("ProductPrice", new BsonDocument("$gte", 0))),
            new BsonDocument("$group", new BsonDocument
            {
                { "_id", BsonNull.Value }, // tek bir grupta toplamak için _id null olarak atanır
                { "avgPrice", new BsonDocument("$avg", "$ProductPrice") } // ProductPrice alanının ortalaması alınır
            })
        };

        // Pipeline çalıştırılır, sonuçlar asenkron olarak alınır
        var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);

        // İlk döküman (grup sonucu) alınır
        var document = await result.FirstOrDefaultAsync();

        // Eğer sonuç null ise veya avgPrice alanı yoksa 0 döndürülür
        if (document == null || !document.Contains("avgPrice"))
            return 0;

        // Ortalama fiyat değeri decimal formatında döndürülür
        return document["avgPrice"].ToDecimal();
    }

    public Task<long> GetProductCount()
    {
        var result = _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        return result;
    }
}
