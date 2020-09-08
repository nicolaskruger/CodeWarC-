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
        public static char FindMissingLetter(char[] array)
        {
          for (int i = 0; i < array.Length; i++)
          {
              if(array[i]!=(array[i+1]-1)){
                  return (char)(array[i]+1);
              }
          }
          return ' ';
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(FindMissingLetter(new [] { 'a','b','c','d','f' }));
        }
    }
}
