using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManager.Comand.Core;
using InventoryManager.Model.Command;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Manager.Command.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public ProductOrdersController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        // POST api/<controller>
        [HttpPost]
        public async void  Post([FromBody]OrderCommand oder)
        {
            await _customerApplication.CreateProductOrder(oder);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody]OrderCommand order)
        {
            await _customerApplication.UpdateOrder(id,order);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            await _customerApplication.RemoveProductOrder(id);
        }
    }
}
