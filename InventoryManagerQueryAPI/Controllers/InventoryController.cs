using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _365Solutions.Shared.Contracts;
using InventoryManager.Model.Query;
using InventoryManager.Query.Handlers.Services;
using InventoryManagerQueryAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagerQueryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IInventoryReadsHandler _inventoryReadsHandler;

        public InventoryController(IInventoryReadsHandler inventoryReadsHandler)
        {
            _inventoryReadsHandler = inventoryReadsHandler;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerRecordQuery>>> GetCustomerRecords()
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var records = await _inventoryReadsHandler.GetCustomerRecords(context);

            return Ok(records);
        }

        
    }
}
