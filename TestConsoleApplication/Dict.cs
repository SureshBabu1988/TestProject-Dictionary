using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class CustomDict<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private readonly int Initial_Size = 16;
        LinkedList<KeyValuePair<K, V>>[] values = null;

        public CustomDict()
        {
            values = new LinkedList<KeyValuePair<K, V>>[Initial_Size];
        }

        public CustomDict(int size)
        {
            Initial_Size = size;
            values = new LinkedList<KeyValuePair<K, V>>[Initial_Size];
        }

        public int Count { get; private set; }
        public int Capacity { get { return values.Length; } }

        public void Add(K key, V value)
        {
            var hash = this.HashKey(key);

            if (this.values[hash] == null)
            { this.values[hash] = new LinkedList<KeyValuePair<K, V>>(); }

            bool KeyAlreadyExists = this.values[hash].Any(p => p.Key.Equals(key));

            if (KeyAlreadyExists)
            { throw new InvalidOperationException("key with same name already exists. !"); }
            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            if (this.Count >= (this.Capacity * 0.8))
            { this.ReSizeAndReAddValues(); }
        }

        public V Find(K key)
        {
            var hash = this.HashKey(key);
            if (this.values[hash] == null)
            { return default(V); }

            return this.values[hash].FirstOrDefault(p => p.Key.Equals(key)).Value;
        }

        public bool ContainsKey(K key)
        {
            var hash = this.HashKey(key);
            if (this.values[hash] == null)
            { return false; }

            return this.values[hash].Any(p => p.Key.Equals(key));
        }

        private int HashKey(K key)
        {
            //Math.abs used to get positive numbs..
            var hashedKey = Math.Abs(key.GetHashCode()) % Capacity;
            return hashedKey;
        }

        private void ReSizeAndReAddValues()
        {
            //cache the values
            var cahedValues = this.values;

            // resize
            this.values = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];

            //read the values
            //this.values = cahedValues;

            foreach (var collection in cahedValues)
            {
                if (collection != null)
                {
                    foreach (var value in collection)
                    { this.Add(value.Key, value.Value); }
                }
            }

        }


        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var collection in this.values)
            {
                if (collection != null)
                {
                    foreach (var value in collection)
                    {
                        yield return value;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
