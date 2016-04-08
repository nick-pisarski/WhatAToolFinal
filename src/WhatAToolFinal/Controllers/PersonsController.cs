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
    public class PersonsController : Controller
    {
        public PersonService _personService;

        public PersonsController(PersonService personService)
        {
            this._personService = personService;
        }

        // GET: api/Persons
        [HttpGet]
        public IActionResult GetPerson()
        {
            return Ok(_personService.GetListOfPersons());
        }

        // GET: api/Persons/id
        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            return Ok();
        }

    }
}
