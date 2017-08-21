using System.Web.Http;
using AKQA.Service.Models;

namespace AKQA.Service
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        public string Get(string username, string password)
        {
            return JwtManager.GenerateToken(username);
        }

    }
}
