using CoderCamps.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Models;

namespace WhatAToolFinal.Infastructure
{
    public class ToolApplicationUserRepository : GenericRepository<ToolApplicationUser>
    {
        public ToolApplicationUserRepository(ApplicationDbContext db) : base(db) { }
    }
}
