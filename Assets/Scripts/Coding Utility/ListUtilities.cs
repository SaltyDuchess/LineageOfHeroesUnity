using System.Collections.Generic;

namespace LineageOfHeroes.CodingUtilityScripts
{
	public static class ListUtilities
	{
		public static void AddUniqueRangeToList<T>(this IList<T> self, IEnumerable<T> items)
		{
			foreach (var item in items)
				if (!self.Contains(item))
					self.Add(item);
		}
	}
}