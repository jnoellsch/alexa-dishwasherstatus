namespace Alexa.Functions.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides useful additions to <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var random = new Random();
            return enumerable.ElementAt(random.Next(enumerable.Count()));
        }
    }
}
