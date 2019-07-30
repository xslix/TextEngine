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
		public ConcurrentDictionary<int,  ConcurrentQueue <JToken> > PlayerInput;
		public ConcurrentDictionary<string, ConcurrentQueue<JToken> > ConsoleInput;

		public Input() {
			PlayerInput = new ConcurrentDictionary<int, ConcurrentQueue<JToken>>();
			ConsoleInput = new ConcurrentDictionary<string, ConcurrentQueue<JToken>>();
		}
	}
}
