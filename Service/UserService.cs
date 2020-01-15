using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Repo;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<xUser> _repositoryUser;
        public UserService(IRepositoryBase<xUser> repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        public void DeleteUser(xUser users)
        {
            _repositoryUser.Remove(users);
        }

        public xUser GetByFilter(Expression<Func<xUser, bool>> filter)
        {
            return _repositoryUser.GetByFilter(filter);
        }

        public xUser GetById(long id)
        {
            return _repositoryUser.GetById(id);
        }

        public void InsertUser(xUser users)
        {
            _repositoryUser.Insert(users);
        }

        public void UpdateUser(xUser users)
        {
            _repositoryUser.Update(users);
        }
    }
}
