using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WhatAToolFinal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        
        public ICollection<ToolApplicationUser> ToolApplicationUsers { get; set; }
    }
}
