using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AESWork
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Controler control = new Controler();
            while (true)
            {
                control.Start();
                Console.WriteLine("Nhan enter de tiep tuc");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
