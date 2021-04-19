using GistApp.ExtractModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GistApp.LocalDataContext
{
    public interface ILiteDBBaseOperations<T> where T  : IBaseExtractModel
    {       
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);
        List<T> GetAll();
        List<T> GetBy(Expression<Func<T,bool>> func);
    }
}
