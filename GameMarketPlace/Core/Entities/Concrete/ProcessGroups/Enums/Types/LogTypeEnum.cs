using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete.ProcessGroups.Enums.Types
{
    public enum LogTypeEnum
    {
        Debug = ProcessGroupEnum.LogType + 1,
        Console = ProcessGroupEnum.LogType + 2,
        Notification = ProcessGroupEnum.LogType + 3,
        DataBase = ProcessGroupEnum.LogType + 4,
        File = ProcessGroupEnum.LogType + 5
    }
}
