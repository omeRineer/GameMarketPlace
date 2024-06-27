using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Category.Dto
{
    public record CategoryDto(Guid Id, string Name);
    public record CategoryAddDto(string Name);
    public record CategoryDeleteDto(Guid Id);
    public record CategoryUpdateDto(Guid Id, string Name);
}
