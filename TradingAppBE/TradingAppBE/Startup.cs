using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using TradingAppBE.Infrastructure.DownloaderApi;
using TradingAppBE.Infrastructure.EF;
using TradingAppBE.Infrastructure.MappingProfiles;
using TradingAppBE.Infrastructure.PostgreSQL;
using TradingAppBE.Infrastructure.Redis;
using TradingAppBE.Infrastructure.Settings;
using TrradingAppBE.Application.Algorithms;
using TrradingAppBE.Application.Algorithms.Interfaces;
using TrradingAppBE.Application.Repository.Interfaces;
using TrradingAppBE.Application.Services;
using TrradingAppBE.Application.Services.Interfaces;

namespace TradingAppBE
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
			// authentication


			// settings
			services.Configure<ApiSettings>(Configuration.GetSection("Api")).AddSingleton(x => x.GetRequiredService<IOptions<ApiSettings>>().Value);

			// automapper
			services.AddAutoMapper(Assembly.GetAssembly(typeof(TickerProfile)), Assembly.GetAssembly(typeof(PriceProfile)));
			services.AddAutoMapper(Assembly.GetAssembly(typeof(TradingAppBE.MappingProfiles.TickerProfile)),
								Assembly.GetAssembly(typeof(TradingAppBE.MappingProfiles.PriceProfile)),
								Assembly.GetAssembly(typeof(TradingAppBE.MappingProfiles.MovingAverageProfile)),
								Assembly.GetAssembly(typeof(TradingAppBE.MappingProfiles.AnalyticsProfile)));

			// redis
			services.AddStackExchangeRedisCache(options =>
			{
				options.Configuration = "127.0.0.1:6379"; // TODO - read it from config file
			});

			// postgreDB
			services.AddDbContext<TickersContext>();



			// services
			services.AddTransient<IUserTickersRepository, UserTickersRepository>();
			services.AddHttpClient<IDownloaderApiRepository, DownloaderApiRepository>();
			services.AddTransient<IMovingAverageAlgorithm, SMA>();
			services.AddTransient<ITickerRepository, RedisRepository>();
			services.AddTransient<IDownloaderApiRepository, DownloaderApiRepository>();
			services.AddTransient<IDataService, DataService>();
			services.AddTransient<IAnalyticsService, AnalyticsService>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "TradingAppBE", Version = "v1" });
			});
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(policy =>
				{
					policy.AllowAnyOrigin();
				});

			});

			services.AddCors(options =>
			{
				options.AddPolicy("FRONTEND_CORS", options =>
				{
					options.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradingAppBE v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
