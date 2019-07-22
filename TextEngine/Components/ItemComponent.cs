using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Artemis;
using Artemis.Interface;

namespace TextEngine.Components
{
	public class ItemComponent : IComponent
	{
		[Key] public int Id { get; set; }
		public Entity ChainedEntity { get; set; }

	}
}
