using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.API.CRM.Services;
using Nop.Services.Customers;
using System.Threading.Tasks;

namespace Nop.Plugin.API.CRM.Controllers
{
    [Route("api/customers")]
    public class CustomerApiController : ControllerBase
    {
        private readonly CRMService _crmService;

        public CustomerApiController(CRMService crmService)
        {
            _crmService = crmService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationRequest model)
        {
            var existingContact = await _crmService.CheckExistingCustomerByEmail(model.Email);

            if (existingContact)
            {
                return BadRequest("Customer already exists in CRM.");
            }

            bool isCreated = await _crmService.CreateContactInCRM(model.Customer.FirstName, model.Customer.LastName, model.Email);

            if (isCreated)
            {
                return Ok("Customer registered successfully in CRM.");
            }

            return BadRequest("Failed to create the customer in CRM.");
        }
    }
}
