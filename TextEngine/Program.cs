using System;
using System.Collections.Generic;
using System.Linq;
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


namespace TextEngine
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var gameContext = new GameContext())
			{
				gameContext.Database.EnsureCreated();

				PlayerComponent user1 = new PlayerComponent {VkId = 100};
				PlayerComponent user2 = new PlayerComponent {VkId = 200};
				OwnerComponent owned1 = new OwnerComponent {Player = user1};
				OwnerComponent owned2 = new OwnerComponent {Player = user1};
				OwnerComponent owned3 = new OwnerComponent {Player = user2};


				//gameContext.Players.Add(user1);
				//gameContext.Players.Add(user2);
				//gameContext.Owners.Add(owned1);
				//gameContext.Owners.Add(owned2);
				//gameContext.Owners.Add(owned3);
				//db.SaveChanges();
				Console.WriteLine("Объекты успешно сохранены");

				//var users = db.Users.ToList();
				//Console.WriteLine("Список объектов:");
				//foreach (User u in users)
				//{
				//	Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
				//}
				
				Console.Read();
				Console.WriteLine("Hello World!");
				var entityWorld = new EntityWorld();
				var input = new Input();
				EntitySystem.BlackBoard.SetEntry<Input>("Input", input);
				var commandListener = new CommandListener {InputObject = input};
				EntitySystem.BlackBoard.SetEntry<GameContext>("GameContext", gameContext);
				Entity entity = entityWorld.CreateEntity();
				entity.Refresh();
				entityWorld.EntityManager.AddedComponentEvent += SetEntityId;
				entityWorld.EntityManager.AddedComponentEvent +=
				
			}

		}


	}
}
