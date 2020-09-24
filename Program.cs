using System;

namespace codeWar
{
    class Program
    {
        public static int NbYear(int p0, double percent, int aug, int p) {
            int cont=0;
            double P0 =(double)p0;
            while(P0<p){
                cont++;
                P0+=(int)(P0*percent/100+aug);
            }
            return cont;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(NbYear(1000,2,50,1214));    
        }
    }
}
