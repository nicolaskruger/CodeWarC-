using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static int DuplicateCount(string str)
        {
            return str.ToLower().GroupBy(c=>c).Where(c=>c.Count()>1).Count();
        }
        static void Main(string[] args)
        {
            int n= DuplicateCount("aabBcde");
            Console.WriteLine(n);
        }
    }
}
