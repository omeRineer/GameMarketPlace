﻿using AutoMapper;
using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto.Category;
using Entities.Main;
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

        public async Task<IResult> AddAsyncDto(CategoryAddDto categoryAddDto)
        {
            var entity = _mapper.Map<Category>(categoryAddDto);

            await _categoryRepository.AddAsync(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> AddAsync(Category entity)
        {
            await _categoryRepository.AddAsync(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Category entity)
        {
            _categoryRepository.Delete(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsyncDto(CategoryDeleteDto categoryDeleteDto)
        {
            var entity = await _categoryRepository.GetAsync(x => x.Equals(categoryDeleteDto));
            _categoryRepository.Delete(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsyncDto(Guid id)
        {
            var entity = await _categoryRepository.GetAsync(x => x.Equals(id));

            var result = _mapper.Map<CategoryDto>(entity);

            return new SuccessDataResult<CategoryDto>(result);
        }

        public async Task<IDataResult<List<Category>>> GetListAsync()
        {
            var list = await _categoryRepository.GetListAsync();

            return new SuccessDataResult<List<Category>>(list);
        }

        public async Task<IResult> UpdateAsync(Category entity)
        {
            _categoryRepository.Update(entity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsyncDto(CategoryUpdateDto categoryUpdateDto)
        {
            var mapEntity = _mapper.Map<Category>(categoryUpdateDto);

            _categoryRepository.Update(mapEntity);
            await _categoryRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<List<CategoryDto>>> GetListAsyncDto()
        {
            var list = await _categoryRepository.GetListAsync();

            var result = _mapper.Map<List<CategoryDto>>(list);

            return new SuccessDataResult<List<CategoryDto>>(result);
        }
    }
}
