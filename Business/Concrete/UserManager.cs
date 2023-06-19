using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public void Add(User user)
        {
            _userdal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userdal.Get(x=>x.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userdal.GetClaims(user);
        }
    }
}
