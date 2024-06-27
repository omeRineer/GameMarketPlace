using Core.Entities.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Category.ODataModels
{
    public record CategoryCreateODataModel(string name) : IODataModel;
    public record CategoryUpdateODataModel(string name) : IODataModel;
}
