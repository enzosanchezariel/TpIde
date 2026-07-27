using Domain.Model;

namespace Data
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<Category?> GetAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<bool> UpdateAsync(Category category);
    }
}
