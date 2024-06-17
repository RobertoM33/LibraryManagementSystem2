using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
   
        public interface ILoanService
        {
            Task AddLoanAsync(Loan loan);
            Task UpdateLoanAsync(Loan loan);
            Task DeleteLoanAsync(int id);
            Task<Loan> GetLoanByIdAsync(int id);
            Task<IEnumerable<Loan>> GetAllLoansAsync();
            Task RegisterReturnAsync(int id, DateTime returnDate);
        }
    }

