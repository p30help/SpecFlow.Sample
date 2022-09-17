using Microsoft.AspNetCore.Mvc;
using WepApp.Application.Orders;
using WepApp.Domain.Entities;

namespace SpecFlow.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        
        private readonly ILogger<OrdersController> _logger;
        private readonly ICreateNewOrderService _createNewOrderService;

        public OrdersController(ILogger<OrdersController> logger, ICreateNewOrderService createNewOrderService)
        {
            _logger = logger;
            _createNewOrderService = createNewOrderService;
        }

        [HttpPost("CreateNewOrder")]
        public async Task CreateNewOrder(Order order)
        {
            await _createNewOrderService.Execute(order);
        }
    }
}