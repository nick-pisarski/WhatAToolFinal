using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Infastructure;
using WhatAToolFinal.Models;

namespace WhatAToolFinal.Services
{
    public class ToolService
    {
        private ToolRepository _toolRepo;

        public ToolService(ToolRepository toolRepo)
        {
            _toolRepo = toolRepo;
        }

        public ICollection<Tool> GetListOfTools()
        {
            return _toolRepo.List().ToList();
   
        }

        public ICollection<Tool> GetListOfToolsByCategory(Category category)
        {
            return _toolRepo.GetListOfToolsByCategory(category).ToList();
        }
    }
}
