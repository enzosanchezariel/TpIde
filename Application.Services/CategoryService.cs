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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryDTO> AddAsync(CategoryDTO dto)
        {
            Category? existingCategory = await categoryRepository.GetByNameAsync(dto.Name.Trim());
            if (existingCategory != null)
            {
                throw new InvalidOperationException("A category with this name already exists.");
            }
            Category category = new Category(
                0,
                dto.Name.Trim()
            );
            await categoryRepository.AddAsync(category);
            dto.Id = category.Id;
            dto.Name = category.Name;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            // TODO: Add pagination
            var categories = await categoryRepository.GetAllAsync();

            return categories.Select(category => new CategoryDTO {
                Id = category.Id,
                Name = category.Name
            }).ToList();
        }

        public async Task<CategoryDTO?> GetAsync(int id)
        {
            Category? category = await categoryRepository.GetAsync(id);

            if (category == null) return null;

            return new CategoryDTO {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<bool> UpdateAsync(CategoryDTO dto)
        {
            Category? category = await categoryRepository.GetAsync(dto.Id);
            if (category == null) return false;
            category.setName(dto.Name.Trim());

            return await categoryRepository.UpdateAsync(category);
        }
    }
}
