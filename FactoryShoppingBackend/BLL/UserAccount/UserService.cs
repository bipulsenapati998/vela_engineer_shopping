using DataAccessLayer.FactoryShoppingModel;
using DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserAccount
{
    public class UserService : IUserRepository
    {
        private readonly FactoryShoppingDataContext _fcontext;
        public UserService(FactoryShoppingDataContext fcontext)
        {
            _fcontext = fcontext;
        }

        public bool deleteuserbyId(int id)
        {
            if (checkvalid(id))
            {
                try
                {
                    var usr = _fcontext.Users.Find(id);
                    _fcontext.Users.Remove(usr);
                    _fcontext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> getAllUsers()
        {
            return _fcontext.Users.ToList();
        }

        public User getUserById(int id)
        {
            return _fcontext.Users.SingleOrDefault(u => u.UserId == id);
            //var checkid = from d in _fcontext.Users where d.UserId == id select d;
            //return checkid;
        }

        public bool saveUser(User newuser)
        {
            var evalid = _fcontext.Users.Where(x => x.Email == newuser.Email).FirstOrDefault();
            if (evalid == null) //if email exist in db or not if not then enter
            {
                try
                {
                    newuser.RoleId = 2;
                    _fcontext.Users.Add(newuser);
                    _fcontext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            else
                return false;

        }

        public bool checkvalid(int id)
        {
            var checkid = _fcontext.Users.Where(i => i.UserId == id).FirstOrDefault();
            if (checkid == null)
                return false;
            else
                return true;
        }

        public bool updateUser(int id, User user)
        {
            if (checkvalid(id))
            {
                try
                {
                    var udata = _fcontext.Users.Where(u => u.UserId == id).FirstOrDefault();
                    udata.FirstName = user.FirstName;
                    udata.LastName = user.LastName;
                    udata.Email = user.Email;
                    udata.Password = user.Password;
                    udata.Profile_Image = user.Profile_Image;
                    udata.Mobile = user.Mobile;
                    udata.Gender = user.Gender;
                    //_fcontext.Entry(user).State = EntityState.Modified;
                    _fcontext.SaveChanges();
                    return true;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
                return false;

        }
    }
}
