using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAToolFinal.Models
{

    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set;}
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public double MachineHours { get; set; }

        public ICollection<ToolPerson> ToolPersons { get; set; }

      
    }
}
