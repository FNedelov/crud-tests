using CRUD.API.Interfaces;
using CRUD.Common.DTOs;
using CRUD.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.API.Services
{
    public class UserService : IUserService
    {
        private readonly CrudappContext _dbContext;

        public UserService(CrudappContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser()
        {
            throw new NotImplementedException();
        }

        public async Task EditUser()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserRoleDto>> GetUsersList()
        {
            var usersList = await _dbContext.Users
                .Join(_dbContext.Roles,
                users => users.RoleId,
                roles => roles.RoleId,
                (users, roles) => new UserRoleDto
                {
                    UserName = users.Name,
                    RoleDefinition = roles.Definition
                }).ToListAsync();

            return usersList;
        }
    }
}