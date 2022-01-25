using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
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
        private ItemsInterface _db;

        public ItemsController(IConfiguration config)
        {
            _config = config;
            _db = new ItemsRepo(_config);
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                throw new ArgumentNullException();
                return Ok(_db.GetItems());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                return BadRequest(ex);
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
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // POST api/<ItemsController>
        [HttpPost]
        public ActionResult Post([FromBody] Items items)
        {
            try
            {

                return Ok(_db.AddItems(items));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Items item)
        {
            try
            {

                return Ok(_db.UpdateItems(item));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {

                return Ok(_db.DeleteItems(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
