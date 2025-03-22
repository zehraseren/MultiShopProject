using AutoMapper;
using MS.Catalog.Entities;
using MS.Catalog.Dtos.ProductDtos;
using MS.Catalog.Dtos.CategoryDtos;
using MS.Catalog.Dtos.ProductImageDtos;
using MS.Catalog.Dtos.SpecialOfferDtos;
using MS.Catalog.Dtos.ProductDetailDtos;
using MS.Catalog.Dtos.FeatureSliderDtos;

namespace MS.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

        CreateMap<Product, ResultProductWithCategoryDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));

        CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

        CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
    }
}
