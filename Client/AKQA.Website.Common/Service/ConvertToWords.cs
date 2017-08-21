using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Website.Common
{
    public class ConvertToWords : IConvertToWords
    {
        public ConvertedResponse GetConvertedNumber(string _name, string _number)
        {
            var _convertedNumber = new ConvertedResponse();
            _convertedNumber = GetConvertedNumberFromService(_name, _number);
            return _convertedNumber;
        }

        private ConvertedResponse GetConvertedNumberFromService(string _name, string _number)
        {
            string _serviceUrl = Helper.ServiceUrl(Constants.ConvertServiceUrl) + _name + "/" + _number + "/";
            var response = RequestHelper.GetRestResponse<ConvertedResponse>(_serviceUrl);
            return response;
        }
    }
}
