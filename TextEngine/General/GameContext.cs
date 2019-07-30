using System;
using System.Collections.Generic;
using System.Text;
using Artemis;
using Artemis.Interface;
using Microsoft.EntityFrameworkCore;
using TextEngine.Components;
using TextEngine.Structures;

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
		public DbSet<TravelComponent> TravelComponents { get; set; }
		public DbSet<UnitComponent> UnitComponents { get; set; }


		public DbSet<Road> Roads { get; set; }

		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=139742685;database=textengine;");
		}

		public void AddComponent(Entity entity, IComponent component)
		{
			if (component is SerializableComponent serializableComponent)
			{
				//serializableComponent.EntityId = entity.Id;
				serializableComponent.Entity = entity;
				
			}

		}
		//public void RemoveComponent(Entity entity, IComponent component)
		//{
		//	if (component is SerializableComponent serializableComponent)
		//	{
		//		serializableComponent.EntityId = entity.Id;
		//		serializableComponent.Entity = entity;
		//	}

		//}
	}
}
