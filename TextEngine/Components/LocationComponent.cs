using System;
using System.Collections.Generic;
using System.Text;
using Artemis.Interface;
using System.ComponentModel.DataAnnotations;
using Artemis;

namespace TextEngine.Components
{
	public class LocationComponent : SerializableComponent
	{
		public List<LocationComponent> Roads { get; set; }
	}
}
