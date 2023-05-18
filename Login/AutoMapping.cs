using AutoMapper;
using DTO;
using Entity;
namespace Login
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDto>().
                    ForMember(productDto => productDto.CategoryName,
                    opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<User, UserWithPasswordDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
           

        }
    }
}
