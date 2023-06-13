using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //IDataResult hem mesaj hem data döndürmek istediğimiz metotlar için kullanılır
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
