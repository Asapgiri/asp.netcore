using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebAPI_Instantgram.Hubs
{
	public class PostHub: Hub
	{
		protected IHubContext<PostHub> _context;

		public PostHub(IHubContext<PostHub> context)
		{
			this._context = context;
		}
		public async Task SendMessage(string user, string message)
		{
			//await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}
