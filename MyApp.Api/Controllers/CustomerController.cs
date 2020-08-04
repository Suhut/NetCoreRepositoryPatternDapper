using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApp.Facade.Dto;
using MyApp.Facade.Interface;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost, Route("[action]")]
        public IActionResult Add(CustomerDtoReq reg)
        {
            return Ok(_customerService.Add(Guid.Parse("28B3380B-DEB2-4835-B582-D7ED0F2E1814"), reg));
        }

        [HttpPost, Route("[action]")]
        public IActionResult Update(CustomerDtoReq reg)
        {
            return Ok(_customerService.Update(Guid.Parse("28B3380B-DEB2-4835-B582-D7ED0F2E1814"), reg));
        }

    }
}
