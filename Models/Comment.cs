using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
	public class Comment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CommentId { get; private set; }

		[Required]
		public string AuthorId { get; set; }

		[Required]
		public int ParentPostId { get; set; }

		[Required]
		public string Message { get; set; }

		public DateTime Created { get; set; }

		public DateTime LastModified { get; set; }
		
		[NotMapped]
		public virtual User Author { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual Post ParentPost { get; set; }

	}
}
