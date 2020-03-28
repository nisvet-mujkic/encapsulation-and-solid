using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

namespace Encapsulation
{
    public class MessageStore
    {
        private readonly StoreCache _cache;
        private readonly StoreLogger _logger;
        private readonly IStore _store;

        public MessageStore(DirectoryInfo workingDirectory)
        {
            _cache = new StoreCache();
            _logger = new StoreLogger();
            _store = new FileStore(workingDirectory);
        }

        public DirectoryInfo WorkingDirectory { get; }

        public void Save(int id, string message)
        {
            Logger.Saving(id);
            Store.WriteAllText(id, message);
            Cache.AddOrUpdate(id, message);
            Logger.Saved(id);
        }

        public Maybe<string> Read(int id)
        {
            Logger.Reading(id);

            var message = Cache.GetOrAdd(id, _ => Store.ReadAllText(id));

            if (message.Any())
            {
                Logger.Returning(id);
            }
            else
            {
                Logger.DidNotFind(id);
            }

            return message;
        }

        public FileInfo GetFileInfo(int id)
        {
            return FileLocator.GetFileInfo(id);
        }

        protected virtual IStore Store
        {
            get { return _store; }
        }

        protected virtual StoreCache Cache
        {
            get { return _cache; }
        }

        protected virtual StoreLogger Logger
        {
            get { return _logger; }
        }

        protected virtual IFileLocator FileLocator
        {
            get { return _logger; }
        }
    }
}