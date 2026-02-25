using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskTracker.Api.Data;
using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;
using TaskTracker.Api.Exceptions;

namespace TaskTracker.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        public AuthService(ApplicationDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task RegisterUser(RegisterUserDto dto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
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
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AuthResponseDto?> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

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
