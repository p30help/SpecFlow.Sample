using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Infra.Repos
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly MainContext _context;

        public OrdersRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Insert(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
