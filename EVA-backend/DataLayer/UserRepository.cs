using EVA_backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EVA_backend.DataLayer
{
    public class UserRepository
    {
        //Creating the datacontext
        private DbContext _db = Eva18Singleton.Db;

        public int InsertUser(User u)
        {
            _db.Set<User>().Add(u);
            return _db.SaveChanges();
        }

        public void DeleteUser(User u)
        {
            _db.Set<User>().Remove(u);
        }

        public User GetUserByEmail(string email)
        {
            return _db.Set<User>().Where(x => x.Email.Equals(email)).FirstOrDefault();
        }
    }
}