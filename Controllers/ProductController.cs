using Microsoft.AspNetCore.Mvc;
using challenge.Dtos.Product;
using Challenge.Services;

namespace challenge.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct(AddProductDto newProduct)
    {
        return Ok(await _productService.AddProduct(newProduct));
    }

    [HttpGet("{brand}")]
    public async Task<ActionResult> GetProductByBrand(string brand)
    {
        var products = await _productService.GetProductByBrand(brand);

        return products != null
            ? Ok(products)
            : NotFound("The brand does not exist.");
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _productService.GetAllProducts());
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProduct(UpdateProductDto updatedProduct)
    {
        var productUpdated = await _productService.UpdateProduct(updatedProduct);

        return productUpdated != null
            ? Ok(productUpdated)
            : NotFound("The product you inserted does not exist");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        try
        {
            _productService.DeleteProduct(id);
        }
        catch (Exception ex)
        {
            return NotFound($"Product with id {id} does not exist" );
        }

        return Ok();
    }
}
