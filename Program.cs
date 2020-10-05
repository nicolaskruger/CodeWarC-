using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static long FindNextSquare(long num)
        {
           double sqr = Math.Sqrt(num);
           if((sqr-(long)sqr)!=0) return -1;
           return (long)Math.Pow(sqr+1,2);
        }
        static void Main(string[] args)
        {
            
        }
    }
}
