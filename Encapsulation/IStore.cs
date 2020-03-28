using System.IO;

namespace Encapsulation
{
    public interface IStore
    {
        Maybe<string> ReadAllText(int id);

        void WriteAllText(int id, string message);
    }
}