using System;

using System.Linq;
namespace codeWar
{
    static class Program
    {
        public static string ToJadenCase(this string phrase)
        {
          return string.Join(" ",phrase.Split(" ").Select(s => (s[0].ToString().ToUpper()+s.Substring(1))));
        }
        static void Main(string[] args)
        {
            string str = ToJadenCase("How can mirrors be real if our eyes aren't real");
        }
    }
}
