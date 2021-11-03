using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using Logic;
using Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebAPI_Instantgram.Hubs;

using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Instantgram_API.Startup))]
namespace Instantgram_API
{
	public class Startup
	{
		//public Startup(IConfiguration configuration)
		//{
		//	Configuration = configuration;
		//}
		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder =>
								  {
									  builder.WithOrigins("http://localhost");
								  });
			});
			services.AddSignalR();

			services.AddControllers();
			//services.AddDbContext<InstantgramDbContext>();
			services.AddDbContext<InstantgramDbContext>(db =>
				db.UseLazyLoadingProxies()
				.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InstantgramDB;Trusted_Connection=True;MultipleActiveResultSets=True")
			);
			services.AddTransient<IHomeLogic, HomeLogic>();
			services.AddTransient<AuthLogic, AuthLogic>();
			services.AddTransient<CommentLogic, CommentLogic>();
			//services.AddTransient<PostHub, PostHub>();

			services.AddTransient<ICommentRepository, CommentRepository>();
			services.AddTransient<IFriendlistRepository, FriendlistRepository>();
			services.AddTransient<IFriendRequestRepository, FriendRequestRepository>();
			services.AddTransient<ILikeRepository, LikeRepository>();
			services.AddTransient<IMessageRepository, MessageRepository>();
			services.AddTransient<IPostRepository, PostRepository>();

			

			services.AddIdentity<IdentityUser, IdentityRole>(
				option =>
				{
					option.Password.RequireDigit = false;
					option.Password.RequiredLength = 6;
					option.Password.RequireNonAlphanumeric = false;
					option.Password.RequireUppercase = false;
					option.Password.RequireLowercase = false;
				}
				).AddEntityFrameworkStores<InstantgramDbContext>().AddDefaultTokenProviders();

			services.AddAuthentication(option =>
			{
				option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = true;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = "http://www.security.org",
					ValidIssuer = "http://www.security.org",
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Paris Berlin Cairo Sydney Tokyo Beijing Rome London Athens"))
				};
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(x => x
				.WithOrigins("http://localhost:4200")
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials());

			//app.UseHttpsRedirection();

			//app.UseCors(x => x
			//	.WithOrigins("http://localhost:4200")
			//	.AllowAnyMethod()
			//	.AllowAnyHeader());

			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				//endpoints.MapHub<PostHub>("/postHub");
			});
		}
	}
}
