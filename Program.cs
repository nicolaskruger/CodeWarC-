using System;
using System.Linq;
using System.Collections.Generic;
//https://www.codewars.com/kata/55f2b110f61eb01779000053/train/csharp
namespace codeWar
{
    class Program
    {
        public int GetSum(int a, int b)
        {
          return (a + b) * (Math.Abs(a - b) + 1) / 2;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
