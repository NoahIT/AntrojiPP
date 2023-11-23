using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.MVVM.Model
{
    internal class UserProperties
    {
        private string _username;
        private string _password;
        private string _userLevel;

        public UserProperties(string username, string password, string userLevel) // proped ctor
        {
            _username = username;
            _password = password;
            _userLevel = userLevel;
        }

        public UserProperties() // default ctor
        {
        }

        public string getUsername()
        {
            return this._username;
        }

        public string getUserlevel()
        {
            return this._userLevel;
        }

        public string GetPassword()
        {
            return this._password;
        }
    }
}
