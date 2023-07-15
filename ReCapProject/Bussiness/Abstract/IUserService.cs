using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IUserService
    {
        public IDataResult<List<User>> GetAll();
        public IDataResult<User> GetById(int id);
        public IResult Add(User user);
        public IResult Update(User user);
        public IResult Delete(User user);

    }
}
