using System;
using System.Collections.Generic;
using System.Text;
using Artemis.Interface;
using System.ComponentModel.DataAnnotations;

namespace TextEngine.Components
{
	public class LocationComponent : IComponent
	{
		[Key] public int Id { get; set; }
	}
}
