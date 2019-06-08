﻿using Data.Infrastructủe;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        bool GetUser(string userName, string Pass);
        User GetUserById(int id);
    }
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly IDbSet<User> dbSet;
        public UserRepository(IDbFactory dbFactory): base(dbFactory)
        {
            dbSet = DbContext.Set<User>();
        }

        public bool GetUser(string userName, string Pass)
        {
            return dbSet.Count(x => x.UserName == userName && x.PassWord == Pass) > 0;
        }

        public User GetUserById(int id)
        {
            return dbSet.Find(id);
        }
    }
}
