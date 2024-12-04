using System.Collections.Generic;

namespace IB_Company.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable <Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
