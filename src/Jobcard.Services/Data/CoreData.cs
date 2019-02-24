using System;

namespace Jobcard.Services.Data
{
    public abstract class CoreData
    {

        public CoreData(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException();

            CollectionName = collectionName;
        }
        internal string DatabaseName { get; private set;} = @"Creations";

        internal string CollectionName { get; set; }

        public void SetDatabase(string databaseName, bool clear = false)
        {
            DatabaseName = databaseName;
            if (clear)
            {
                Clear();
            }
        }

        public abstract void Clear();
    }
}
