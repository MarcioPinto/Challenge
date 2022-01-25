using AutoMapper;
using challenge.Dtos.Product;
using Challenge.Models;

namespace challenge
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
        }
    }
}
