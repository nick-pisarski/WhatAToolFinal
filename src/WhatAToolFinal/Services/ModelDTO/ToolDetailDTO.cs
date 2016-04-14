using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Models;

namespace WhatAToolFinal.Services.ModelDTO
{
    public class ToolDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string ImageURL { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public double MachineHours { get; set; }
        
    }
}
