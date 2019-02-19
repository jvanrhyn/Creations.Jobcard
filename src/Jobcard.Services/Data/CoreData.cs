using System;
using System.Text;

namespace Jobcard.Services.Data
{
    public abstract class CoreData
    {

        public CoreData(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException();

            this.CollectionName = collectionName;
        }
        internal string DatabaseName { get; private set;} = @"Creations";

        internal string CollectionName { get; set; }

        public void SetDatabase(string databaseName)
        {
            this.DatabaseName = databaseName;
        }
    }
}
