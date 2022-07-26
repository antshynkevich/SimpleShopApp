using AutoMapper;
using VideoCourseProject.db.Models;
using VideoCourseProject.db.Repositories;
using VideoCourseProject.Models;

namespace VideoCourseProject.Extensions;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>();
        CreateMap<ProductViewModel, Product>();
        CreateMap<ProductsDbRepository, List<ProductViewModel>>()
            .ForMember("Item", opt => opt.Ignore());
        CreateMap<Cart, CartViewModel>();
        CreateMap<CartItem, CartItemViewModel>();
    }
}
