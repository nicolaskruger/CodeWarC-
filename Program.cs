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
           })).Trim().Where(s =>{
               if(space && s==' '){
                   space = false;
                   return true;
               }
               else if(s==' ' ) return false;
               space = true;
               return true;
           }));
           
        }
        static void Main(string[] args)
        {
            string str =SongDecoder("RWUBWUBWUBLWUB");
        }
    }
}
