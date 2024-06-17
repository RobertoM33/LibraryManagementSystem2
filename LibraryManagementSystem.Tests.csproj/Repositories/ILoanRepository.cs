using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface ILoanRepository
    {
        Task AddLoanAsync(Loan loan);
        Task UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(int id);
        Task<Loan> GetLoanByIdAsync(int id);
        Task<IEnumerable<Loan>> GetAllLoansAsync();
    }
}
