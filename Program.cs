using System;
using System.Linq;
namespace codeWar
{
    class Program
    {
      public string dnaToRna(string dna)
      {
        return string.Join("",dna.Select(s => {
          if(s == 'T') return 'U';
          return s;
        }));
      }
        static void Main(string[] args)
        {
            
        }
    }
}
