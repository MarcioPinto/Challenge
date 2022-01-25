using challenge.Dtos.Product;
using Challenge.Models;

namespace Challenge.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto>> GetAllProducts();
        Task<IEnumerable<GetProductDto>> GetProductByBrand(string brand);
        Task<GetProductDto> AddProduct(AddProductDto newProduct);
        Task<GetProductDto> UpdateProduct(UpdateProductDto updatedProduct);
        void DeleteProduct(int id);
    }
}