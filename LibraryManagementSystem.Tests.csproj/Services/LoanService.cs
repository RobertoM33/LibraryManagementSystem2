using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task AddLoanAsync(Loan loan)
        {
            await _loanRepository.AddLoanAsync(loan);
        }

        public async Task UpdateLoanAsync(Loan loan)
        {
            await _loanRepository.UpdateLoanAsync(loan);
        }

        public async Task DeleteLoanAsync(int id)
        {
            await _loanRepository.DeleteLoanAsync(id);
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _loanRepository.GetLoanByIdAsync(id);
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _loanRepository.GetAllLoansAsync();
        }

        public async Task RegisterReturnAsync(int id, DateTime returnDate)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(id);
            if (loan == null)
            {
                throw new Exception("Loan not found");
            }
            loan.ReturnDate = returnDate;
            await _loanRepository.UpdateLoanAsync(loan);
        }
    }
}


