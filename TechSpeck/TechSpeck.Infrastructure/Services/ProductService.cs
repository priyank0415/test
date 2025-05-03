using Microsoft.EntityFrameworkCore;
using TechSpeck.Application.DTOs;
using TechSpeck.Application.Interfaces;
using TechSpeck.Domain.Entities;
using TechSpeck.Infrastructure.Data;

namespace TechSpeck.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            StockQuantity = p.StockQuantity
        });
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity
        };
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            StockQuantity = productDto.StockQuantity
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        productDto.Id = product.Id;
        return productDto;
    }

    public async Task<ProductDto> UpdateProductAsync(ProductDto productDto)
    {
        var product = await _context.Products.FindAsync(productDto.Id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {productDto.Id} not found.");

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;
        product.StockQuantity = productDto.StockQuantity;

        await _context.SaveChangesAsync();
        return productDto;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
} 