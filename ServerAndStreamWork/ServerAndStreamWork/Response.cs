using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerAndStreamWork
{
    public class Response
    {


        public static byte[] GetRequest(Request request)
        {
            string html = "<!DOCTYPE html>";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(html);
            return data;
        }
    }
}
