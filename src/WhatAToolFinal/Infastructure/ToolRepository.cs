using CoderCamps.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Models;

namespace WhatAToolFinal.Infastructure
{
    public class ToolRepository : GenericRepository<Tool>
    {

        public ToolRepository(ApplicationDbContext db) : base(db) { }
        
        public IQueryable<Tool> GetListOfToolsByCategory(Category category)
        {
            return _db.Tools.Where(t => t.Category == category).Select(t => t);
        }       

    }
}
