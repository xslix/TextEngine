﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using Artemis;
using Artemis.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TextEngine.Components
{
	public class PlayerComponent : SerializableComponent
	{
		public int VkId { get; set; }
		
	}
}
