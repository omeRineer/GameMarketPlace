using Core.Entities.Concrete.ProcessGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enum.Type
{
    public enum SliderTypeEnum
    {
        SliderItem = ProcessGroupEnum.SliderType + 1,
        SliderSideItem = ProcessGroupEnum.SliderType + 2
    }
}
