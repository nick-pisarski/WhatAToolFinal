using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAToolFinal.Models
{
    public class ToolApplicationUser    
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        
        public int ToolId { get; set; }
        [ForeignKey("ToolId")]
        public Tool Tool { get; set; }

        public DateTime CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}