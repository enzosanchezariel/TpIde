using Domain.Model;

namespace Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private static readonly List<Category> categories = new List<Category>();
        private static int lastId = 0;

        public Task AddAsync(Category category)
        {
            category.setId(lastId + 1);
            lastId++;
            categories.Add(category);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null) {
                categories.Remove(category);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Category>>(categories.ToList());
        }

        public Task<Category?> GetAsync(int id)
        {
            return Task.FromResult(categories.FirstOrDefault(c => c.Id == id));
        }

        public Task<bool> UpdateAsync(Category category)
        {
            var index = categories.FindIndex(p => p.Id == category.Id);

            if (index != -1) {
                categories[index] = category;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
