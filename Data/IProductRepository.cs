using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<Product?> GetAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> UpdateAsync(Product product);
    }
}
