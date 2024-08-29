using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace WpfApp1.Models
{
    public class Cinema
    {
        public string Filmtitel { get; set; }
        public int Filmvarighed { get; set; }
        public string Filmgenre { get; set; }

        public string Biograf { get; set; }
        public string By { get; set; }

        public string Forestillingstidspunkt { get; set; }

        public string Filminstruktør { get; set; }

        public string Premieredato { get; set; }

    }
}
