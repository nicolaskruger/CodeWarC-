using System;

namespace codeWar
{
    class Program
    {
        public static string FindNeedle(object[] haystack)
        {
            return "found the needle at position " + Array.IndexOf(haystack,"needle");
        }
        static void Main(string[] args)
        {
            
        }
    }
}
