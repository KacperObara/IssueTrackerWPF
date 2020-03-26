using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PasswordModel
    {
        public string Password { get; set; }

        public PasswordModel(string password)
        {
            this.Password = password;
        }

        public void Hash()
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            Password = System.Text.Encoding.ASCII.GetString(data);
            Console.WriteLine(Password);
        }
    }
}
