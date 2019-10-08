using DataAccessLayer.FactoryShoppingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserAccount
{
    public interface IUserRepository
    {
        bool saveUser(User user); //post

        List<User> getAllUsers(); // Get all users 

        User getUserById(int id); // get by id

        bool deleteuserbyId(int id); //Delete user by id 

        bool updateUser(int id, User user); //put

    }
}
