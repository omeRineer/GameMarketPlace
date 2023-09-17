using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class GeneralTypeExtensions
    {
        public static string JsonSerialize<TModel>(this TModel obj)
            where TModel : class, new()
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static TModel JsonDeserialize<TModel>(this string obj)
        {
            return JsonConvert.DeserializeObject<TModel>(obj);
        }
    }
}
