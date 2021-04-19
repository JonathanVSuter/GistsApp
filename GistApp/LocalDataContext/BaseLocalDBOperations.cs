using GistApp.ExtractModels;
using GistApp.Helpers;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GistApp.LocalDataContext
{
    public abstract class BaseLocalDBOperations<T> : ILiteDBBaseOperations<T> where T : IBaseExtractModel
    {
        public bool Add(T item)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Constants.DatabasePath))
                {
                    ILiteCollection<T> collection = db.GetCollection<T>(typeof(T).Name);
                    if (collection.FindOne(x => x.Id == item.Id) == null)
                    {
                        collection.Insert(item);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Delete(T item)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            List<T> ts;
            try
            {
                using (var db = new LiteDatabase(Constants.DatabasePath))
                {
                    ILiteCollection<T> collection = db.GetCollection<T>(typeof(T).Name);
                    ts = new List<T>(collection.FindAll());
                }
                return ts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
        public List<T> GetBy(Expression<Func<T, bool>> func)
        {
            List<T> ts;
            try
            {                
                using (var db = new LiteDatabase(Constants.DatabasePath))
                {
                    var collection = db.GetCollection<T>(typeof(T).Name);                   
                    ts = new List<T>(collection.Find(func));
                }
                return ts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
        public bool Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
