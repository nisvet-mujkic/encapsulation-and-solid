using System;
using System.IO;

namespace Encapsulation
{
    public class MessageStore
    {
        private readonly IFileLocator _fileLocator;
        private readonly IStoreWriter _writer;
        private readonly IStoreReader _reader;

        public MessageStore(IStoreWriter writer, IStoreReader reader, IFileLocator fileLocator)
        {
            _writer = writer ?? throw new ArgumentNullException();
            _reader = reader ?? throw new ArgumentNullException();
            _fileLocator = fileLocator ?? throw new ArgumentNullException();
        }

        public void Save(int id, string message)
        {
            _writer.Save(id, message);
        }

        public Maybe<string> Read(int id)
        {
            return _reader.Read(id);
        }

        public FileInfo GetFileInfo(int id)
        {
            return _fileLocator.GetFileInfo(id);
        }
    }
}