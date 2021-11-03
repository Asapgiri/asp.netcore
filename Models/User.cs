using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
	public class User: IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Description { get; set; }

		public DateTime DateOfBirth { get; set; }

		public DateTime Created { get; set; }

		public DateTime Modified { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Message> MessageList { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Friendlist> Friends { get; set; }

		//[NotMapped]
		//[JsonIgnore]
		//public virtual ICollection<Friendlist> Friends2 { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Post> Posts { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Friendrequest> FriendrequestsOutgoing { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Message> MessageListRecived { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Friendrequest> FriendrequestsIncoming { get; set; }

	}
}
