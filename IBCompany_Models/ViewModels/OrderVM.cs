using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace IBCompany_Models
{
	public class OrderVM
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Adress { get; set; }
		public string Status { get; set; }
       





    }
}
