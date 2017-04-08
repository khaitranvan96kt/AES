using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AESWork
{
    class Animation
    {      
        public void Turn()
        {
           int counter = 0;
            while (true)
            {
                counter++;
                switch (counter % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write(@"\"); break;
                    case 3: Console.Write("|"); break;
                }
                Thread.Sleep(100);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            
        }
    }
}
