using System;

using System.Linq;
using System.Collections.Generic;
namespace codeWar
{
    class Program
    {
        public static int FindEvenIndex(int[] arr)
        {
          for (int i = 0; i < arr.Length; i++)
          {
             var add = arr.AsSpan();
             var a = add[..i].ToArray().Sum();
             var b = add[(i+1)..^0].ToArray().Sum();
             if(a==b) return i;
          }
          return -1;
        }
        static void Main(string[] args)
        {
            int n = FindEvenIndex(new int[] {1,2,3,4,3,2,1});
        }
    }
}
