using DataAccessLayer.AccessModel;
using DataAccessLayer.FactoryShoppingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserAccount
{
    public interface ILoginRepository
    {
        int checkUser(Login user); //post
        int getUserId(Login val);
        //int getUserIdviaGoogle(User val);
        int googleLogin(Login guestUser);
    }
}
