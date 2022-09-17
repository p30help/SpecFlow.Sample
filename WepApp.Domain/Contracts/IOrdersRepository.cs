using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepApp.Domain.Entities;

namespace WepApp.Domain.Contracts
{
    public interface IOrdersRepository
    {
        public Task Insert(Order order);
    }
}
