using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAToolFinal.Services.ModelDTO
{
    public class UserToolListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
