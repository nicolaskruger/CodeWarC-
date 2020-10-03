using System;

namespace codeWar
{
    class Program
    {
        public static long find(long n, long v=2){
            n-=(v-1)*(v-1)*(v-1);
            if(n==0) return v -1;
            if(n<0) return -1;
            return find(n,v+1);
        }

        public static long findNb(long m) {
            return find(m);
	    }
        static void Main(string[] args)
        {
            
        }
    }
}
