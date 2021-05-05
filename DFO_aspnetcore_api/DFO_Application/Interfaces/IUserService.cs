using System.Collections.Generic;
using System.Threading.Tasks;
using DFO_Application.DTOs.User;
using DFO_Application.Wrappers;

namespace DFO_Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseBase<int>> RegisterAsync(RegisterUserRequest request);

        Task<ResponseBase<UserInfo>> GetByIdAsync(int id);

        Task<ResponseBase<List<UserInfo>>> GetAllAsync();

        Task<ResponseBase<UserInfo>> Update(UpdateUserRequest request);
    }
}