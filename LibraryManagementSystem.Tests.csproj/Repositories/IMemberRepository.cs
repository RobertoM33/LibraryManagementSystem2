using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IMemberRepository
    {
        Task AddMemberAsync(Member member);
        Task UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int id);
        Task<Member> GetMemberByIdAsync(int id);
        Task<IEnumerable<Member>> GetAllMembersAsync();
    }
}
