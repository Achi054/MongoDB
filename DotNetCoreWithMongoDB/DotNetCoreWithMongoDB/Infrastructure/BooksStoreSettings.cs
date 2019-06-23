namespace DotNetCoreWithMongoDB.Infrastructure
{
    public class BooksStoreSettings : IBooksStoreSettings
    {
        public string CollectionName { get; set; }
        public string ConnectingStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
