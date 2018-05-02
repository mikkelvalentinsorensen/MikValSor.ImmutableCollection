using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MikValSor.Immutable
{
	/// <summary>
	///		Provides class for a generic immutable collection.
	/// </summary>
	/// <typeparam name="T">
	///		The type of elements in the collection.
	///	</typeparam>
	public sealed class ImmutableCollection<T> : ReadOnlyCollection<T>
    {

		/// <summary>
		///     Initializes a new instance of the MikValSor.Immutable.ImmutablCollection`1 class that is a immutable wrapper around the specified list.
		/// </summary>
		/// <param name="list">
		///     The list to wrap.
		///</param>
		public ImmutableCollection(IList<T> list) : base(Enumerable.ToList(list))
		{
		}
	}
}
