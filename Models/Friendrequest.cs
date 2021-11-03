using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
	public class Friendrequest
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FrndrqstId { get; private set; }

		[Required]
		public string AuthorId { get; set; }

		[Required]
		public string RequestedId { get; set; }

		public DateTime Created { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual User Author { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual User Requested { get; set; }
	}
}
