using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Infrastructure.EF.DTOs;

namespace TradingAppBE.Infrastructure.EF
{
	public class TickersContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Database=TradingApp;Username=postgres;Password=123");
		}

		// DbSets
		public DbSet<TickerDTO> Tickers { get; set; }
		public DbSet<UserDTO> Users { get; set; }
		public DbSet<UserTickerDTO> UserTickers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserTickerDTO>()
				.HasKey(x => new { x.TickerId, x.UserId });
			modelBuilder.Entity<UserTickerDTO>()
				.HasOne(x => x.User)
				.WithMany(x => x.UserTickers)
				.HasForeignKey(x => x.UserId);
			modelBuilder.Entity<UserTickerDTO>()
				.HasOne(x => x.Ticker)
				.WithMany(x => x.UserTickers)
				.HasForeignKey(x => x.TickerId);


			base.OnModelCreating(modelBuilder);
		}
	}
}
