
using Dapper;
using eCommerceCore.Entities;
using eCommerceCore.RepositoryContracts;
using eCommerceInfrastructure.DbContext;

namespace eCommerceInfrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dapperDbContext;
        public UserRepository(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {


            string query = "insert into public.user(name,email,password,gender) Values(@Name,@Email,@Password,@Gender)";
            int rowsAffected = await _dapperDbContext.DbConnection.ExecuteAsync(query,user);

            if (rowsAffected > 0) {

                return user;
            }
            else
            {
                return null;
            }
        }

        public  async Task<ApplicationUser?> GetUserByUserId(Guid id)
        {
            string query = "select * from public.user where id = @id";
            var parameters = new { Id = id };
            ApplicationUser? applicationUser =
                await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync(query, parameters);
            return applicationUser;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? username, string? password)
        {

            string query = "select * from public.user where email = @username and password = @password";
            var paramaters = new {
            Password = password,
            Username = username};
           ApplicationUser? result = await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, paramaters);

            if (result == null)
            {
                return null;
            }
            return result;
       
            
        }
    }
}
