using System;
using System.Collections.Generic;

namespace Task_1
{
	/// <summary>
	/// Static class for sorting objects.
	/// </summary>
	public static class Sorting
    {
		/// <summary>
		/// Sorts list with comparer.
		/// </summary>
		/// <typeparam name="T">Type of list elements.</typeparam>
		/// <param name="list">Specified list.</param>
		/// <param name="comparer">Specified comparer</param>
		public static void ListSort<T>(List<T> list, IComparer<T> comparer)
        {
			for (int i = 0; i < list.Count; ++i)
			{
				for (int j = 0; j < list.Count - i - 1; ++j)
				{
					if (comparer.Compare(list[j], list[j + 1]) > 0)
					{
						T swap = list[j];
						list[j] = list[j + 1];
						list[j + 1] = swap;
					}
				}
			}
		}
    }
}