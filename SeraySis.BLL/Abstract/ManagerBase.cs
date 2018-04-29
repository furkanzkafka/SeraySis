using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SeraySis.Core.DataAccess;
using SeraySis.DAL.EntityFramework;

namespace SeraySis.BLL.Abstract
{
    //Manager Base classimiz butun manager classlarimiza uyumlu assadaki metotlari kullanabilecegiz UI Core katmani ile de tum bunlara UIda da erisebilecegiz olusturulmamasi icin abstract yaptik
    public abstract class ManagerBase<T> : IDataAccess<T> where T : class
    {
        //Oncesinde her managerda repoyu olusturuyorduk boylelikle ilgili managerlarimiz ManagerBaseden tureyip Repositorynin olusturulmasina gerek kalmayacak
        private Repository<T> repo = new Repository<T>();

        public int Delete(T obj)
        {
            return repo.Delete(obj);
        }

        public T Find(Expression<Func<T, bool>> express)
        {
            return repo.Find(express);
        }

        public int insert(T obj)
        {
            return repo.insert(obj);
        }

        public List<T> List()
        {
            return repo.List();
        }

        public List<T> List(Expression<Func<T, bool>> express)
        {
            return repo.List(express);
        }

        public IQueryable<T> ListQueryable()
        {
            return repo.ListQueryable();
        }

        public int Save()
        {
            return repo.Save();
        }

        public int Update(T obj)
        {
            return repo.Update(obj);
        }
    }
}
