namespace DynamicFolderEngine
{
    public class Condition
    {
        public const string FolderIdKey = "folderId";
        public const string EmptyValue = "% Empty %";

        public string Key { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        
    }
}