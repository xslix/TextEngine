using System;
using System.Collections.Generic;
using System.Threading;
using Artemis;
using Artemis.Blackboard;
using Artemis.System;
using Newtonsoft.Json;
using TextEngine.General;
using TextEngine.Network;
using Newtonsoft.Json.Linq;


namespace TextEngine
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			 var entityWorld = new EntityWorld();
			 var input = new Input();
			 EntitySystem.BlackBoard.SetEntry<Input>("Input", input);
			 var commandListener = new CommandListener {InputObject = input};



		}
	}
}
