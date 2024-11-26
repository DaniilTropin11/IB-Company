using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IB_Company.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[DisplayName("DisplayOrder")]
		[Required]
		[Range (1, int.MaxValue,ErrorMessage ="отображения значения категории должен быть больше 0")]
		public int DisplayOrder { get; set; }


	}
}
