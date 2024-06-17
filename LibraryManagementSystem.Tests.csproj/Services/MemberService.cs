using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task AddMemberAsync(Member member)
        {
            await _memberRepository.AddMemberAsync(member);
        }

        public async Task UpdateMemberAsync(Member member)
        {
            await _memberRepository.UpdateMemberAsync(member);
        }

        public async Task DeleteMemberAsync(int id)
        {
            await _memberRepository.DeleteMemberAsync(id);
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _memberRepository.GetMemberByIdAsync(id);
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberRepository.GetAllMembersAsync();
        }
    }
}




