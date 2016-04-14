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

        public IQueryable<Tool> GetListOfToolsByCategory(string category)
        {
            return _db.Tools.Where(t => t.Category.Name == category).Select(t => t);
        }

        public IQueryable<Tool> GetToolById(int id)
        {
            return _db.Tools.Where(t => t.Id == id).Select(t => t);
        }
 

    }
}

