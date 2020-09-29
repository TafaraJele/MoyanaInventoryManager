using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManager.Comand.Core;
using InventoryManager.Model.Command;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagerCommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public OderController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] CustomerRecord customerRecord )
        {
            _customerApplication.CreateOder(customerRecord);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

       
    }
}
