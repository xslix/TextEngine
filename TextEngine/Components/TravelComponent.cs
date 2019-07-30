using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using TextEngine.Structures;

namespace TextEngine.Components
{
	public class TravelComponent : SerializableComponent
	{
		public Road CurrentRoad { get; set; }
		public float RemainingTime { get; set; }
		public List<LocationComponent> Route { get; set; }

		public enum TravelingStatus
		{
			Starting,
			Moving,
			Stopping,

		}

		public TravelingStatus Status { get; set; }

		public TravelComponent()
		{
			CurrentRoad = null;
			RemainingTime = 0;
			Route = new List<LocationComponent>();
		}
	}
}
