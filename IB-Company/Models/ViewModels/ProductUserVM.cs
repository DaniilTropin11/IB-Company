using System.Collections;
using System.Collections.Generic;

namespace IB_Company.Models.ViewModels
{
    public class ProductUserVM
    {
       public ProductUserVM() 
        {
            ProductList = new List<Product>();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public IList<Product>  ProductList { get; set; }
    }
}
