using Jobcard.Models;
using LiteDB;
using System.Collections.Generic;

namespace Jobcard.Services.Data
{
    public class DefaultsManager : CoreData
    {
        public DefaultsManager() : base(@"layerkinddefaults")
        {
        }

        public IEnumerable<LayerKindDefault> GetAll()
        {
            using (var db = new LiteDatabase(DatabaseName))
            {
                var collection = db.GetCollection<LayerKindDefault>(CollectionName);

                return collection.FindAll();
            }
        }

        public LayerKindDefault Add(LayerKindDefault layerKindDefault)
        {
            using (var db = new LiteDatabase(DatabaseName))
            {
                var collection = db.GetCollection<LayerKindDefault>(CollectionName);

                collection.Insert(layerKindDefault);
                return layerKindDefault;
            }
        }

        public override void Clear()
        {
            using (var db = new LiteDatabase(DatabaseName))
            {
                db.DropCollection(CollectionName);
            }
        }
    }
}
