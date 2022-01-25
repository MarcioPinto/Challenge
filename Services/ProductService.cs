using AutoMapper;
using challenge;
using challenge.Dtos.Product;
using Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetProductDto> AddProduct(AddProductDto newProduct)
        {
            Product product = _mapper.Map<Product>(newProduct);
    
            _context.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetProductDto>(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAllProducts()
        {
            var productsToReturn =  await _context.Product.ToListAsync();
            
            return  productsToReturn.Select(p => _mapper.Map<GetProductDto>(p)).ToList();
        }

        public async Task<IEnumerable<GetProductDto>> GetProductByBrand(string brand)
        {
            var productsFromContext = await _context.Product.ToListAsync();
            var productsToReturn = productsFromContext.Where(p => p.Brand.Equals(brand, StringComparison
                                                      .InvariantCultureIgnoreCase))
                                                      .ToList();

            if (!productsToReturn.Any())
            {
                return null;
            }

            return productsToReturn.Select(p => _mapper.Map<GetProductDto>(p)).ToList();
        }

        public async Task<GetProductDto> UpdateProduct(UpdateProductDto updatedProduct)
        {
            var productToUpdate = await _context.Product.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);
            
            if (productToUpdate == null)
            {
                return null;
            }

            productToUpdate.Brand = updatedProduct.Brand;
            productToUpdate.Name = updatedProduct.Name;
            productToUpdate.Description = updatedProduct.Description;
            productToUpdate.Category = updatedProduct.Category;

            await _context.SaveChangesAsync();

            return _mapper.Map<GetProductDto>(productToUpdate);
        }

        public void DeleteProduct(int id)
        {
            Product productToRemove = _context.Product.FirstOrDefault(p => p.Id == id);

            try
            {
                _context.Product.Remove(productToRemove);
            }
            catch (Exception)
            {
                throw;
            }
            
            _context.SaveChanges();
        }
    }
}