using System;
using System.Collections.Generic;
using System.Linq;

namespace MilošBot.Extensions
{
    static class IEnumerableExtension
    {
        public static T GetRandom<T>(this IEnumerable<T> source)
        {
            return source.ElementAt(new Random().Next(source.Count()));
        }
    }
}
