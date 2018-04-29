using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeraySis.DAL;

namespace SeraySis.DAL.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lockSync = new object();


        protected RepositoryBase()
        {
            CreateContext();
            //Sadece miras alan, nesneyi olusturabilir(new)

        }

        //Singleton Pattern
        //Tekrar tekrar nesneyi olusturmayacak eger var ise var olan uzerinden calisacak
        //Hep ayni DatabaseContexti kullanacak
        private static void CreateContext()
        {
            if (context == null)
            {
                //Multithreadingde farkli threadler aynanda dbyi olusturmamasi icin biri bitirmesini bekleyecek
                lock (_lockSync)
                {
                    if (context == null) //Garantiye almak icin
                        context = new DatabaseContext();
                }
            }
        }
    }
}
