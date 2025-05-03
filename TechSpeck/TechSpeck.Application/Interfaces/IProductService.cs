using TechSpeck.Application.DTOs;

namespace TechSpeck.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(ProductDto productDto);
    Task<ProductDto> UpdateProductAsync(ProductDto productDto);
    Task<bool> DeleteProductAsync(int id);
} 