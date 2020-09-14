using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace clientBot4._7
{
    public class WebCommand
    {
        private string url;
        public string command { get; set; } = default;

        public WebCommand(string url)
        {
            this.url = url;
            this.command = GetCommandFromServer(this.url);
        }

        private string GetCommandFromServer(string url)
        {
            string data = default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                data = sr.ReadToEnd();
            }
            Match re = Regex.Match(data, @"<p>command(\s\w\w\w)</p>");
            string command = re.Groups[1].Value;
            return command;
        }
    }
}
