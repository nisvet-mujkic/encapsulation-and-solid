using System.IO;

namespace Encapsulation
{
    public interface IFileLocator
    {
        FileInfo GetFileInfo(int id);
    }
}