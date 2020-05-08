using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps.Models
{
    public class Partner
    {
        public int Order { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AgeMet { get; set; }
        public string Background { get; set; }
        public string RateOnScale { get; set; }
    }
}
