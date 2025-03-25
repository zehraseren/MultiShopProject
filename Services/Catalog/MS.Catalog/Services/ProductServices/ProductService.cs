using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.ProductDtos;

namespace MS.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IMongoCollection<Product> productCollection, IMongoCollection<Category> categoryCollection)
        {
            _mapper = mapper;
            _productCollection = productCollection;
            _categoryCollection = categoryCollection;
        }

        public async Task CreateProductAsync(CreateProductDto cpdto)
        {
            var value = _mapper.Map<Product>(cpdto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<ResultProductWithCategoryDto> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId == CategoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<ResultProductWithCategoryDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updto)
        {
            var value = _mapper.Map<Product>(updto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updto.ProductId, value);
        }
    }
}
