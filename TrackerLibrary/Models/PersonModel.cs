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

        public PersonModel(string login, string emailAdress)
        {
            this.Login = login;
            this.Email = emailAdress;
        }
    }
}
