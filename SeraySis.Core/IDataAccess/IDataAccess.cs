using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeraySis.Core.DataAccess
{
    //UI dan tum bu metodlara erisebilmesi icin butun katmanlara ulasabilen core katmanini actik ve eski IRepositorymizi burada tanimladik

    public interface IDataAccess<T>
    {
        List<T> List();

        IQueryable<T> ListQueryable();

        List<T> List(Expression<Func<T, bool>> express);

        int insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        int Save();

        T Find(Expression<Func<T, bool>> express);

    }
}
