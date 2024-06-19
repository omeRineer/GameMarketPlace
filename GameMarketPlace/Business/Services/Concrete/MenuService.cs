using Business.Services.Abstract;
using Core.Entities.Concrete.Menu;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class MenuService : IMenuService
    {
        readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public Task<IResult> AddAsync(Menu entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(Menu entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Menu>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(Menu entity)
        {
            throw new NotImplementedException();
        }
    }
}
