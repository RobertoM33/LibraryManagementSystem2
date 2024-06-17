namespace LibraryManagementSystem.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string BookISBN { get; set; }
        public int MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
