using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectSample.Clases
{
    public class UserService : NinjectSample.Clases.IUserService
    { 
        public  List<UserData> UserDataRepository = null;

        public UserService()
        {
            UserDataRepository = new List<UserData>();
            UserData user = new UserData();
            user.UserName ="luis";
            user.Id = 100;
            user.Area = "Salud";
            user.Cuenta = "Privado";
            user.FirstName = "Luis";
            user.Roles = new  String[]{"Admin","User","Mannager"};
            user.Password = "1";

            UserDataRepository.Add(user);
            user = new UserData();
            user.UserName = "noe";
            user.Id = 101;
            user.Area = "Gestion";
            user.Cuenta = "Privado";
            user.FirstName = "Noe";
            user.Roles = new String[] {  "User"  };
            user.Password = "1";
            UserDataRepository.Add(user);

            user = new UserData();
            user.Id = 102;
            user.UserName = "gerard";
            user.Area = "Salud";
            user.Cuenta = "Privado";
            user.FirstName = "Gerad";
            user.Roles = new String[] {  "User" };
            user.Password = "1";
            UserDataRepository.Add(user);

        }

        public  UserData Get(string name)
        {
            var user = UserDataRepository.Where(p => p.UserName.Equals(name.Trim()));
            if (user != null)
                return user.FirstOrDefault();

            return null;
        }



        internal  bool ValidateUser(string p1, string password)
        {
            return true;
        }

        internal  void Authenticate(UserData wUserData, string OuthRuleName)
        {
            
        } 
    }
}
