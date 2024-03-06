using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ASPNETMvcCV.Models.Entity;
using Microsoft.Ajax.Utilities;

namespace ASPNETMvcCV.Repositories
{
    public class GenericRepository<T> where T : class , new()
    {
       DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList(); // T den geleni bana list olarak geri döndüreceksin. 
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);  // parametreden gelen değeri ekle.
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p); // parametreden gelen değeri kaldır.
            db.SaveChanges() ;
        }
        
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);// id ye göre bulma işlemi gerçekleştireceksin.
        }

        public void TUpdate(T p)  // t den gelen bir p parametresi
        {
            db.SaveChanges();
        }
        // silinecek olan değeri bulabilmemiz için bir metota ihtiyacımız var.
        public T Find(Expression<Func<T ,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
            // where den gelecek olan şarta göre(id ye göre, ad a göre vb.) bana ilk değeri döndür.
        }
    }
}