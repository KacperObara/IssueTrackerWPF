using System;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Login  { get; set; }
        public string Email { get; set; }

        public PersonModel()
        {

        }

        public PersonModel(string login)
        {
            this.Login = login;
        }

        public PersonModel(string login, string emailAdress)
        {
            this.Login = login;
            this.Email = emailAdress;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                PersonModel person = (PersonModel)obj;
                return (Id == person.Id);
            }
        }
    }
}
