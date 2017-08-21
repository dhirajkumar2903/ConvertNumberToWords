using AKQA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Service.Repository
{
    public interface IGetWords
    {
        Response GetResponses(string name, string number);
    }
}
