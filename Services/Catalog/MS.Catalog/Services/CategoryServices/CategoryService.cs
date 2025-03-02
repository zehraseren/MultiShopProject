using AutoMapper;
using MongoDB.Driver;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.CategoryDtos;

namespace MS.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IMongoCollection<Category> categoryCollection, IMapper mapper)
        {
            _categoryCollection = categoryCollection;
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto ccdto)
        {
            var value = _mapper.Map<Category>(ccdto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto ucdto)
        {
            var value = _mapper.Map<Category>(ucdto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == ucdto.CategoryId, value);
        }
    }
}
