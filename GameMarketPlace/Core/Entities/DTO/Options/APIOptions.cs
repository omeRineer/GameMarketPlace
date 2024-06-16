﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.Options
{
    public class APIOptions
    {
        public WebAPIOptions WebAPI { get; set; }
        public ODataAPIOptions ODataAPI { get; set; }
    }
    public class WebAPIOptions
    {
        public string BaseUrl { get; set; }
    }

    public class ODataAPIOptions
    {
        public string BaseUrl { get; set; }
    }
}
