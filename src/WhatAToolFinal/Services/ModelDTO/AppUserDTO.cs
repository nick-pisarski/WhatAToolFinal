using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Models;

namespace WhatAToolFinal.Services.ModelDTO
{
    public class AppUserDTO
    {   
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public List<UserToolListDTO> Tools { get; set; }
    }
}
