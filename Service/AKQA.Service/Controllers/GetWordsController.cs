using AKQA.Common;
using AKQA.Service;
using AKQA.Service.Filters;
using AKQA.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AKQA.Service
{
    public class GetWordsController : ApiController
    {
        [HttpGet]
        [JwtAuthenticationAttribute]
        public Response GetWords(string name, string number)
        {
            GetConvertedNumber _convertedNumber = new GetConvertedNumber();
            return _convertedNumber.GetResponses(name, number);
        }
    }
}
