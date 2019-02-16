using Jobcard.Models;
using LiteDB;
using System;
using System.Collections.Generic;
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
        internal string DatabaseName { get; } = @"Creations";

        internal string CollectionName { get; set; }
    }

    public class DefaultsManager : CoreData
    {
        public DefaultsManager() : base(@"layerkinddefaults")
        {
        }

        public IEnumerable<LayerKindDefault> GetAll()
        {
            using var db = new LiteDatabase(this.DatabaseName);
            var collection = db.GetCollection<LayerKindDefault>(this.CollectionName);

            return collection.FindAll();
        }

        public LayerKindDefault Add(LayerKindDefault layerKindDefault)
        {
            using var db = new LiteDatabase(this.DatabaseName);
            var collection = db.GetCollection<LayerKindDefault>(this.CollectionName);

            collection.Insert(layerKindDefault);
            return layerKindDefault;
        }
    }
}
