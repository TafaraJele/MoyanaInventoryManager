using System;

namespace InventoryManager.Core
{
    public interface IAppSettings
    {
        string CommandServerName { get; set; }
        string CommandDatabaseName { get; set; }
        string QueryServerName { get; set; }
        string QueryDatabaseName { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string CommandServerName { get; set; }
        public string CommandDatabaseName { get; set; }
        public string QueryServerName { get; set; }
        public string QueryDatabaseName { get; set; }
    }
}
