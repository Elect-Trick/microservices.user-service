using eCommerceCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary>
        /// Retrieves an application user based on the provided unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>An <see cref="ApplicationUser"/> instance if a user with the given identifier exists; otherwise, null.</returns>
        Task<ApplicationUser?> GetUserByUserId(Guid id);

        Task<ApplicationUser?> GetUserByEmailAndPassword(string? username, string? password);
    }
}
