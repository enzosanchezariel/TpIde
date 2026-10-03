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
        private readonly ICategoryRepository categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<ProductDTO> AddAsync(ProductDTO dto)
        {
            Category? category = dto.Category == null ? null : await categoryRepository.GetAsync(dto.Category.Value);
            if (category == null)
            {
                throw new ArgumentException($"Category with id {dto.Category} does not exist.");
            }

            Product product = new Product(
                0,
                dto.Name.Trim(),
                dto.Description == null ? null : dto.Description.Trim(),
                ProductState.Listed,
                category,
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
                Category = product.Category == null ? null : product.Category.Id,
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
                Category = product.Category == null ? null : product.Category.Id,
                Price = product.Price.Value
            };
        }

        public async Task<bool> UpdateAsync(ProductDTO dto)
        {
            Product? product = await productRepository.GetAsync(dto.Id);
            if (product == null) return false;

            Category? category = dto.Category == null ? null : await categoryRepository.GetAsync(dto.Category.Value);
            if (category == null)
            {
                throw new ArgumentException($"Category with id {dto.Category} does not exist.");
            }

            product.setName(dto.Name.Trim());
            product.setDescription(dto.Description == null ? null : dto.Description.Trim());
            product.setState(ProductState.Listed);
            product.setCategory(category);
            product.setPrice(new Price(dto.Price));

            return await productRepository.UpdateAsync(product);
        }
    }
}
