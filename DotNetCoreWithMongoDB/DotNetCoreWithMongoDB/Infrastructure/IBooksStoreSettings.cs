namespace DotNetCoreWithMongoDB.Infrastructure
{
    public interface IBooksStoreSettings
    {
        string CollectionName { get; set; }
        string ConnectingStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
