using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps.Misc
{
    public class MiscService
    {
        public bool DoStuff()
        {
            var list = new List<Coverage> { new Coverage { Name = "Liability" }, new Coverage { Name = "Property" } };

            if (list.All(x => x.Name != "Property"))
                return false;
            else
                return true;
        }
    }
}
