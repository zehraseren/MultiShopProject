using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Settings;

namespace MS.Catalog.Container;

public static class MongoDbExtensions
{
    public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMongoClient>(s =>
        {
            var settings = s.GetRequiredService<IDatabaseSettings>();
            return new MongoClient(settings.ConnectionString);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<Category>(settings.CategoryCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<Product>(settings.ProductCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<ProductDetail>(settings.ProductDetailCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<ProductImage>(settings.ProductImageCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<FeatureSlider>(settings.FeatureSliderCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<SpecialOffer>(settings.SpecialOfferCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<Feature>(settings.FeatureCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<OfferDiscount>(settings.OfferDiscountCollectionName);
        });

        services.AddScoped(s =>
        {
            var client = s.GetRequiredService<IMongoClient>();
            var settings = s.GetRequiredService<IDatabaseSettings>();
            var database = client.GetDatabase(settings.DatabaseName);
            return database.GetCollection<Brand>(settings.BrandCollectionName);
        });
    }
}
