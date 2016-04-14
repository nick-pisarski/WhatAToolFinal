using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WhatAToolFinal.Services;
using Microsoft.AspNet.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WhatAToolFinal.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ApplicationUserController : Controller
    {
        public ApplicationUserService _auService;

        public ApplicationUserController(ApplicationUserService auService)
        {
            this._auService = auService;
        }

        // GET: api/ApplicationUser
        [HttpGet]
        public IActionResult GetAppUser()
        {
            return Ok(_auService.ListAllUsers());
        }

        // GET: api/ApplicationUser/id
        [HttpGet("userBy/{id}")]
        public IActionResult GetPerson(string id)
        {
            return Ok(_auService.GetUserById(id));
        }

    }
}
