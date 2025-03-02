using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.ProductDetailDtos;

namespace MS.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;

        public ProductDetailService(IMapper mapper, IMongoCollection<ProductDetail> productDetailCollection)
        {
            _mapper = mapper;
            _productDetailCollection = productDetailCollection;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto cpddto)
        {
            var value = _mapper.Map<ProductDetail>(cpddto);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public Task UpdateProductDetailAsync(UpdateProductDetailDto upddto)
        {
            var value = _mapper.Map<ProductDetail>(upddto);
            return _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == upddto.ProductDetailId, value);
        }
    }
}
