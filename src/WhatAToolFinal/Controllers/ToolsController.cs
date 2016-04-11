using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WhatAToolFinal.Services;
using WhatAToolFinal.Models;

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

        // GET: api/tools
        [HttpGet]
        public IActionResult GetTools()
        {
            var tools = _toolService.GetListOfTools();
            return Ok(tools);
        }

        //GET: api/tools/{id}
        [HttpGet("{id}")]
        public IActionResult GetToolById(int id)
        {
            return Ok(_toolService.GetToolById(id));
        }

        //GET api/tools/category/{category}
        [HttpGet("category/{category}")]
        public IActionResult GetToolByCat(string category)
        {
            return Ok(_toolService.GetListOfToolsByCategory(category));
        }
    }
}
