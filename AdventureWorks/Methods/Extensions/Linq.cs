using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventureWorks.Methods.Extensions
{ 
    public static class Linq
    {
        public static double Median(this IEnumerable<double> source)
        {
            if (source.Count() == 0)
                throw new InvalidOperationException("Cannot compute median for an empty set.");

            IOrderedEnumerable<double> sortedList = from number in source
                                                    orderby number
                                                    select number;

            int itemIndex = sortedList.Count() / 2;

            if (sortedList.Count() % 2 == 0) // Even number of items.
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2; 
            else // Odd number of items.
                return sortedList.ElementAt(itemIndex);
        }

        public static IEnumerable<T> TakeEvery<T>(this IEnumerable<T> sequence, int every, int skipInitial)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (every < 1) throw new ArgumentException("'every' must be 1 or greater");
            if (skipInitial < 0)  throw new ArgumentException("'skipInitial' must be 0 or greater");

            var enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (skipInitial == 0)
                {
                    yield return enumerator.Current;
                    skipInitial = every;
                }
                skipInitial--;
            }
        }
    }
}
