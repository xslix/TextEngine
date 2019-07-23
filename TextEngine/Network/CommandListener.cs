using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using TextEngine.General;


namespace TextEngine.Network
{
	class CommandListener
	{
		public Input InputObject { get; set; }
		public void Listen()
		{
			HttpListener listener = new HttpListener();
			listener.Prefixes.Add("http://localhost:3000/gamemodel/playerinput/");
			listener.Start();
			Console.WriteLine("Ожидание подключений...");
			while (true)
			{
				HttpListenerContext context = listener.GetContext();
				HttpListenerRequest request = context.Request;
				
				using (StreamReader stream = new StreamReader(
					request.InputStream, Encoding.UTF8))
				{
					JToken requestBody = JToken.Parse(stream.ReadToEnd());
					Console.WriteLine("Listener: " + requestBody.Value<String>());
					int playerId = requestBody["player"].Value<int>();
					string callingMethod = requestBody["command"].Value<string>();
					InputObject.PlayerInput[playerId][callingMethod].Enqueue(requestBody["body"]); 
				}
				HttpListenerResponse response = context.Response;
				string responseStr = "ok";
				byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
				response.ContentLength64 = buffer.Length;
				Stream output = response.OutputStream;
				output.Write(buffer, 0, buffer.Length);
				// закрываем поток
				output.Close();
			}
		}
	}
}
