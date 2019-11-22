using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PersonModel
    {
        public string Login  { get; set; }
        public string Password  { get; set; }
        public string EmailAdress  { get; set; }
        public byte[] Picture { get; set; }
    }
}
