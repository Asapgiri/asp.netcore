using Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
	public class Post
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PostId { get; private set; }

		[Required]
		public string AuthorId { get; set; }
		
		[Required]
		public ContentType ContentType { get; set; }

		[Required]
		public string Location { get; set; }

		public DateTime Created { get; set; }

		public int Likes { get; set; }

		[NotMapped]
		public virtual ICollection<Comment> Comments { get; set; }

        //[NotMapped]
        //[JsonIgnore]
        //public virtual ICollection<Like> Likes { get; set; }

        [NotMapped]
        //[JsonIgnore]
        public virtual User Author { get; set; }
    }
}
