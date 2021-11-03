using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
	public class Friendlist
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FriendlistId { get; private set; }

		[Required]
		public string AuthorId { get; set; }

		[Required]
		public string FriendId { get; set; }

		public DateTime Created { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual User Author { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual User Friend { get; set; }
	}
}
