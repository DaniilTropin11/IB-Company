using System.ComponentModel.DataAnnotations;

namespace IB_Company.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int DisplayOrder { get; set; }


	}
}
