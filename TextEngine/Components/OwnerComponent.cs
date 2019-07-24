using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artemis;

namespace TextEngine.Components
{
	public class OwnerComponent	: SerializableComponent
	{

	//public int? PlayerId { get; set; }
	//[ForeignKey("PlayerId")]
	public PlayerComponent Player { get; set; }

	}
}
