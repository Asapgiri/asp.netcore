using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
	public class Like
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int LikeId { get; private set; }

		[Required]
		public string AuthorId { get; set; }

		[Required]
		public int PostId { get; set; }

		public DateTime Created { get; set; }

		[NotMapped]
		public virtual User Author { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual Post Post { get; set; }
	}
}
