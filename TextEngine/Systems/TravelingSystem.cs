using System;
using System.Collections.Generic;
using System.Text;
using Artemis;
using Artemis.Attributes;
using Artemis.System;
using TextEngine.Components;
using TextEngine.Structures;

namespace TextEngine.Systems
{
	[ArtemisEntitySystem]
	class TravelingSystem	: EntityProcessingSystem
	{
		public TravelingSystem() : base(Aspect.All(typeof(TravelComponent), typeof(PlacementComponent)))
		{

		}
		public override void Process(Entity entity)
		{
			var travel = entity.GetComponent<TravelComponent>();
			var placement = entity.GetComponent<PlacementComponent>();
			switch (travel.Status)
			{
				case TravelComponent.TravelingStatus.Moving:
				{
					float ms = TimeSpan.FromTicks(this.EntityWorld.Delta).Milliseconds;
					travel.RemainingTime -= ms;

					if (travel.RemainingTime <= 0)
					{
						travel.Status = TravelComponent.TravelingStatus.Stopping;
					}

					return;
				}

				case TravelComponent.TravelingStatus.Starting:
				{
					travel.Status = TravelComponent.TravelingStatus.Moving;
					travel.CurrentRoad = null;
					foreach (var road in placement.Location.Roads)
					{
						if (road.To != travel.Route[0]) continue;
						travel.CurrentRoad = road;
						travel.RemainingTime = road.Duration;
						travel.Route.RemoveAt(0);
						placement.Location = null;
						break;
					}

					if (travel.CurrentRoad == null)
					{
						//send no road
						travel.Status = TravelComponent.TravelingStatus.Stopping;
					}

					break;
				}

				case TravelComponent.TravelingStatus.Stopping:
				{
					placement.Location = travel.CurrentRoad.To;
					if (travel.Route.Count == 0)
					{
						entity.RemoveComponent<TravelComponent>();
						break;
					}

					travel.CurrentRoad = null;
					travel.Status = TravelComponent.TravelingStatus.Starting;

					break;
				}
			}

		}
	}
}
