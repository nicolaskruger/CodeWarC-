using System;
using System.Linq;
using System.Collections.Generic;
namespace codeWar
{
    class Program
    {
        
        static ISet<char> voewl = new HashSet<char>(){
            'a','e','i','o','u'
        };
        public static int GetVowelCount(string str)
        {
            return str.Count(i => "aeiou".Contains(i));
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(GetVowelCount("aeiou"));            
        }
    }
}
