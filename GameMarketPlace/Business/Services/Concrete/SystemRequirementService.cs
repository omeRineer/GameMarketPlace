using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class SystemRequirementService : ISystemRequirementService
    {
        readonly ISystemRequirementRepository _systemRequirementRepository;

        public SystemRequirementService(ISystemRequirementRepository systemRequirementRepository)
        {
            _systemRequirementRepository = systemRequirementRepository;
        }

        public async Task<IResult> AddAsync(SystemRequirement entity)
        {
            await _systemRequirementRepository.AddAsync(entity);
            await _systemRequirementRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(SystemRequirement entity)
        {
            _systemRequirementRepository.Delete(entity);
            await _systemRequirementRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<List<SystemRequirement>>> GetListAsync()
        {
            var list = await _systemRequirementRepository.GetListAsync();

            return new SuccessDataResult<List<SystemRequirement>>(list);
        }

        public async Task<IResult> UpdateAsync(SystemRequirement entity)
        {
            _systemRequirementRepository.Update(entity);
            await _systemRequirementRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
