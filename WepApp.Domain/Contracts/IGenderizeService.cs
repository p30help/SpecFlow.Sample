using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WepApp.Domain.Contracts
{
    public interface IGenderizeService
    {
        public Task<string> GetAsync(string name);
    }
}
