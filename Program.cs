using System;
using System.Collections.Generic;
using System.Linq;
namespace codeWar
{
    class Program
    {
            static List<List<long>> part = new List<List<long>>(); 
            static void UniqueParts(long n) 
            { 
                part.Clear();
                // An array to store a partition 
                long[] p = new long[n];  

                // Index of last element in a  
                // partition 
                int k = 0;  

                // Initialize first partition as  
                // number itself 
                p[k] = n;  

                // This loop first prints current  
                // partition, then generates next 
                // partition. The loop stops when  
                // the current partition has all 1s 
                while (true) 
                { 

                    // print current partition

                    // printArray(p, k+1); 
                    part.Add(p.Take(k+1).ToList());
                    // Generate next partition 

                    // Find the rightmost non-one  
                    // value in p[]. Also, update  
                    // the rem_val so that we know 
                    // how much value can be  
                    // accommodated 
                    long rem_val = 0; 

                    while (k >= 0 && p[k] == 1) 
                    { 
                        rem_val += p[k]; 
                        k--; 
                    } 

                    // if k < 0, all the values are 1 so 
                    // there are no more partitions 
                    if (k < 0)  
                        return; 

                    // Decrease the p[k] found above  
                    // and adjust the rem_val 
                    p[k]--; 
                    rem_val++; 


                    // If rem_val is more, then the sorted 
                    // order is violated. Divide rem_val in 
                    // different values of size p[k] and copy 
                    // these values at different positions 
                    // after p[k] 
                    while (rem_val > p[k]) 
                    { 
                        p[k+1] = p[k]; 
                        rem_val = rem_val - p[k]; 
                        k++; 
                    } 

                    // Copy rem_val to next position and  
                    // increment position 
                    p[k+1] = rem_val; 
                    k++; 
                } 
            } 
        public static string Part(long n)
        {
          UniqueParts(n);
          var prod = part.Select(s => s.Aggregate((long)1,(total,next)=>total*next)).Distinct().OrderBy(c => c).ToList();
          long range = prod.Last()-prod.First();
          double media = (double)prod.Sum()/prod.Count;
          double mediana = prod.Count%2==1?prod[prod.Count/2]:(double)(prod[prod.Count/2]+prod[prod.Count/2-1])/2;
          return $"Range: {range} Average: {media.ToString("0.00")} Median: {mediana.ToString("0.00")}";
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(Part(5));
        }
    }
}
