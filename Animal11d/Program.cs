using Animal11d.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal11d
{
     class Program
    {
        static void Main(string[] args)
        {
            AnimalShelter form = new AnimalShelter();
            //Application.EnableVisualStyles();

            Application.Run(form);
        }
    }
}
