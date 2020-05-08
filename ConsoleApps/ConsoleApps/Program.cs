using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            //var service = new Isogram.IsogramService();
            //service.Intro();
            //service.Execute();
            var service = new SpreadSheet.SpreadsheetService();
            service.DoStuff();
        }
    }
}
