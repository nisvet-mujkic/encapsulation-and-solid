using Serilog;
using System.Linq;

namespace Encapsulation
{
    public class StoreLogger : IStoreWriter, IStoreReader
    {
        private readonly ILogger _logger;
        private readonly IStoreWriter _writer;
        private readonly IStoreReader _reader;

        public StoreLogger(ILogger logger, IStoreWriter writer, IStoreReader reader)
        {
            _logger = logger;
            _writer = writer;
            _reader = reader;
        }

        public void Save(int id, string message)
        {
            _logger.Information($"Saving message {id}.");
            _writer.Save(id, message);
            _logger.Information($"Saved message {id}.");
        }

        public Maybe<string> Read(int id)
        {
            _logger.Debug($"Reading message {id}");
            var returnValue = _reader.Read(id);
            if (returnValue.Any())
            {
                _logger.Debug($"Returning message {id}");
            }
            else
            {
                _logger.Debug($"No message {id} found");
            }

            return returnValue;
        }
    }
}