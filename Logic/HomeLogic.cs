using Models;
using System;
using Repository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Logic
{
    public class HomeLogic : IHomeLogic
    {
        IPostRepository postRepo;
        //UserRepository userRepo;
        IFriendlistRepository friendlistRepo;
        public HomeLogic(IPostRepository postRepository, IFriendlistRepository friendlistRepository)
        {
            this.postRepo = postRepository;
            this.friendlistRepo = friendlistRepository;
        }
        public void Create(Post item)
        {
            postRepo.AddToCollection(item);
        }
        public void Update(Post item)
        {
            postRepo.AddToCollection(item);
        }

        public void Delete(Post item)
        {
            postRepo.RemoveFromCollection(item);
        }

        public IList<Post> GetAll()
        {
            return postRepo.GetAll();
        }

        public IList<Post> GetFollowedPosts(User user)
        {
            List<Friendlist> friends = (List<Friendlist>)friendlistRepo.GetAll();
            List<Post> posts = new List<Post>();
            foreach (Friendlist friend in friends)
            {
                foreach (Post post in friend.Author.Posts)
                {
                    posts.Add(post);
                }             
            }                              
            return posts;
        }

        public Post GetOne(int itemId)
        {
            return postRepo.GetOneById(itemId);
        }

        public void LikePost(int postId, User user)
        {
            postRepo.LikePost(user, postRepo.GetOneById(postId));
        }

        public void MakeComment(int postId, User user, string comment)
        {
            Comment comm = new Comment();
            comm.ParentPost = postRepo.GetOneById(postId);
            comm.Message = comment;
            comm.AuthorId = user.Id;
            postRepo.CommentPost(user, comm);
        }

  //      public void createDatabaseData(IUserLogic userLogic)
		//{
  //          User user = new User()
  //          {
  //              UserName = "admin",
  //              Email = "bandika@fasszopas.com",
  //              PasswordHash = new PasswordHasher<User>().HashPassword(null, "kecske"),
  //              DateOfBirth = DateTime.Now
  //          };

  //          Post post = new Post()
  //          {
  //              Author = user,
  //              ContentType = Models.EnumTypes.ContentType.Picture,
  //              ContentLocation = "usr/pic/asd.png"
  //          };

  //          userLogic.Create(user);
  //          this.Create(post);
  //          this.LikePost(post.PostId, user);
  //          user = userLogic.GetUserByName(user.UserName);
  //          MakeComment(post.PostId, user, "First Comment!!!");
		//}
    }
}
