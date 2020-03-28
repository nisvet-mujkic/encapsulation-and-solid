using Serilog;
using System;
using System.IO;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration().CreateLogger();
            var fileStore = new FileStore(new DirectoryInfo(Environment.CurrentDirectory));
            var cache = new StoreCache(fileStore, fileStore);
            var log = new StoreLogger(logger, cache, cache);
            var messageStore = new MessageStore(log, log, fileStore);
        }
    }
}
