using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace System.Linq
{
	public static class LINQExtensions
	{
		public static void ForEach<T>(this T[] array, Action<T> action)
		{
			for (int i = 0; i < array.Length; i++)
				action?.Invoke(array[i]);
		}

		public static void ForEach<T>(this T[] array, Action<T, int> action)
		{
			for (int i = 0; i < array.Length; i++)
				action?.Invoke(array[i], i);
		}

		public static void ForEach<T>(this List<T> list, Action<T> action)
		{
			for (int i = 0; i < list.Count; i++)
				action?.Invoke(list[i]);
		}

		public static void ForEach<T>(this List<T> list, Action<T, int> action)
		{
			for (int i = 0; i < list.Count; i++)
				action?.Invoke(list[i], i);
		}
	}
}