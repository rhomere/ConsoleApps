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
            // IsoGramn
            //var service = new Isogram.IsogramService();
            //service.Intro();
            //service.Execute();

            // SpreadSheet
            //var service = new SpreadSheet.SpreadsheetService();
            //service.DoStuff();

            // Email - Microsoft Exchange WebServices
            // works for Outlook, UCF.EdU,
            // doesn't work for Marriott, Gmail
            var service = new Email.EmailService("emailAddress", "password");
            var emails = service.GetEmails();
        }
    }
}
