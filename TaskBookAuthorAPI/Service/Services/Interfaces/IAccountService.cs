﻿using Service.DTOs.Account;
using Service.Helpers.Account;


namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task CreateRoleAsync();
        Task<LoginResponse> SignInAsync(LoginDto model);
    }
}
