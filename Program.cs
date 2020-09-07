using System;

namespace codeWar
{
    class Program
    {
        public static int SomaString(string str){
            int soma = 0;
            for (int i = 0; i < str.Length; i++)
            {
                soma+=int.Parse(str[i].ToString());
            }
            return soma;
        }
         public static int DigitalRoot(long n)
        {
          // Your awesome code here!
          int val= SomaString(n.ToString());
          if(val>9){
              return DigitalRoot(val);
          }
          return val;
        }
        static void Main(string[] args)
        {
            DigitalRoot(111111);
        }
    }
}
