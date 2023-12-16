using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Manger
{
    public class MangePassword
    {
        public string encrypt_password(string password, int id)
        {
            int key = id % 1000000;
            char[] pass = password.ToCharArray();

            for (int i = 0; i < password.Length; ++i)
            {
                pass[i] = (char)(pass[i] + (key + i));
            }

            return new string(pass);
        }

        public string decrypt_password(string password, int id)
        {
            int key = id % 1000000;
            char[] pass = password.ToCharArray();

            for (int i = 0; i < password.Length; ++i)
            {
                pass[i] = (char)(pass[i] - (key + i));
            }

            return new string(pass);
        }
    }
}
