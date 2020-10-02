using System;
using System.Linq;
using System.Collections.Generic;
namespace codeWar
{
    class Program
    {
        public static int Test(string numbers)
        { 
            int[] num = numbers.Split(" ").Select( s => int.Parse(s)).ToArray();
            int odd = num.Take(3).Where(s => s%2 ==1).Count();
            int even = num.Take(3).Where(s => s%2 ==0).Count();
            int tipe = odd>even? 0:1;
            int val= num.Where(n => n%2==tipe).First();
            return num.ToList().IndexOf(val)+1;
        }
        static void Main(string[] args)
        {
            int v = Test("2 4 7 8 10");
        }
    }
}
