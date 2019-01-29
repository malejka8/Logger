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
            //for (int i = 0; i < args.Length; i++)
            //{
            //    Console.WriteLine(args[i]);
            //}
            List<string> temp = new List<string>();
            temp.AddRange(args);
            //foreach (var item in args)
            //{
            //    temp.Add(item);
            //}
            while (temp.Count > 0)
            {
                Console.WriteLine(temp[0]);
                temp.Remove(temp[0]);
            }
            Console.Read();
        }
    }
}
