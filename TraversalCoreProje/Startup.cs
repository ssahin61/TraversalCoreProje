using BussinesLayer.Container;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TraversalCoreProje.Models;

namespace TraversalCoreProje
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<Context>();
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>
				().AddErrorDescriber<CustomIdentityValidator>
				().AddEntityFrameworkStores<Context>();

			services.AddHttpClient();

			services.ContainerDependencies();

			services.AddAutoMapper(typeof(Startup));

			services.CustomerValidator();

			services.AddControllersWithViews().AddFluentValidation();


			//services.AddIdentity<AppUser, AppRole>(p =>
			//{
			//	p.Password.RequiredLength = 6;
			//	p.Password.RequireNonAlphanumeric = false;
			//	p.Password.RequireLowercase = false;
			//	p.Password.RequireUppercase = false;
			//	p.Password.RequireDigit = true;
			//}).AddEntityFrameworkStores<Context>();


			services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});

			services.AddMvc();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Login/SignIn";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}


			app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code={0}");

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthentication();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Login}/{action=SignIn}/{id?}");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});


		}
	}
}
