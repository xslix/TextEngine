using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TextEngine.Components;

namespace TextEngine.General
{
	public class GameContext	: DbContext
	{
		public DbSet<ItemComponent> ItemComponents { get; set; } 
		public DbSet<LifeTimeComponent> LifeTimeComponents { get; set; }
		public DbSet<LocationComponent> LocationComponents { get; set; }
		public DbSet<OwnerComponent> OwnerComponents { get; set; }
		public DbSet<PlayerComponent> PlayerComponents { get; set; }
		public DbSet<PlacementComponent> PlacementComponents { get; set; }
		public DbSet<UnitComponent> UnitComponents { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=139742685;database=textengine;");
		}
	}
}
