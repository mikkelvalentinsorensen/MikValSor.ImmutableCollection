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
		///<exception cref="ArgumentNullException">
		///		List is null.
		/// </exception>
		///<exception cref="ArgumentException">
		///		List contains mutable element.
		/// </exception>
		public ImmutableCollection(IList<T> list) : base()
		{
			if (list == null) throw new ArgumentNullException(nameof(list));

			m_array = Enumerable.ToArray(list);

			var validator = new ImmutableValidator();
			if (!validator.IsImmutable(typeof(T)))
			{
				for (var i = 0; i < m_array.Length; i++)
				{
					try
					{
						validator.EnsureImmutable(m_array[i]);
					}
					catch (NotImmutableException e)
					{
						throw new ArgumentException($"List element at index {i}, was not immutable.", nameof(list), e);
					}
				}
			}
		}

		/// <summary>
		///		Gets the number of elements contained in the MikValSor.Immutable.ImmutableCollection`1.
		/// </summary>
		/// <returns>
		///		The number of elements contained in the MikValSor.Immutable.ImmutableCollection`1.
		/// </returns>
		public int Count => m_listT.Count;

		/// <summary>
		///		Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">
		///		The zero-based index of the element to get or set.
		/// </param>
		/// <returns>
		///		The element at the specified index.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///		index is less than 0. -or- index is equal to or greater than MikValSor.Immutable.ImmutableCollection`1.Count.
		/// </exception>
		public T this[int index] => m_listT[index];

		/// <summary>
		///		Determines whether an element is in the MikValSor.Immutable.ImmutableCollection`1.
		/// </summary>
		/// <param name="value">
		///		The object to locate in the MikValSor.Immutable.ImmutableCollection`1. The value can be null for reference types.
		/// </param>
		/// <returns>
		///		true if item is found in the MikValSor.Immutable.ImmutableCollection`1; otherwise, false.
		/// </returns>
		public bool Contains(T value) => m_listT.Contains(value);

		/// <summary>
		///		Copies the entire MikValSor.Immutable.ImmutableCollection`1 to a compatible one-dimensional array, starting at the specified index of the target array.
		/// </summary>
		/// <param name="array">
		///		The one-dimensional System.Array that is the destination of the elements copied from MikValSor.Immutable.ImmutableCollection`1. The System.Array must have zero-based indexing.
		/// </param>
		/// <param name="index">
		///		The zero-based index in array at which copying begins.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		array is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///		arrayIndex is less than 0.
		/// </exception>
		/// <exception cref="ArgumentException">
		///		The number of elements in the source MikValSor.Immutable.ImmutableCollection`1 is greater than the available space from arrayIndex to the end of the destination array.
		/// </exception>
		public void CopyTo(T[] array, int index) => m_listT.CopyTo(array, index);

		/// <summary>
		///		Returns an enumerator that iterates through the MikValSor.Immutable.ImmutableCollection`1.
		/// </summary>
		/// <returns>
		///		A MikValSor.Immutable.ImmutableCollection`1.Enumerator for the MikValSor.Immutable.ImmutableCollection`1.
		/// </returns>
		public IEnumerator<T> GetEnumerator() => m_listT.GetEnumerator();

		/// <summary>
		///		Searches for the specified object and returns the zero-based index of the first occurrence within the entire MikValSor.Immutable.ImmutableCollection`1.
		/// </summary>
		/// <param name="value">
		///		The object to locate in the MikValSor.Immutable.ImmutableCollection`1. The value can be null for reference types.
		/// </param>
		/// <returns>
		///		The zero-based index of the first occurrence of item within the entire MikValSor.Immutable.ImmutableCollection`1, if found; otherwise, –1.
		/// </returns>
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
