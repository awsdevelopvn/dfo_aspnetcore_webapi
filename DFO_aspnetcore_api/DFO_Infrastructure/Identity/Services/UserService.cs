using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFO_Application.DTOs.User;
using DFO_Application.Exceptions;
using DFO_Application.Interfaces;
using DFO_Application.Loggings;
using DFO_Application.Wrappers;
using DFO_Infrastructure.Identity.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DFO_Infrastructure.Identity.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppLogger<UserService> _logger;
        public UserService(UserManager<ApplicationUser> userManager,
            IAppLogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        
        public async Task<ResponseBase<int>> RegisterAsync(RegisterUserRequest request)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                _logger.LogWarning($"Username '{request.UserName}' is already taken.");
                throw new ApiException($"Username '{request.UserName}' is already taken.");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                Age = request.Age,
                UserName = request.UserName,
                Address = request.Address
            };
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                _logger.LogWarning($"Email {request.Email} is already registered.");
                throw new ApiException($"Email {request.Email} is already registered.");
            }
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) throw new ValidationException(result.Errors.Select(e=> new ValidationFailure(e.Code, e.Description)));
            _logger.LogInformation($"User{request.UserName} is registered");
            return new ResponseBase<int>(user.Id, message: "User Registered.");
        }

        public async Task<ResponseBase<UserInfo>> GetByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                return new ResponseBase<UserInfo>(new UserInfo
                {
                    Id = user.Id,
                    Name = user.Name,
                    Address = user.Address,
                    Age = user.Age
                });
            }
            
            _logger.LogWarning($"Could not find user with id {id}");
            throw new KeyNotFoundException($"User {id} does not exist.");
        }

        public async Task<ResponseBase<List<UserInfo>>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return new ResponseBase<List<UserInfo>>(users.Select(u=> new UserInfo
            {
                Id = u.Id,
                Name = u.Name,
                Age = u.Age,
                Address = u.Address
            }).ToList());
        }

        public async Task<ResponseBase<UserInfo>> Update(UpdateUserRequest request)
        {
            var applicationUser = await _userManager.FindByIdAsync(request.Id.ToString());

            if (applicationUser == null)
            {
                throw new ApiException("User Not Found.");
            }
            
            applicationUser.Name = request.Name;
            applicationUser.Age = request.Age;
            applicationUser.Address = request.Address;
            await _userManager.UpdateAsync(applicationUser);
            return new ResponseBase<UserInfo>(new UserInfo
            {
                Id = request.Id,
                Address = request.Address,
                Age = request.Age,
                Name = request.Name
            });
        }
    }
}