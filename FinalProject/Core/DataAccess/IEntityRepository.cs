using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//Core katmanı diğer katmanları referans almaz çünkü her projede kullanılabilir olmalıdır.
namespace Core.DataAccess
{
    //T değişkenini sınırlandırmamız gerekiyor çünkü int,string vs veya herhangi bir class,interface vs parametre olarak
    //verilmesini istemiyoruz
    //where T : class,IEntity ifadesi "T" IEntitiy veya IEntitiyi impelemente eden bir class olabilir anlamına geliyor
    //IEntitynin parametre olarak verilememesini sadece oluşturduğumuz IEntity interfacine bağlı  classların parametre olarak
    //verilebilmesini istiyoruz. Bunun için new() ifadesi koyduk, verilecek parametre newlenebilir olmalı anlamına geliyor
    //Bu kısıtlama işlemine generic constraint yani generic kısıtlama deniyor
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
