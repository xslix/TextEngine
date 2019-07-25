using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Artemis.Interface;

namespace TextEngine.Components	
{
	public class PlacementComponent : SerializableComponent
	{

		//public int? LocationId { get; set; }
	//	[ForeignKey("LocationId")]
		public LocationComponent Location { get; set; }




	}
}
