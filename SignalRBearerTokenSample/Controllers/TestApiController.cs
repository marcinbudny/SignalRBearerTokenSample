using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SignalRBearerTokenSample.Controllers
{
    public class TestApiController : ApiController
    {
        [HttpGet]
        [Route("api/whoami")]
        public string GetUserName()
        {
            if (User.Identity.IsAuthenticated)
                return User.Identity.Name;

            return "anonymous";
        }
    }
}