using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data.Models;

namespace Service
{
    public interface IUserService
    {
        xUser GetById(Int64 id);
        xUser GetByFilter(Expression<Func<xUser, bool>> filter);
        void InsertUser(Data.Models.xUser users);
        void UpdateUser(Data.Models.xUser users);
        void DeleteUser(Data.Models.xUser users);
    }
}
