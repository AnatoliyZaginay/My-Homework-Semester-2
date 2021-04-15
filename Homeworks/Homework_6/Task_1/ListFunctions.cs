using System;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Static class that includes functions for working with lists.
    /// </summary>
    public static class ListFunctions
    {
        /// <summary>
        /// Translates all the list items to a new form by function and adds them to the new list.
        /// </summary>
        /// <typeparam name="TValue">Type of given list.</typeparam>
        /// <typeparam name="TResult">Type of returned list.</typeparam>
        /// <param name="list">Given list.</param>
        /// <param name="function">Given function.</param>
        /// <returns>New TResult type list.</returns>
        public static List<TResult> Map<TValue, TResult>(List<TValue> list, Func<TValue, TResult> function)
        {
            var newList = new List<TResult>();

            foreach (TValue listElement in list)
            {
                newList.Add(function(listElement));
            }

            return newList;
        }

        /// <summary>
        /// Filters given list by function and return filtered list.
        /// </summary>
        /// <typeparam name="TValue">Type of given list.</typeparam>
        /// <param name="list">Given list.</param>
        /// <param name="function">Given function.</param>
        public static List<TValue> Filter<TValue>(List<TValue> list, Func<TValue, bool> function)
        {
            var newList = new List<TValue>();

            foreach (TValue listElement in list)
            {
                if (function(listElement))
                {
                    newList.Add(listElement);
                }
            }

            return newList;
        }

        /// <summary>
        /// Accumulates values of all list items in the accumulator using given function.
        /// </summary>
        /// <typeparam name="TValue">Type of given list.</typeparam>
        /// <typeparam name="TResult">Type of accumulator.</typeparam>
        /// <param name="list">Given list.</param>
        /// <param name="accumulator">Accumulator start value.</param>
        /// <param name="function">Given function.</param>
        /// <returns>Value of accumulator.</returns>
        public static TResult Fold<TValue, TResult>(List<TValue> list, TResult accumulator, Func<TResult, TValue, TResult> function)
        {
            foreach (TValue listElement in list)
            {
                accumulator = function(accumulator, listElement);
            }

            return accumulator;
        }
    }
}