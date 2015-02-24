using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
	public class PlayerViewModel
	{
		[Required]
		public string Name { get; set; }

		public int ID { get; set; }

		public string ViewTitle { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }
	}
}