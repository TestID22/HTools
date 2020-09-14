using System;
using System.Collections.Generic;
using System.Drawing;
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
                    var timer = new System.Windows.Forms.Timer() { Interval = 40 };
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
    }
}
