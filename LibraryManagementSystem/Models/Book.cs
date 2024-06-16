namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public List<Author> Authors { get; set; }
    }
}
