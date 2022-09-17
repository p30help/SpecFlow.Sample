using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepApp.Requests;

namespace WepApp.Tests.Features.Users
{
    public class UserTestContext
    {
        public string Url { get; set; }

        public string HttpMethod { get; set; }

        public object RequestBody { get; set; }

        public HttpResponseMessage ResponseMessage { get; set; }

    }
}
