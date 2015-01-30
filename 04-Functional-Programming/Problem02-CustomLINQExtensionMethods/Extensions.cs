using System;
using System.Collections.Generic;

public static class Extensions
{
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
    foreach (T value in collection)
        {
            if (!predicate(value)) yield return value;
        }
    }

    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
    {
    for (int i = 0; i < count; i++)
        {
        foreach (var item in collection)
            {
                yield return item; 
            }
        }
    }

    public static IEnumerable<string> WhereEndsWith<T>(this IEnumerable<string> collection, IEnumerable<string> suffixes)
    {
    foreach (var s in collection)
        {
        foreach (var suff in suffixes)
            {
                if (s.EndsWith(suff))
                {
                    yield return s;
                }
            }
        }
    }
}