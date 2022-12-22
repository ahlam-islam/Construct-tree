namespace TreeAPI.Model
{
    public class TreeDatabaseSettings : ITreeDatabaseSettings
    {
       
        public string TreeCollectionName { get; set; } = string.Empty;
        public string ConntionString { get; set; } = string.Empty;
        public string TreeDatabaseName { get; set; } = string.Empty;
    }
}
