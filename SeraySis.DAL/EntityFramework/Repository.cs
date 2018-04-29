using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SeraySis.Common;
using SeraySis.Core.DataAccess;
using SeraySis.Entities;

namespace SeraySis.DAL.EntityFramework
{
    public class Repository<T> : RepositoryBase, IDataAccess<T> where T : class //instance alinabilir bir nesne olmak zorunda misal int donerse problem olur
    {
        //private DatabaseContext db; //RepositoryBase'den kalitim alarak dbyi buradan kaldirdik ve repository metodundan kaldirdik
        private DbSet<T> _objectSet; //ObjectSet de DbSet den türüyor

        public Repository()
        {
            _objectSet = context.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T, bool>> express)
        {
            //IQueryAble
            return _objectSet.Where(express).ToList();
        }

        public int insert(T obj)
        {
            _objectSet.Add(obj);

            //her insert isleminde bu satirlari guncellemek istedigimiz icin
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                //tek tek DateTime now yapsaydik milisaniye de olsa fark olacakti
                DateTime now = DateTime.Now;

                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = "system"; // Burayi duzeltmemiz lazim
            }

            return Save();
        }

        public int Update(T obj)
        {

            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                //tek tek DateTime now yapsaydik milisaniye de olsa fark olacakti

                o.ModifiedOn = DateTime.Now;
                o.ModifiedUsername = "system"; // Burayi duzeltmemiz lazim
            }
            return Save();
        }

        public int Delete(T obj)
        {

            //silmek istemezsek insert updatedeki gibi obj islemlerine  isRemoved gibi bir sutun ekleriz

            _objectSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> express)
        {
            return _objectSet.FirstOrDefault(express);
        }


    }
}
