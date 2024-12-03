using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace IB_Company.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string ShortDesc { get; set; }

		public string Description { get; set; }
		[Range(1, int.MaxValue)]
		public double Price { get; set; }
		public string Image { get; set; }
		[Display(Name = "Category Type")]

		public int CategoryId { get; set; } // связь сущности Category и Product
		[ForeignKey("CategoryId")]

		public virtual Category Category { get; set; }


        [Display(Name = "Application Type")]

        public int ApplicationTypeId { get; set; } // связь сущности ApplictaionType и Product
        [ForeignKey("ApplicationTypeId")]

        public virtual ApplicationType ApplicationType { get; set; }



    }
}
