using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepApp.Domain.Contracts;

namespace WepApp.Tests.Stubs
{
    public class GenderizeServiceStub : IGenderizeService
    {
        public Task<string> GetAsync(string name)
        {
            return Task.FromResult("male");
        }
    }
}
