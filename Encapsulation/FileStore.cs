using System;
using System.IO;

namespace Encapsulation
{
    public class FileStore : IStore
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

        public virtual void WriteAllText(int id, string message)
        {
            var path = GetFileInfo(id).FullName;
            File.WriteAllText(path, message);
        }

        public virtual Maybe<string> ReadAllText(int id)
        {
            var file = GetFileInfo(id);
            if (!file.Exists)
            {
                return Maybe<string>.CreateEmpty();
            }

            var path = file.FullName;
            return Maybe<string>.Create(File.ReadAllText(path));
        }

        public virtual FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(_workingDirectory.FullName, $"{id}.txt"));
        }
    }
}