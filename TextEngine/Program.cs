using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using Artemis;
using Artemis.Blackboard;
using Artemis.Interface;
using Artemis.Manager;
using Artemis.System;
using Newtonsoft.Json;
using TextEngine.General;
using TextEngine.Network;
using Newtonsoft.Json.Linq;
using TextEngine.Components;
using TextEngine.Structures;
using TextEngine.Systems;


namespace TextEngine
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var gameContext = new GameContext())
			{
				Console.WriteLine("TextEngine");
				//gameContext.Database.EnsureCreated();

				


				//gameContext.Players.Add(user1);
				//gameContext.Players.Add(user2);
				//gameContext.Owners.Add(owned1);
				//gameContext.Owners.Add(owned2);
				//gameContext.Owners.Add(owned3);
				//db.SaveChanges();
			//	Console.WriteLine("Объекты успешно сохранены");

				//var users = db.Users.ToList();
				//Console.WriteLine("Список объектов:");
				//foreach (User u in users)
				//{
				//	Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
				//}
				
				//Console.Read();
				//Console.WriteLine("Hello World!");
				var entityWorld = new EntityWorld();
				entityWorld.EntityManager.AddedComponentEvent += gameContext.AddComponent;
				var input = new Input();
				EntitySystem.BlackBoard.SetEntry<Input>("Input", input);
				var commandListener = new CommandListener {InputObject = input};
				EntitySystem.BlackBoard.SetEntry<GameContext>("GameContext", gameContext);
				entityWorld.InitializeAll(true);
				var locations = new List<Entity>();
				for (int i = 0; i < 4; ++i)
				{
					Entity entity = entityWorld.CreateEntity();
					entity.AddComponent<LocationComponent>( new LocationComponent());
					entity.Refresh();
					entity.GetComponent<LocationComponent>().Id = i;
					locations.Add(entity);
				}
				var roads = new List<Road>();
				for (int i = 0; i < 8; ++i)
				{
					var road = new Road();
					road.Duration = 10000;
					roads.Add(road);

				}

				locations[0].GetComponent<LocationComponent>().Roads.Add(roads[0]);
				locations[1].GetComponent<LocationComponent>().Roads.Add(roads[1]);
				locations[1].GetComponent<LocationComponent>().Roads.Add(roads[2]);
				locations[2].GetComponent<LocationComponent>().Roads.Add(roads[5]);
				locations[2].GetComponent<LocationComponent>().Roads.Add(roads[3]);
				locations[3].GetComponent<LocationComponent>().Roads.Add(roads[4]);
				locations[3].GetComponent<LocationComponent>().Roads.Add(roads[6]);
				locations[3].GetComponent<LocationComponent>().Roads.Add(roads[7]);
				roads[0].From = locations[0].GetComponent<LocationComponent>();
				roads[1].From = locations[1].GetComponent<LocationComponent>();
				roads[2].From = locations[1].GetComponent<LocationComponent>();
				roads[3].From = locations[2].GetComponent<LocationComponent>();
				roads[4].From = locations[3].GetComponent<LocationComponent>();
				roads[5].From = locations[2].GetComponent<LocationComponent>();
				roads[6].From = locations[3].GetComponent<LocationComponent>();
				roads[7].From = locations[3].GetComponent<LocationComponent>();
				roads[0].To = locations[3].GetComponent<LocationComponent>();
				roads[1].To = locations[2].GetComponent<LocationComponent>();
				roads[2].To = locations[3].GetComponent<LocationComponent>();
				roads[3].To = locations[3].GetComponent<LocationComponent>();
				roads[4].To = locations[0].GetComponent<LocationComponent>();
				roads[5].To = locations[1].GetComponent<LocationComponent>();
				roads[6].To = locations[1].GetComponent<LocationComponent>();
				roads[7].To = locations[2].GetComponent<LocationComponent>();

				var players = new List<Entity>();
				for (int i = 0; i < 2; ++i)
				{
					Entity entity = entityWorld.CreateEntity();
					entity.AddComponent<UnitComponent>(new UnitComponent());
					entity.AddComponent<PlayerComponent>(new PlayerComponent());
					entity.AddComponent<PlacementComponent>(new PlacementComponent());
					entity.GetComponent<PlayerComponent>().Id = i;
					entity.Refresh();
					players.Add(entity);
				}

				players[0].GetComponent<PlacementComponent>().Location = locations[0].GetComponent<LocationComponent>();
				players[1].GetComponent<PlacementComponent>().Location = locations[1].GetComponent<LocationComponent>();
			//	players[0].AddComponent<LifeTimeComponent>(new LifeTimeComponent(100000));
				Thread listen = new Thread(new ThreadStart(commandListener.Listen));
				
				listen.Start();
				while (true)
				{
					Thread.Sleep(10);
					entityWorld.Update();
				}

				//gameContext.SaveChangesAsync();
			}

		}


	}
}
