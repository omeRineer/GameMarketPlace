﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Category.Cms
{
    public class CreateCategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}