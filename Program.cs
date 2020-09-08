using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    static class Program
    {
        
        public static string Longest(string s1, string s2)
        {
            s1+=s2;
            char[] ss= s1.OrderBy(c=>c).Distinct().ToArray();
            return string.Join("",ss);
        }
        public static void print<T>(this T[] lis){
            System.Console.WriteLine(string.Join("\n",lis));
        }
        public static char FindMissingLetter(char[] array)
        {
          var combo = from a in array
                      from b in array
                      select new{
                          a,
                          b
                      };
          combo=  combo.Where((c)=>((c.a<c.b)&&c.a==(c.b-1)));
            combo.ToArray().print();
          return ' ';
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(FindMissingLetter(new [] { 'a','b','c','d','f' }));
        }
    }
}
