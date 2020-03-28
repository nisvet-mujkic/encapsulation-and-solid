using System;
using System.Collections.Concurrent;

namespace Encapsulation
{
    public class StoreCache : IStoreCache
    {
        private readonly ConcurrentDictionary<int, Maybe<string>> _cache;

        public StoreCache()
        {
            _cache = new ConcurrentDictionary<int, Maybe<string>>();
        }

        public virtual void AddOrUpdate(int id, string message)
        {
            var msg = Maybe<string>.Create(message);
            _cache.AddOrUpdate(id, msg, (i, s) => msg);
        }

        public virtual Maybe<string> GetOrAdd(int id, Func<int, Maybe<string>> messageFactory)
        {
            return _cache.GetOrAdd(id, messageFactory);
        }
    }
}