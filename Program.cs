using System;

namespace codeWar
{
    class Program
    {
        public static string FindNeedle(object[] haystack)
        {
            for (int i = 0; i < haystack.Length; i++)
            {
                if(haystack[i] is string && haystack[i]=="needle") return $"found the needle at position {i}";
            }
            return "";
        }
        static void Main(string[] args)
        {
            
        }
    }
}
