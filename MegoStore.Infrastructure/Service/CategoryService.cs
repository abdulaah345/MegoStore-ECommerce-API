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
 
    
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitofWork unitofWork , IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;   
        }
        public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
        {
           var category=_mapper.Map<Category>(categoryDto);
            await _unitofWork.Repository<Category>().AddAsync(category);
            await _unitofWork.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var categories = await _unitofWork.Repository<Category>().GetByIdAsync(id);
            if(categories == null) 
                return false;
             _unitofWork.Repository<Category>().Delete(categories);
            await _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var categories = await _unitofWork.Repository<Category>().GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);

        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var categories = await _unitofWork.Repository<Category>().GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(categories);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto, int id)
        {
            var category = await _unitofWork.Repository<Category>().GetByIdAsync(id);
            if (category == null)
                return null;
            _mapper.Map(categoryDto, category);
            _unitofWork.Repository<Category>().Update(category);
            await _unitofWork.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(category);

           
        }
    }
}
