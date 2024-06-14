using Microsoft.AspNetCore.Mvc;

namespace BigTimeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private ICustomerService _customerService;

        public CustomerController(
            ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            await Task.CompletedTask;
            var customers = _customerService.GetList();
            return Ok(customers);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            await Task.CompletedTask;
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateCustomerRequestModel model)
        {
            await Task.CompletedTask;
            _customerService.Create(model);
            return Ok(new { message = "Customer created" });
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateCustomerRequestModel model)
        {
            await Task.CompletedTask;
            _customerService.Update(model);
            return Ok(new { message = "Customer updated" });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Task.CompletedTask;
            _customerService.Delete(id);
            return Ok(new { message = "Customer deleted" });
        }
    }
}
