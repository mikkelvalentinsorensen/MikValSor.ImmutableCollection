using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MikValSor.Immutable
{
	/// <summary>
	///		Provides class for a generic immutable collection.
	/// </summary>
	/// <typeparam name="T">
	///		The type of elements in the collection.
	///	</typeparam>
	[Serializable]
	public sealed class ImmutableCollection<T> : ReadOnlyCollection<T>, ISerializable
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
		
		#region Serializable

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("L", this.ToArray());
		}

		private ImmutableCollection(SerializationInfo info, StreamingContext context) : base(((T[])info.GetValue("L", typeof(T[]))).ToList())
		{
		}

		#endregion Serializable
	}
}
