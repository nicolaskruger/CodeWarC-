using System;

namespace codeWar
{
    class Program
    {
        public static string Encode(string s, int n)
        {
            // Your code here
            string[] ss = new string[n];
            int i=0;
            int di=1;
            while(s!=""){
                ss[i]+=s[0];
                i+=di;
                if(i==n){i=n-2;di=-1;}
                if(i==-1){i=1;di=1;}
                s = s.Substring(1);
            }
            return string.Join("",ss);
        }

        public static string Decode(string s, int n)
        {
            string [] st = new string[n];
            int L = s.Length;
            int len = s.Length/(2*n-2);
            int res = s.Length%(2*n-2);
            int i=0;
            int di=1;
            string store="";
            while(s!=""){
                int tam=0;
                if(i==0||i==n-1){
                    tam=len+(res>0?1:0);
                    res--;
                    st[i]=s.Substring(0,tam);
                }else{
                    tam=len*2+(res>0?1:0);
                    res--;
                    st[i]=s.Substring(0,tam);
                }
                s=s.Substring(tam);
                i++;
            }
            i=0;
            while(L--!=0){
                store+=st[i][0];
                st[i] = st[i].Substring(1);
                i+=di;
                if(i==n){i=n-2;di=-1;}
                if(i==-1){i=1;di=1;}
            }

            return store;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Decode("WEAREDISCOVEREDFLEEATONCE",8));
        }
    }
}
