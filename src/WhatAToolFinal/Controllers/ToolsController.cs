using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WhatAToolFinal.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WhatAToolFinal.Controllers
{
    [Route("api/[controller]")]
    public class ToolsController : Controller
    {
        public ToolService _toolService;

        public ToolsController(ToolService toolService) {
           this._toolService = toolService;
        }

        // GET: api/Tools
        [HttpGet]
        public IActionResult GetTools()
        {
            return Ok(_toolService.GetListOfTools());
        }

      
    }
}
