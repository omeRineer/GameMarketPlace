using AutoMapper;
using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Enum.Type;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using Models.Category.WebService;
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

        public async Task<IResult> CreateAsync(CreateCategoryRequest request)
        {
            var entity = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _categoryRepository.GetAsync(f => f.Id == id);

            await _categoryRepository.DeleteAsync(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleCategoryResponse>> GetAsync(Guid id)
        {
            var entity = await _categoryRepository.GetAsync(f => f.Id == id);
            var mappedEntity = _mapper.Map<SingleCategoryResponse>(entity);

            return new SuccessDataResult<SingleCategoryResponse>(mappedEntity);
        }

        public async Task<IResult> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            var entity = await _categoryRepository.GetAsync(f => f.Id == updateCategoryRequest.Id);
            var mappedEntity = _mapper.Map(updateCategoryRequest, entity);

            await _categoryRepository.UpdateAsync(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
