using System;
using System.Collections.Generic;
using System.Linq;

namespace codeWar
{
    class Program
    {
        public static List<int> RemoveSmallest(List<int> numbers)
  {
    numbers.Remove(numbers.DefaultIfEmpty().Min());
    return numbers;
  }
        static void Main(string[] args)
        {
            var lista = RemoveSmallest(new List<int>{1, 2, 3, 4, 5});
        }
    }
}
