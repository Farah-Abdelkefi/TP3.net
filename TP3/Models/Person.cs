namespace TP3.Models
{
    public class Person
    {
        public Person(int id, string firstName, string lastName, string email, string image, string country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Image = image;
            Country = country;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
