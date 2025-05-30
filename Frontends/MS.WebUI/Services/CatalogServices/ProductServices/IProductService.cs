﻿using MS.UI.DtoLayer.CatalogDtos.ProductDtos;

namespace MS.WebUI.Services.CatalogServices.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task CreateProductAsync(CreateProductDto cpdto);
    Task UpdateProductAsync(UpdateProductDto updto);
    Task DeleteProductAsync(string id);
    Task<GetByIdProductDto> GetByIdProductAsync(string id);
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId);
}
