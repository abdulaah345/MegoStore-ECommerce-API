using MegoStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetByIdAsync(int id);

        Task<ProductDto> AddProductAsync(ProductDto productDto);

        Task<ProductDto> UpdateProductAsync(ProductDto productDto,int id);

        Task<bool> DeleteProductAsync(int id);


            }
}
