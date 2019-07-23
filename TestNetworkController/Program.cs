using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TestNetworkController
{
  
    class Program
    {

        static void Main(string[] args)
        {
            Thread listen = new Thread(new ThreadStart(Listen));
            listen.Start();
            Thread send = new Thread(new ThreadStart(Send));
            send.Start();
            while (true) 
                Thread.Sleep(1000);
        }

        public static void Listen()
        {
            HttpListener listener = new HttpListener();
            // установка адресов прослушки
            listener.Prefixes.Add("http://localhost:3000/controller/");
            listener.Start();
            Console.WriteLine("Ожидание подключений...");
            // метод GetContext блокирует текущий поток, ожидая получение запроса 
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                using (StreamReader stream = new StreamReader(
                    request.InputStream, Encoding.UTF8))
                {
                    Console.WriteLine("Listener: " + stream.ReadToEnd());
                }
                // получаем объект ответа
                HttpListenerResponse response = context.Response;
                // создаем ответ в виде кода html
                string responseStr = "ok";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
                // получаем поток ответа и пишем в него ответ
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // закрываем поток
                output.Close();
            }
        }

        public static void Send()
        {
            while (true)
            {
                var command = Console.ReadLine();
                
                string site = "http://localhost:3000/controller/";

                HttpWebRequest req = (HttpWebRequest) HttpWebRequest.Create(site);
                req.Method = WebRequestMethods.Http.Post;
                // преобразуем данные в массив байтов
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(command);
                // устанавливаем тип содержимого - параметр ContentType
                req.ContentType = "application/x-www-form-urlencoded";
                // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
                req.ContentLength = byteArray.Length;

                //записываем данные в поток запроса
                using (Stream dataStream = req.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                HttpWebResponse resp = (HttpWebResponse) req.GetResponse();

                using (StreamReader stream = new StreamReader(
                    resp.GetResponseStream(), Encoding.UTF8))
                {
                    Console.WriteLine("Sender: " + stream.ReadToEnd());
                }
            }
        }
    }
}
