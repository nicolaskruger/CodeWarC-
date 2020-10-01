using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static int find_it(int[] seq) 
        {
            return seq.GroupBy(s =>s).Where(s => s.Count()%2==1).First().Key;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
