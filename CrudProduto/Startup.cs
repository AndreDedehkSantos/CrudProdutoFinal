using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;
using CrudProduto.Bussiness.Services;
using CrudProduto.Models.ViewModels;
using CrudProduto.Dal;

namespace CrudProduto
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

		    services.AddDbContext<CrudProdutoContext>(options =>
					options.UseMySql(Configuration.GetConnectionString("CrudProdutoContext"), builder =>
						builder.MigrationsAssembly("CrudProduto")));

			services.AddScoped<ProdutoDal>();
			services.AddScoped<LinhaProdutoDal>();
			services.AddScoped<AcessorioBasicoDal>();
			services.AddScoped<AcessorioOpcionalDal>();
			services.AddScoped<FichaTecnicaDal>();
			services.AddScoped<UsuarioDal>();
			services.AddScoped<LogDal>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Usuarios}/{action=Create}");
			});
		}
	}
}
