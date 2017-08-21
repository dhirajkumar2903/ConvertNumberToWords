using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Website.Common
{
    public class ConvertedRequest
    {
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"\d+",ErrorMessage ="Please enter numeric values")]
        public string Number { get; set; }
    }
}
