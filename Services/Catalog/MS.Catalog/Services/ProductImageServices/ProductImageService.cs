using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.ProductImageDtos;

namespace MS.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public ProductImageService(IMapper mapper, IMongoCollection<ProductImage> productImageCollection)
        {
            _mapper = mapper;
            _productImageCollection = productImageCollection;
        }

        public Task CreateProductImageAsync(CreateProductImageDto cpidto)
        {
            var value = _mapper.Map<ProductImage>(cpidto);
            return _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _productImageCollection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<GetByIdProductImageDto> GetProductImagesByProductIdAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto upidto)
        {
            var value = _mapper.Map<ProductImage>(upidto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == upidto.ProductImageId, value);
        }
    }
}
