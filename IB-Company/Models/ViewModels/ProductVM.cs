using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Policy;
using System.Collections.Generic;

namespace IB_Company.Models.ViewModels
{
    public class ProductVM
    {
   
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
    }
}
