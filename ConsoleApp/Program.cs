using System;
using System.Collections.Generic;
using Data;
using Logic;
using Models;
using Repository;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			InstantgramDbContext dbContext = new InstantgramDbContext(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\InstantgramDB.mdf;integrated security=True;MultipleActiveResultSets=True");
			//try
			//{
			//	dbContext = new InstantgramDbContext(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\InstantgramDB.mdf;integrated security=True;MultipleActiveResultSets=True");
			//}
			//catch (Exception e)
			//{
			//	Console.WriteLine(e.Message);
			//	Console.Write("Pess key to exit...");
			//	Console.Read();
			//	return;
			//}

			//PostRepository postRepo = new PostRepository(dbContext);
			//FriendlistRepository flRepo = new FriendlistRepository(dbContext);
			//FriendRequestRepository frRepo = new FriendRequestRepository(dbContext);

			//HomeLogic hlogic = new HomeLogic(postRepo, flRepo);

			////hlogic.createDatabaseData(userLogic);

			//Console.WriteLine("Users:");
			//List<Post> posts = (List<Post>)hlogic.GetAll();

			//if (users.Count != 0)
			//{
			//	foreach (User user in users)
			//	{
			//		Console.WriteLine($"\t-> {user.Id}: {user.UserName},\tbirth: {user.DateOfBirth}");
			//	}
			//}

			//if (posts.Count != 0)
			//{
			//	foreach (Post post in posts)
			//	{
			//		Console.WriteLine($"\t-> {post.PostId}: {post.ContentType.ToString()}, {post.ContentLocation}\tlikes: {post.LikeCnt}");
			//	}
			//}

		}
	}
}
