using Downloader.Application.Repository.Interfaces;
using Downloader.Infrastructure.MappingProfiles;
using Downloader.Infrastructure.Redis;
using Downloader.Infrastructure.Settings;
using Downloader.Infrastructure.YahooApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Downloader
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
			// settings
			services.Configure<ApiSettings>(Configuration.GetSection("Api")).AddSingleton(x => x.GetRequiredService<IOptions<ApiSettings>>().Value);

			//mapper
			services.AddAutoMapper(Assembly.GetAssembly(typeof(TickerProfile)), Assembly.GetAssembly(typeof(PriceProfile)));

			// redis
			services.AddStackExchangeRedisCache(options =>
			{
				options.Configuration = "127.0.0.1:6379"; // TODO - read it from config file
			});

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Downloader", Version = "v1" });
			});

			// register services
			services.AddHttpClient<ITickerRepository, YahooApiRepository>();
			services.AddTransient<ITickerRepository, YahooApiRepository>();
			services.AddTransient<ITickerWritableRepository, RedisRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Downloader v1"));
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
