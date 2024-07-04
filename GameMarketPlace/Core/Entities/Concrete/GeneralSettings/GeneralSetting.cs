using Core.Entities.Abstract;
using Core.Entities.Concrete.ProcessGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete.GeneralSettings
{
    public class GeneralSetting : BaseEntity<long>
    {
        public int SettingTypeId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
        public bool IsCached { get; set; }
        public int? CacheDuration { get; set; }

        public TypeLookup SettingType { get; set; }
    }
}
