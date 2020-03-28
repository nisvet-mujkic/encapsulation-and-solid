namespace Encapsulation
{
    public interface IStoreReader
    {
        Maybe<string> Read(int id);
    }
}