using System.IO;

namespace Encapsulation
{
    public class SqlStore : IStore
    {
        public Maybe<string> ReadAllText(int id)
        {
            throw new System.NotImplementedException();
        }

        public void WriteAllText(int id, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}