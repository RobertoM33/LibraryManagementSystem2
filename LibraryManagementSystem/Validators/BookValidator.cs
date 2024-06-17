using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Validators
{
    public class BookValidator
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1000, 9999)]
        public int PublicationYear { get; set; }

        public string Category { get; set; }
        public string Status { get; set; }

    }
}
