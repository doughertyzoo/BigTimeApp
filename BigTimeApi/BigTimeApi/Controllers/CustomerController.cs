using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BigTimeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;
        private ICustomerService _customerService;

        public CustomerController(
            ILogger<CustomerController> logger,
            IMapper mapper,
            ICustomerService customerService)
        {
            _logger = logger;
            _mapper = mapper;
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
        public async Task<IActionResult> Create(CreateCustomerForm model)
        {
            await Task.CompletedTask;
            var customer = _mapper.Map<Customer>(model);
            _customerService.Save(customer);
            return Ok(new { message = "Customer created" });
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateCustomerForm model)
        {
            await Task.CompletedTask;
            var customer = _mapper.Map<Customer>(model);
            _customerService.Save(customer);
            return Ok(new { message = "Customer updated" });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            await Task.CompletedTask;
            _customerService.Delete(id);
            return Ok(new { message = "Customer deleted" });
        }
    }
}
