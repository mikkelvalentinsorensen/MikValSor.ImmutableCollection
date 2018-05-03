using System.Collections.Generic;
using System.Linq;

namespace MikValSor.Immutable
{
	/// <summary>
	///		Extender class for bringing immutable extensions to Enumerable classes
	/// </summary>
	public static class EnumerableExtender
	{
		/// <summary>
		///		Function for creating a Immutable representation of the source enumerable.
		/// </summary>
		/// <typeparam name="TSource">
		///		Type of the IEnumerable
		/// </typeparam>
		/// <param name="source">
		///		Enumerable source to create immutable collection.
		/// </param>
		/// <returns></returns>
		public static ImmutableCollection<TSource> ToImmutable<TSource>(this IEnumerable<TSource> source)
		{
			var result = source as ImmutableCollection<TSource>;
			if (result != null) return result;
			var list = source as IList<TSource>;
			if (list == null)
			{
				list = source.ToList();
			}
			return new ImmutableCollection<TSource>(list);
		}
	}
}
