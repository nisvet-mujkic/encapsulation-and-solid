using System.Collections;
using System.Collections.Generic;

namespace Encapsulation
{
    public class Maybe<T> : IEnumerable<T>
    {
        private readonly T[] _data;

        private Maybe(T[] data)
        {
            _data = data;
        }

        public static Maybe<T> Create(T value)
        {
            return new Maybe<T>(new[] { value });
        }

        public static Maybe<T> CreateEmpty()
        {
            return new Maybe<T>(new T[0]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this._data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}