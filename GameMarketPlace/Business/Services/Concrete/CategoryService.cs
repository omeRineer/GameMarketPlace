using AutoMapper;
using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using Entities.Models.Category.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id)
        {
            var entity = await _categoryRepository.GetAsync(x => x.Id.Equals(id));

            var result = _mapper.Map<CategoryDto>(entity);

            return new SuccessDataResult<CategoryDto>(result);
        }

        public async Task<IDataResult<List<CategoryDto>>> GetListAsync()
        {
            var list = await _categoryRepository.GetListAsync();

            var result = _mapper.Map<List<CategoryDto>>(list);

            return new SuccessDataResult<List<CategoryDto>>(result);
        }

        public async Task<IResult> DeleteByIdAsync(Guid id)
        {
            var entity = await _categoryRepository.GetAsync(f => f.Id == id);

            _categoryRepository.Delete(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
