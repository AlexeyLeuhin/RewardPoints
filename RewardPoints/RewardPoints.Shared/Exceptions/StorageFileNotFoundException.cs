namespace RewardPoints.Shared.Exceptions;

public class StorageFileNotFoundException : Exception
{
    public StorageFileNotFoundException(Type type)
        : base("Not found storage file for type " +  type)
    {

    }
}

