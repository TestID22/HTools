using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ServerAndStreamWork
{
    public class Request
    {
        string host;
        string userAgent;
        string accept;
        string acceptLanguage;

        public Request(string host, string userAgent, string accept, string acceptLanguage)
        {
            this.host = host;
            this.userAgent = userAgent;
            this.accept = accept;
            this.acceptLanguage = acceptLanguage;
        }

        public static Request Parse(String request)
        {
            Request requestPacket;
            string[] paresdRequest = request.Split('\n');
            requestPacket = new Request(paresdRequest[0], paresdRequest[1], paresdRequest[2], paresdRequest[3]);
            Console.WriteLine(requestPacket.host);
            return requestPacket;
        }
    }
}
