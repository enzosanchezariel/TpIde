using Domain.Model;
using DTOs;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddAsync(CategoryDTO category);
        Task<bool> DeleteAsync(int id);
        Task<CategoryDTO?> GetAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<bool> UpdateAsync(CategoryDTO category);
    }
}
