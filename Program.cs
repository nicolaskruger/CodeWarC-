using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace codeWar
{
    class Program
    {
        static Regex reg = new Regex(@"^[:;][-~]?[)D]$");
        public static int CountSmileys(string[] smileys) 
        {
           return smileys.Where(s => reg.IsMatch(s)).Count();
        }
        static void Main(string[] args)
        {
            int c= CountSmileys(new string[]{":)", ";(", ";}", ":-D"});
        }
    }
}
