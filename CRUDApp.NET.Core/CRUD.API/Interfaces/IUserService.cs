using CRUD.Common.DTOs;

namespace CRUD.API.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserRoleDto>> GetUsersList();
        public Task AddUser();
        public Task EditUser();
        public Task DeleteUser();
    }
}