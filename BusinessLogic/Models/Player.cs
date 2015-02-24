using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class Player
	{
		[Required]
		public string Name { get; set; }

		public int ID { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }
	}
}