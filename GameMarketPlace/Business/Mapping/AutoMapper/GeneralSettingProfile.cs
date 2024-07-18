using AutoMapper;
using Core.Entities.Concrete.GeneralSettings;
using Core.Extensions;
using Models.GeneralSetting.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class GeneralSettingProfile : Profile
    {
        public GeneralSettingProfile()
        {
            #region OData Profiles
            CreateMap<GeneralSettingCreateODataModel, GeneralSetting>();
            //.ForMember(m => m.Value, x => x.MapFrom((src, dst) =>
            //{
            //    Dictionary<string, object> mappedList = new Dictionary<string, object>();

            //    foreach (var item in src.Value)
            //    {
            //        if (double.TryParse(item.Value.ToString(), out double doubleValue)) mappedList.Add(item.Key, doubleValue);
            //        else if (bool.TryParse(item.Value.ToString(), out bool boolValue)) mappedList.Add(item.Key, boolValue);
            //        else mappedList.Add(item.Key, item.Value);
            //    }

            //    return JsonConvert.SerializeObject(mappedList, Formatting.Indented);
            //}));
            #endregion
        }
    }
}
