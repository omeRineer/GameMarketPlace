﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.Pagination
{
    public struct PaginationParameter
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
