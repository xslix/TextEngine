using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TextEngine.Components;

namespace TextEngine.Structures
{
	public class Road
	{
		[Key]
		public int Id { get; set; }
		public LocationComponent From { get; set; }
		public LocationComponent To { get; set; }
		public int Duration { get; set; }
	}
}
