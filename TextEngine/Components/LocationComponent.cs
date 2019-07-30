using System;
using System.Collections.Generic;
using System.Text;
using Artemis.Interface;
using System.ComponentModel.DataAnnotations;
using Artemis;
using TextEngine.Structures;

namespace TextEngine.Components
{
	public class LocationComponent : SerializableComponent
	{
		public List<Road> Roads { get; set; }

		public LocationComponent()
		{
			Roads = new List<Road>();
		}
	}
}
