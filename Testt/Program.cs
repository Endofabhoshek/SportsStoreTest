using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i <= 100; i = i + 2)
            {
                if (i % 8 != 0)
                {
                    Console.Write(i + "+");
                    sum = sum + i;
                }                
            }
            Console.Write("=" + sum);
            Console.Read();
        }
    }
}
