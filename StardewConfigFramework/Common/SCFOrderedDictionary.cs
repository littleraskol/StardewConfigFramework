﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace StardewConfigFramework {
	internal class SCFOrderedDictionary<T>: ISCFOrderedDictionary<T> where T : SCFObject {

		protected readonly OrderedDictionary dictionary = new OrderedDictionary();

		public T this[int index] {
			get => (T) dictionary[index];
			set {
				RemoveAt(index);
				Insert(index, value);
			}
		}
		public T this[string identifier] {
			get => (T) dictionary[identifier];
			set {
				if (identifier != value.Identifier)
					throw new Exception("New value does not contain a matching identifier");

				dictionary[identifier] = value;
			}
		}

		public int Count => dictionary.Count;

		public bool IsReadOnly => false;

		public ICollection<string> Keys => dictionary.Keys as ICollection<string>;

		public ICollection<T> Values => dictionary.Values as ICollection<T>;

		public void Add(T item) {
			dictionary.Add(item.Identifier, item);
		}

		public void Add(string identifier, T item) {
			dictionary.Add(identifier, item);
		}

		public void Add(KeyValuePair<string, T> item) {
			dictionary.Add(item.Value.Identifier, item.Value);
		}

		public void Clear() {
			dictionary.Clear();
		}

		public bool Contains(string identifier) {
			return dictionary.Contains(identifier);
		}

		public bool Contains(T item) {
			return dictionary.Contains(item.Identifier);
		}

		public bool Contains(KeyValuePair<string, T> item) {
			return dictionary.Contains(item.Value.Identifier);
		}

		public bool ContainsKey(string identifier) {
			return dictionary.Contains(identifier);
		}

		public void CopyTo(T[] array, int arrayIndex) {
			int j = 0;
			for (int i = arrayIndex; i < dictionary.Count + arrayIndex; i++) {
				array[i] = (T) dictionary[j];
				j++;
			}
		}

		public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex) {
			dictionary.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator() {
			return dictionary.GetEnumerator() as IEnumerator<T>;
		}

		/// <summary>
		/// Index of the identifier
		/// </summary>
		/// <returns>The index of of the <paramref name="identifier"/>. Returns -1 if identifier does not exist.</returns>
		/// <param name="identifier">Identifier.</param>
		public int IndexOf(string identifier) {
			for (int i = 0; i < dictionary.Count; i++) {
				if (dictionary[i] == dictionary[identifier])
					return i;
			}
			return -1;
		}

		public int IndexOf(T item) {
			return IndexOf(item.Identifier);
		}

		public void Insert(int index, T item) {
			dictionary.Insert(index, item.Identifier, item);
		}

		public bool Remove(T item) {
			return Remove(item.Identifier);
		}

		public bool Remove(string identifier) {
			if (!Contains(identifier))
				return false;

			dictionary.Remove(identifier);
			return true;
		}

		public bool Remove(KeyValuePair<string, T> item) {
			return Remove(item.Value.Identifier);
		}

		public void RemoveAt(int index) {
			dictionary.RemoveAt(index);
		}

		public bool TryGetValue(string identifier, out T value) {
			if (!Contains(identifier)) {
				value = default(T);
				return false;
			}

			value = this[identifier];
			return true;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return dictionary.GetEnumerator();
		}

		IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator() {
			return dictionary.GetEnumerator() as IEnumerator<KeyValuePair<string, T>>;
		}
	}
}