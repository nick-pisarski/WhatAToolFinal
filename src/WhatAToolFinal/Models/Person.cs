using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAToolFinal.Models
{
    public class Person {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public string ImgUrl { get; set; }
            public bool IsAdmin { get; set; }

            public ICollection<ToolPerson> ToolPersons { get; set; }
    }
}
