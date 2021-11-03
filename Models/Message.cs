using Models.EnumTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
	public class Message
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int MessageId { get; private set; }

		[Required]
		public string AuthorId { get; set; }

		[Required]
		public string ReceverId { get; set; }

		[Required]
		public MessageType MessageType { get; set; }

		[Required]
		public string LeMessage { get; set; }

		public DateTime Created { get; set; }

		public DateTime LastModified { get; set; }
		
		[NotMapped]
		[JsonIgnore]
		public virtual User Author { get; set; }
		
		[NotMapped]
		[JsonIgnore]
		public virtual User Recever { get; set; }
	}
}
