using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//TODO Сделать подделку заголовков HTTP
namespace GetWebServerName
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Web Server Name Detecter";
            Console.WriteLine("Enter web-site url");
            Console.WriteLine("Format: www.sitename.com /and others domain");
            string url = Console.ReadLine();
            string url1 = "http://" + url;
            await GetServerName(url1);


            Console.ReadLine();

        }

        private static async Task GetServerName(string url)
        {
            try
            {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            WebHeaderCollection headers = response.Headers;

            for (int i = 0; i < headers.Count; i++)
            {
                if (headers.GetKey(i).ToLower().Contains("server"))
                    Console.WriteLine("{0}: {1}", headers.GetKey(i), headers[i]);
            }
            response.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Сайт не такой простой нужно подделать заголовок");
            }
            finally
            {
                //TODO : add some logic
            }
        }
    }
}
