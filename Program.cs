using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
       public static string SongDecoder(string input)
        { 
           return Regex.Replace(input, "(WUB)+", " " ).Trim();
        }
        static void Main(string[] args)
        {
            string str =SongDecoder("RWUBWUBWUBLWUB");
        }
    }
}
