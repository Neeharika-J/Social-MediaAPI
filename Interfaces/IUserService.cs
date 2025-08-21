using Microsoft.AspNetCore.Mvc;
using SMApi.DTO;

namespace SMApi.Interfaces
{
    public interface IUserService
    {
        Task<(string token, DateTime expiry)> createUserAsync(UserCreateDTO userDto);
        Task<IEnumerable<UserReadDTO>> getAllUsersAsync();
        Task<UserReadDTO> getUserByIdAsync(int userid);
        Task<UserReadDTO> updateUserByIdAsync(UserUpdateDTO userDto);
        Task<AuthResponseDTO> loginUserAsync(LoginDTO loginDto);
        Task deleteUserAsync(string email);
    }
}
