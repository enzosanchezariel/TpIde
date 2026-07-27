using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductService
    {
        Task<ProductDTO> AddAsync(ProductDTO product);
        Task<bool> DeleteAsync(int id);
        Task<ProductDTO?> GetAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<bool> UpdateAsync(ProductDTO product);
    }
}
