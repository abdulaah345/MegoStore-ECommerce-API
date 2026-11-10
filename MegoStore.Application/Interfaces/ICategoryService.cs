using MegoStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
        Task<CategoryDto> GetByIdAsync(int id);

        Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto);

        Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto, int id);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
