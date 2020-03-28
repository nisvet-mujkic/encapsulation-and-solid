using System;
using System.IO;

namespace Encapsulation
{
    public class FileStore : IStoreWriter, IStoreReader, IFileLocator
    {
        private readonly DirectoryInfo _workingDirectory;

        public FileStore(DirectoryInfo workingDirectory)
        {
            _workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

            if (!workingDirectory.Exists)
            {
                throw new ArgumentException("Working directory does not exist", nameof(workingDirectory));
            }
        }

        public void Save(int id, string message)
        {
            var path = GetFileInfo(id).FullName;
            File.WriteAllText(path, message);
        }

        public Maybe<string> Read(int id)
        {
            var file = GetFileInfo(id);
            if (!file.Exists)
            {
                return Maybe<string>.CreateEmpty();
            }

            var path = file.FullName;
            return Maybe<string>.Create(File.ReadAllText(path));
        }

        public FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(_workingDirectory.FullName, $"{id}.txt"));
        }
    }
}