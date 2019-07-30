using System;
using System.Collections.Concurrent;
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
				HttpListenerResponse response = context.Response;
				string responseStr = "ok";
				response.StatusCode = (int) HttpStatusCode.OK;
				using (StreamReader stream = new StreamReader(
					request.InputStream, Encoding.UTF8))
				{
					try
					{
					JToken requestBody = JToken.Parse(stream.ReadToEnd());
					//Console.WriteLine("Listener: " + requestBody.ToString());
					int playerId = requestBody["player"].Value<int>();
					if (!InputObject.PlayerInput.ContainsKey(playerId))
						InputObject.PlayerInput.TryAdd(playerId, new ConcurrentQueue<JToken>());
					InputObject.PlayerInput[playerId].Enqueue(requestBody["command"]);

					}
					catch (Exception e)
					{
						responseStr = "wrong player command format: " + e.ToString();
						response.StatusCode = (int) HttpStatusCode.BadRequest;
					}
				}

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
