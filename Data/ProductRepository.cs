using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> products = new List<Product>();
        private static int lastId = 0;

        public Task AddAsync(Product product)
        {
            product.setId(lastId + 1);
            lastId++;
            products.Add(product);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var product = products.FirstOrDefault(c => c.Id == id);
            if (product != null) {
                products.Remove(product);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(products.ToList());
        }

        public Task<Product?> GetAsync(int id)
        {
            return Task.FromResult(products.FirstOrDefault(c => c.Id == id));
        }

        public Task<bool> UpdateAsync(Product product)
        {
            var index = products.FindIndex(p => p.Id == product.Id);

            if (index != -1) {
                products[index] = product;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
