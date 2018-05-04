using System;
using System.Collections;
using System.Collections.Generic;
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
	public sealed class ImmutableCollection<T> : IList<T>, IList, IReadOnlyList<T>, ISerializable
	{
		private readonly T[] m_array;
		private IList<T> m_listT => m_array;
		private IList m_list => m_array;
		private ICollection m_collcetion => m_array;
		private IEnumerable m_enumerable => m_array;

		/// <summary>
		///     Initializes a new instance of the MikValSor.Immutable.ImmutablCollection`1 class that is a immutable wrapper around the specified list.
		/// </summary>
		/// <param name="list">
		///     The list to wrap.
		///</param>
		public ImmutableCollection(IList<T> list) : base()
		{
			m_array = Enumerable.ToArray(list);
		}

		public int Count => m_listT.Count;

		public T this[int index] => m_listT[index]; 

		public bool Contains(T value) => m_listT.Contains(value);
		public void CopyTo(T[] array, int index) => m_listT.CopyTo(array, index);

		public IEnumerator<T> GetEnumerator() => m_listT.GetEnumerator();
		public int IndexOf(T value) =>  m_listT.IndexOf(value);

		bool ICollection<T>.IsReadOnly => true;

		T IList<T>.this[int index]
		{
			get => m_listT[index];
			set => throw new NotSupportedException();
		}

		void ICollection<T>.Add(T value) => throw new NotSupportedException();

		void ICollection<T>.Clear() => throw new NotSupportedException();

		void IList<T>.Insert(int index, T value) => throw new NotSupportedException();

		bool ICollection<T>.Remove(T value) => throw new NotSupportedException();

		void IList<T>.RemoveAt(int index) => throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => m_enumerable.GetEnumerator();

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		void ICollection.CopyTo(Array array, int index) => m_collcetion.CopyTo(array, index);

		bool IList.IsFixedSize => true;

		bool IList.IsReadOnly => true;

		object IList.this[int index]
		{
			get => m_list[index];
			set => throw new NotSupportedException();
		}

		int IList.Add(object value) => throw new NotSupportedException();

		void IList.Clear() => throw new NotSupportedException();

		bool IList.Contains(object value) => m_list.Contains(value);

		int IList.IndexOf(object value) => m_list.IndexOf(value);

		void IList.Insert(int index, object value) => throw new NotSupportedException();

		void IList.Remove(object value) => throw new NotSupportedException();

		void IList.RemoveAt(int index) => throw new NotSupportedException();

		#region Serializable

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("a", m_array);
		}

		private ImmutableCollection(SerializationInfo info, StreamingContext context)
		{
			m_array = (T[]) info.GetValue("a", typeof(T[]));
		}

		#endregion Serializable
	}
}
