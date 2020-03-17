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
    }
}
