using System;
using System.Linq;
using System.IO;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageStore = new MessageStore(new DirectoryInfo(@"C:\Users\Nisvet\Desktop\docs"));

            messageStore.Save(22, "ja sa nisvet");
        }
    }
}
