using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Application.Orders
{
    public class CreateNewOrderService : ICreateNewOrderService
    {
        private IOrdersRepository _ordersRepository { get; set; }

        public CreateNewOrderService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Execute(Order order)
        {
            await _ordersRepository.Insert(order);
        }
    }
}
