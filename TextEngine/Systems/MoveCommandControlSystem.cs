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
	public class MoveCommandControlSystem : EntityProcessingSystem
	{
		public MoveCommandControlSystem() : base(Aspect.One(typeof(PlayerComponent)))
		{

		}

		public override void Process(Entity entity)
		{
			var player = entity.GetComponent<PlayerComponent>();
			var transform = entity.GetComponent<TransformComponent>();
			
			var input = BlackBoard.GetEntry<Input>("Input");
			var commands = input.PlayerInput[player.Id]["MoveCommand"];
			JToken command;
			while ( commands.TryDequeue(out command) )
			{ 

				//Process 

			}
		}
	}
}
