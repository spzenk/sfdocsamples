using System;
namespace NinjectSample.Clases
{
    interface IUserService
    {
        UserData Get(string name);
    }
}
