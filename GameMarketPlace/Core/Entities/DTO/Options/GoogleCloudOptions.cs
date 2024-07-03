using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.Options
{
    public class GoogleCloudOptions
    {
        public StorageOptions StorageOptions { get; set; }
    }

    public class StorageOptions
    {
        public string ServiceKey { get; set; }
    }
}
