using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{

        public interface IMemberService
        {
            Task AddMemberAsync(Member member);
            Task UpdateMemberAsync(Member member);
            Task DeleteMemberAsync(int id);
            Task<Member> GetMemberByIdAsync(int id);
            Task<IEnumerable<Member>> GetAllMembersAsync();
        }
    }


