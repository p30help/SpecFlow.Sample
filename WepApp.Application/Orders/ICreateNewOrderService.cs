using WepApp.Domain.Entities;

namespace WepApp.Application.Orders
{
    public interface ICreateNewOrderService
    {
        public Task Execute(Order order);
    }
}
