using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using ServiceStack.Text;



namespace OneStopRest
{
    class Program
    {
        static void Main()
        {

            var ws = new WebServer(SendResponse, "http://localhost:8080/");
            //http://localhost:8080/name/ http://localhost:8080/family http://localhost:8080/DoubleNestedArray/1
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {

            var url = request.Url.AbsolutePath;
            var opts = new char[] { '/', '\n' };
            var urlonly = url.Split(opts, StringSplitOptions.RemoveEmptyEntries);

            object text = "";
           var text1 = JsonObject.Parse(File.ReadAllText(@"C:\Users\caturner\Documents\GitHub\SimpleServer\SimpleServer\apistore\array.json"));
            
            var node = text1;
            int outnode;
            foreach (var url1 in urlonly)
            {
                var me = node.Values;
                text = node[url1];
            }
            {
                
            }
            
            
            
            
            string model = text.Dump();
            return model;
           // return string.Format("{0}", text);




        }

        public static string FromJson(string json)
        {
            //string json = "{\"number\": 3, \"object\" : { \"t\" : 3, \"whatever\" : \"hi\", \"str\": \"test\"}}";

            dynamic array = JsonObject.Parse(json);
            foreach (var item in array)
            {
                //Console.WriteLine("{0} {1}", item[0].ToString(), item[1].ToString());
            }

            // var serialized = JsonSerializer.
            // var deserialized = JsonObject.Parse(json);

            //if (deserialized != null)
            // {
            //     foreach (object obj in deserialized)
            //     {
            //         myValue = key;
            //     }
            // }
            return "";
        }


    }
}
