using System;
using System.Collections.Generic;
using System.Text;

namespace TextEngine.Components
{
	public class TravelComponent : SerializableComponent
	{
		public List<LocationComponent> Route { get; set; }

		public enum TravelingStatus
		{
			Starting,
			Moving,
			Stopping,

		}

		public TravelingStatus Status { get; set; }

	}
}
