using AutoMapper;
using MegoStore.Application.Dtos;
using MegoStore.Application.Interfaces;
using MegoStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitofWork _unitwork;
        private readonly IMapper _mapper;

        public ProductService(IUnitofWork unitwork, IMapper mapper)
        {
            _unitwork = unitwork;
            _mapper = mapper;
        }
        public async Task<ProductDto> AddProductAsync(ProductDto productDto)
        {
            var products=_mapper.Map<Product>(productDto);
            await  _unitwork.Repository<Product>().AddAsync(products);
            await _unitwork.SaveChangesAsync();
            return _mapper.Map<ProductDto>(products);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product= await _unitwork.Repository<Product>().GetByIdAsync(id);
            if(product == null)
                return false;
            _unitwork.Repository<Product>().Delete(product);


            await _unitwork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products=await _unitwork.Repository<Product>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _unitwork.Repository<Product>().GetByIdAsync(id);
            if (product == null)
                return null;
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(ProductDto productDto, int id)
        {
         var product=  await _unitwork.Repository<Product>().GetByIdAsync(id);
            if (product == null)
                return null;
            _mapper.Map( productDto,product);
            _unitwork.Repository<Product>().Update(product);
            await _unitwork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }
    }
}
