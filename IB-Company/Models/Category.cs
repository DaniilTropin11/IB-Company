using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IB_Company.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[DisplayName ("DisplayOrder")]
		public int DisplayOrder { get; set; }


	}
}
