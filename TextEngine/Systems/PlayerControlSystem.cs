using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Newtonsoft.Json.Linq;
using TextEngine.Components;
using TextEngine.General;

namespace TextEngine.Systems 
{
	[ArtemisEntitySystem (GameLoopType = GameLoopType.Update)]
	public class PlayerControlSystem : EntityProcessingSystem
	{
		public PlayerControlSystem() : base(Aspect.One(typeof(PlayerComponent)))
		{

		}

		public override void Process(Entity entity)
		{
			var player = entity.GetComponent<PlayerComponent>();
			var input = BlackBoard.GetEntry<Input>("Input");
		//	if (!input.PlayerInput.ContainsKey(player.Id))
			//	return;
			ConcurrentQueue<JToken> commands = null;
			if (input.PlayerInput.TryGetValue(player.Id, out commands))
			{
				//var commands = input.PlayerInput[player.Id];
				JToken command;
				while (commands.TryDequeue(out command))
				{
					var type = command["type"].Value<string>();
					switch (type)
					{
						case "move":
							ProcessMove(entity, command);
							break;
						case "move_stop":
							ProcessMoveStop(entity, command);
							break;
						default:
							// send type error
							break;
					}

					//Process 

				}
			}
		}

		private void ProcessMove(Entity entity, JToken jToken)
		{
			if (jToken["destination"] == null)
			{
				return;
			}

			var travel = entity.GetComponent<TravelComponent>();
			var placement = entity.GetComponent<PlacementComponent>();
			if (placement == null)
			{
				//send error
				Console.WriteLine("no placement on player");
				return;
			}

			var lastLocation = travel == null ? placement.Location : travel.Route.Last();
			LocationComponent newLocation = null;
			foreach (var road in lastLocation.Roads)
			{
				if (road.To.Id != jToken["destination"].Value<int>()) continue;
				newLocation = road.To;
				break;
			}

			if (newLocation == null)
			{
				//send error
				Console.WriteLine("no way to this location");
				return;
			}
			if (travel == null)
			{
				travel = new TravelComponent
				{
					Status = TravelComponent.TravelingStatus.Starting,
					Route = {newLocation}
				};
				entity.AddComponent(travel);
			}
			else
			{
				travel.Route.Add(newLocation);
			}
			
		}

		private void ProcessMoveStop(Entity entity, JToken jToken)
		{
			var travel = entity.GetComponent<TravelComponent>();
			if (travel == null)
			{
				//send not traveling
				return;
			}
			if (travel.Route.Count > 1)
				travel.Route.RemoveRange(1, travel.Route.Count - 1);
		}



	}
}
