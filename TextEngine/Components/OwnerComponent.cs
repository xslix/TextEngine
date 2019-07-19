using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextEngine.Components
{
	class OwnerComponent
	{
	public int? PlayerId { get; set; }
	[ForeignKey("PlayerId")]
	public PlayerComponent Player { get; set; }
	}
}
