using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models.DTO
{
	
	public class VillaNumberUpdateDTO
	{
		[Required]
		public int VillaNo { get; set; }

		public string SpecialDetails { get; set; }
	}
	
}
