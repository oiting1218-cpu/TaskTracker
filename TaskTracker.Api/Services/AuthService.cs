using Microsoft.AspNetCore.Identity;
using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;
using TaskTracker.Api.Exceptions;
using TaskTracker.Api.Repositories;

namespace TaskTracker.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task RegisterUser(RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                //Note: Middleware catch this and return e.g. { "status": 409, "message": "Email 'abc@test.com' is already registered." }
                //Best practice: DO NOT throw exception in controller, throw exception in service layer
                throw new EmailAlreadyExistsException(dto.Email);
            }
            else
            {
                var newUser = new User
                {
                    Email = dto.Email
                };
                var passwordHasher = new PasswordHasher<User>();
                newUser.PasswordHash = passwordHasher.HashPassword(newUser, dto.Password); //hash password into that newUser
                await _userRepository.AddUserAsync(newUser);
            }
        }

        public async Task<AuthResponseDto?> Login(LoginDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email);

            if (user == null)
                throw new InvalidCredentialsException();

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result != PasswordVerificationResult.Success)
                throw new InvalidCredentialsException();

            //generate token
            var token = _jwtService.GenerateToken(user);
            return new AuthResponseDto
            {
                Email = user.Email,
                Token = token
            };
        }
    }
}
