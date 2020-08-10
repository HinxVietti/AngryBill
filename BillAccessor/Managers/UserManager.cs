using System;
using System.Collections.Generic;
using BillAccess;

public class UserManager
{
    internal static CreateUserResponse CreateUser(UserCreateInfo info)
    {
        return new CreateUserResponse()
        {
            code = -1,
            message = "not allow create user. Just press login btn"
        };
    }
}
