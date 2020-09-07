using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    static class Program
    {
        public static void print<T>(this T[] arr){
            foreach (var a in arr)
            {
                System.Console.WriteLine(a);
            }
        }
        public static string Longest(string s1, string s2)
        {
            s1+=s2;
            char[] ss= s1.OrderBy(c=>c).Distinct().ToArray();
            return string.Join("",ss);
        }
        static void Main(string[] args)
        {
            string st = Longest("xyaabbbccccdefww","xxxxyyyyabklmopq");
            System.Console.WriteLine(st);
        }
    }
}
