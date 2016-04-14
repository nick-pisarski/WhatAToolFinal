using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAToolFinal.Services.ModelDTO
{
    public class ReturnToolModelDTO
    {
        public string UserId { get; set; }
        public int ToolId { get; set; }
        public double MachineHours { get; set; }
        public string Status { get; set; }

    }
}
