using System.Collections.Concurrent;
using System.Linq;

namespace Encapsulation
{
    public class StoreCache : IStoreWriter, IStoreReader
    {
        private readonly ConcurrentDictionary<int, Maybe<string>> _cache;
        private readonly IStoreWriter _writer;
        private readonly IStoreReader _reader;

        public StoreCache(IStoreWriter writer, IStoreReader reader)
        {
            _cache = new ConcurrentDictionary<int, Maybe<string>>();
            _writer = writer;
            _reader = reader;
        }

        public void Save(int id, string message)
        {
            _writer.Save(id, message);
            var msg = Maybe<string>.Create(message);
            _cache.AddOrUpdate(id, msg, (i, s) => msg);
        }

        public Maybe<string> Read(int id)
        {
            if (_cache.TryGetValue(id, out Maybe<string> returnValue))
                return returnValue;

            returnValue = _reader.Read(id);

            if (returnValue.Any())
            {
                _cache.AddOrUpdate(id, returnValue, (i, s) => returnValue);
            }

            return returnValue;
        }
    }
}