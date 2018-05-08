using System;
using System.Collections;
using System.Collections.Generic;


namespace MikValSor.Immutable
{
    public abstract class ImmutableCollectionBase<T> : IList<T>, IList, IReadOnlyList<T>
	{
		private readonly ImmutableCollection<T> m_ImmutableCollection;

		private IList<T> m_listT => m_ImmutableCollection;
		private IList m_list => m_ImmutableCollection;
		private ICollection m_collcetion => m_ImmutableCollection;
		private IEnumerable m_enumerable => m_ImmutableCollection;

		public int Count => m_listT.Count;

		public T this[int index] => m_listT[index];

		public bool Contains(T value) => m_listT.Contains(value);
		public void CopyTo(T[] array, int index) => m_listT.CopyTo(array, index);

		public IEnumerator<T> GetEnumerator() => m_listT.GetEnumerator();
		public int IndexOf(T value) => m_listT.IndexOf(value);

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
	}
}
