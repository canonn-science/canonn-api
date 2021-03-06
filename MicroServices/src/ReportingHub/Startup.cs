using System;
using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace ReportingHub
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
			services.Configure<RequestLocalizationOptions>(options =>
			{
				var en = new CultureInfo("en-US");
				options.DefaultRequestCulture = new RequestCulture(en, en);
				options.SupportedCultures = new[] { en };
				options.SupportedUICultures = new[] { en };
			});

			services.AddMvc();

			// Add FormFactory
			// Add the file provider to the Razor view engine
			var embeddedFileProvider = new EmbeddedFileProvider(typeof(FormFactory.FF).GetTypeInfo().Assembly, nameof(FormFactory));
			services.Configure<RazorViewEngineOptions>(options =>
			{
				options.FileProviders.Add(embeddedFileProvider);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app
				.UseStaticFiles() // first with default options
				.UseStaticFiles(new StaticFileOptions() // and now for FormBuilder
				{
					RequestPath = String.Empty,
					FileProvider = new EmbeddedFileProvider(typeof(FormFactory.FF).GetTypeInfo().Assembly, nameof(FormFactory)),
				})
				.UseRequestLocalization()
				.UseMvc();
		}
	}
}
