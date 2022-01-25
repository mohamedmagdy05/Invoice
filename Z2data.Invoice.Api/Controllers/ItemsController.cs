﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z2data.Invoice.Core.Entity;
using Z2data.Invoice.Core.Interfaces;
using Z2data.Invoice.Core.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Z2data.Invoice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IConfiguration _config;
        ItemsInterface _db; 
        
        public ItemsController(IConfiguration config)
        {
            _config = config;

            _db = new ItemsRepo(_config);
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<Items> Get()
        {
            try
            {

                return _db.GetItems();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {

                return Ok(_db.GetItemsById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}