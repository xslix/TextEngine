using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace TextEngine.General
{
	public class Input
	{
		public Dictionary<int,  ConcurrentQueue <JToken> > PlayerInput;
		public Dictionary<string, ConcurrentQueue<JToken> > ConsoleInput;

	}
}
