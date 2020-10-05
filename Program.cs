using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static string AbbrevName(string name)
        {
          return string.Join(".",name.Split(" ").Select(s => s[0].ToString().ToUpper()));
        }
        static void Main(string[] args)
        {
            
        }
    }
}
