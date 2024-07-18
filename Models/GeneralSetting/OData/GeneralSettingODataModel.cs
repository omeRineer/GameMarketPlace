using Core.Entities.DTO.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GeneralSetting.OData
{
    public record GeneralSettingCreateODataModel(int SettingTypeId,
                                                 string Key,
                                                 string Value,
                                                 string Description,
                                                 bool? IsCached,
                                                 int? CacheDuration) : IODataModel;
}
