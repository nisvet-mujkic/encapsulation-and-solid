using Serilog;

namespace Encapsulation
{
    public class StoreLogger
    {
        public virtual void Saving(int id)
        {
            Log.Information($"Saving message {id}.");
        }

        public virtual void Saved(int id)
        {
            Log.Information($"Saved message {id}.");
        }

        public virtual void Reading(int id)
        {
            Log.Debug($"Reading message {id}.");
        }

        public virtual void DidNotFind(int id)
        {
            Log.Debug($"No message {id} found.");
        }

        public virtual void Returning(int id)
        {
            Log.Debug($"Returning message {id}.");
        }
    }
}