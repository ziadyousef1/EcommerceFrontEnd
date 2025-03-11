using ClientLibrary.Models.Category;
using ClientLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId);
    }
}
