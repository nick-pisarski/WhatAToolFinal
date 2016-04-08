using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAToolFinal.Models
{
    public class ToolPerson    
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        
        public int ToolId { get; set; }
        [ForeignKey("ToolId")]
        public Tool Tool { get; set; }

        public DateTime CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}