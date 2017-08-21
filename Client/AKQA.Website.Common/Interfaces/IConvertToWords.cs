using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Website.Common
{
    public interface IConvertToWords
    {
        ConvertedResponse GetConvertedNumber(string _name, string _number);
    }
}
