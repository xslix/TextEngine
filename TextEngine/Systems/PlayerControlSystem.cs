using System;
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
	[ArtemisEntitySystem]
	public class PlayerControlSystem : EntityProcessingSystem
	{
		public PlayerControlSystem() : base(Aspect.One(typeof(PlayerComponent)))
		{

		}

		public override void Process(Entity entity)
		{
			var player = entity.GetComponent<PlayerComponent>();
			var input = BlackBoard.GetEntry<Input>("Input");
			var commands = input.PlayerInput[player.Id];
			JToken command;
			while (commands.TryDequeue(out command))
			{
				var type = command["type"].Value<string>();
				switch (type)
				{
					case "Move":
						ProcessMove(entity, command);
						break;
					default:
						// send type error
						break;
				}

				//Process 

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


	}
}
