using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static string ReverseWords(string str)
        {
        	return string.Join(" ",str.Split(" ").Select(s => string.Join("",s.Reverse())));
        }
        static void Main(string[] args)
        {
            string rev = ReverseWords("This is an example!");
        }
    }
}
