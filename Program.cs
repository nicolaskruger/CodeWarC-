using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
        public static string SongDecoder(string input)
        { 
            bool space = true;
            return
            string.Join("",
            string.Join("",input.Split("WUB").Select(s=>{
               return s+" ";
           })).Trim().Split("").Select(s =>{
               if(space && s==" "){
                   space = false;
                   return " ";
               }
               space = true;
               return s;
           }));
           
        }
        static void Main(string[] args)
        {
            string str =SongDecoder("AWUBBWUBCWUBD");
        }
    }
}
