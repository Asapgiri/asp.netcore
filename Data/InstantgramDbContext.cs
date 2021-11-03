using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public class InstantgramDbContext: IdentityDbContext<IdentityUser>
	{
		private string _connectionString;
		public InstantgramDbContext(DbContextOptions<InstantgramDbContext> opt) : base(opt) { }
		public InstantgramDbContext(string connectionString)
		{
			this._connectionString = connectionString;
			this.Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				if (this._connectionString == null) throw new Exception("ConnectionString Needed!!");
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(this._connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            var appUser = new User
            {
				Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "admin@admin.hu",
                EmailConfirmed = true,
                UserName = "admin",
				NormalizedUserName = "ADMIN",
                SecurityStamp = string.Empty,
				PasswordHash = new PasswordHasher<User>().HashPassword(null, "adminpass")
			};

            var appUser2 = new User
			{
				Id = "02174cf0–9412–4cfe-afbs-59f706d72cf6",
				Email = "ferenc@gmail.hu",
                EmailConfirmed = true,
                UserName = "ferenc",
				NormalizedUserName = "FERENC",
				SecurityStamp = string.Empty,
				PasswordHash = new PasswordHasher<User>().HashPassword(null, "ferencpass")
			};

			var comment = new Comment
			{
				Author = appUser,
				Message = "First"
			};

			var post = new Post
			{
				Author = appUser,
				ContentType = ContentType.Picture,
				Location = "https://images6.fanpop.com/image/photos/36100000/Boss-This-image-boss-this-36181814-397-380.png",
				Comments = new List<Comment>() { comment }
			};


            modelBuilder.Entity<User>().HasData(appUser);
            modelBuilder.Entity<User>().HasData(appUser2);

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
				UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6",
				UserId = "02174cf0–9412–4cfe-afbs-59f706d72cf6"
			});

			modelBuilder.Entity<Post>(entity =>
			{
				entity
					.HasOne(post => post.Author)
					.WithMany(author => author.Posts)
					.HasForeignKey(post => post.AuthorId);
			});

			modelBuilder.Entity<Comment>(entity =>
			{
				entity
					.HasOne(comm => comm.ParentPost)
					.WithMany(post => post.Comments)
					.HasForeignKey(comm => comm.ParentPostId);
				entity
					.HasOne(comm => comm.Author)
					.WithMany()
					.HasForeignKey(comm => comm.AuthorId)
					.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<Message>(entity =>
			{
				entity
					.HasOne(msg => msg.Author)
					.WithMany(user => user.MessageList)
					.HasForeignKey(msg => msg.AuthorId);
				entity
					.HasOne(msg => msg.Recever)
					.WithMany(user => user.MessageListRecived) //// <===  here
					.HasForeignKey(msg => msg.ReceverId)
					.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<Like>(entity =>
			{
				entity
					.HasOne(like => like.Author)
					.WithMany()
					.HasForeignKey(like => like.AuthorId)
					.OnDelete(DeleteBehavior.NoAction);
				//entity
					//.HasOne(like => like.Post)
					//.WithMany(post => post.)
					//.HasForeignKey(like => like.PostId);
			});

			modelBuilder.Entity<Friendrequest>(entity =>
			{
				entity
					.HasOne(fr => fr.Author)
					.WithMany(user => user.FriendrequestsOutgoing)
					.HasForeignKey(fr => fr.AuthorId);
				entity
					.HasOne(fr => fr.Requested)
					.WithMany(user => user.FriendrequestsIncoming) //// <===  here
					.HasForeignKey(fr => fr.RequestedId)
					.OnDelete(DeleteBehavior.NoAction);

			});

			modelBuilder.Entity<Friendlist>(entity =>
			{
				entity
					.HasOne(fl => fl.Author)
					.WithMany(user => user.Friends)
					.HasForeignKey(fl => fl.AuthorId);
				//entity
				//	.HasOne(fl => fl.Friend)
				//	.WithMany(user => user.Friends2) //// <===  here
				//	.HasForeignKey(fl => fl.FriendId);
			});
		}

        //public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Like> Likes { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Friendlist> Friendlist { get; set; }
		public DbSet<Friendrequest> Friendrequest { get; set; }
	}
}
