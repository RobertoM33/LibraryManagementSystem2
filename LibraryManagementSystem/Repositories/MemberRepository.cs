using Dapper;
using LibraryManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddMemberAsync(Member member)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "INSERT INTO Members (FirstName, LastName, BirthYear, Address, RegistrationDate) VALUES (@FirstName, @LastName, @BirthYear, @Address, @RegistrationDate)";
            await connection.ExecuteAsync(query, member);
        }

        public async Task UpdateMemberAsync(Member member)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "UPDATE Members SET FirstName = @FirstName, LastName = @LastName, BirthYear = @BirthYear, Address = @Address WHERE Id = @Id";
            await connection.ExecuteAsync(query, member);
        }

        public async Task DeleteMemberAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "DELETE FROM Members WHERE Id = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Members WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Members";
            return await connection.QueryAsync<Member>(query);
        }
    }
}
