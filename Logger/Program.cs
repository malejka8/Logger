using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLogger.Logger logger = new FileLogger.Logger("Info.txt");
            while (true)
            {
                Console.WriteLine("Wpisz coś");
                var text = Console.ReadLine();                
                logger.Log(text);
                //Console.Read();
            }
        }
    }
}
