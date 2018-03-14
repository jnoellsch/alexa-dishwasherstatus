namespace Alexa.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var random = new Random();
            return enumerable.ElementAt(random.Next(enumerable.Count()));
        }
    }
}
