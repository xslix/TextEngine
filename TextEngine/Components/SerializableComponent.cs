using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Artemis;
using Artemis.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TextEngine.Components
{
	public class SerializableComponent	: IComponent
	{
		[Key]
		public int Id { get; set; }
		public int? EntityId { get; set; }
		[NotMapped]
		public Entity Entity { get; set; }
	}
}
