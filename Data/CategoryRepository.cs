using Domain.Model;

namespace Data
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
