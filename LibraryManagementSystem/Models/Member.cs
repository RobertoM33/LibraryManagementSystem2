namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
