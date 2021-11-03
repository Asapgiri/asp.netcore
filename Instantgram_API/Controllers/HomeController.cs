using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using WebAPI_Instantgram.Hubs;

namespace Instantgram_API.Controllers
{
	
	[Authorize]
	[ApiController]
	[Route("home")]
	public class HomeController : ControllerBase
	{
		IHomeLogic logic;
		CommentLogic clogic;
		
		public HomeController(IHomeLogic _hlogic, CommentLogic commentLogic)
		{
			this.logic = _hlogic;
			this.clogic = commentLogic;
		}
		// GET: api/<HomeController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			//read some header somewhat ...
			User user = null; // = GetCurrentSomewhere();
			List<Post> posts = (List<Post>)logic.GetFollowedPosts(user);
			return null;
		}

		// GET api/<HomeController>/5
		/// <summary>
		/// Get one post.
		/// </summary>
		/// <param name="id"></param>
		[HttpGet("{id}")]
		[Route("getpost")]
		public Post GetPostByID(int id)
		{
			return logic.GetOne(id);
		}

		[HttpGet]
		[Route("home")]
		[Route("explore")]
		public IList<Post> GetAllPosts()
        {
			return logic.GetAll();
        }

		// POST api/<HomeController>
		[HttpPost]
		[Route("newpost")]
		public void CreatePost([FromBody] Post post)
		{
			logic.Create(post);
		}

		// PUT api/<HomeController>/5
		[HttpPut("{id}")]
		[Route("updatepost")]
		public void UpdatePost([FromBody] Post post)
		{
			logic.Update(post);
		}

		// DELETE api/<HomeController>/5
		[HttpDelete("{id}")]
		[Route("deletepost")]
		public void DeletePost(int id)
		{
			Post post = logic.GetOne(id);
			logic.Delete(post);
		}

		[HttpPost]
		[Route("commentsend")]
		public void CreateComment([FromBody] Comment comment)
        {
			clogic.AddToCollection(comment);
		}

		[HttpPut("{id}")]
		[Route("commentsend")]
		public void UpdateComment([FromBody] Comment comment)
        {
			clogic.AddToCollection(comment);
		}

		[HttpDelete("{id}")]
		public void DeleteComment(int id)
        {
			Comment comment = clogic.GetOneById(id);
			clogic.RemoveFromCollection(comment);
		}

		[HttpGet]
		[Route("like")]
		public void Like (string name, int postID, AuthLogic authLogic)
        {
			User user = (User)authLogic.GetOneByName(name).Result;
			logic.LikePost(postID, user);
		}
	}
}
