using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductDTO> AddAsync(ProductDTO dto)
        {
            Product product = new Product(
                0,
                dto.Name.Trim(),
                dto.Description.Trim(),
                ProductState.Listed,
                new Category(0, "PLACEHOLDER", CategoryState.Listed),
                new Price(dto.Price)
            );
            await productRepository.AddAsync(product);
            dto.Id = product.Id;
            dto.Name = product.Name;
            dto.Description = product.Description;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            // TODO: Add pagination
            var products = await productRepository.GetAllAsync();

            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                State = product.State.ToString(),
                Category = product.Category.Id,
                Price = product.Price.Value
            }).ToList();
        }

        public async Task<ProductDTO?> GetAsync(int id) {
            Product? product = await productRepository.GetAsync(id);

            if (product == null) return null;

            return new ProductDTO {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                State = product.State.ToString(),
                Category = product.Category.Id,
                Price = product.Price.Value
            };
        }

        public async Task<bool> UpdateAsync(ProductDTO dto)
        {
            Product? product = await productRepository.GetAsync(dto.Id);
            if (product == null) return false;
            product.setName(dto.Name.Trim());
            product.setDescription(dto.Description.Trim());
            product.setState(ProductState.Listed);
            product.setCategory(new Category(dto.Category, "PLACEHOLDER", CategoryState.Listed));
            product.setPrice(new Price(dto.Price));

            return await productRepository.UpdateAsync(product);
        }
    }
}
