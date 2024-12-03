using SimpleBlog.Application.Authentication;
using SimpleBlog.Application.DTOs.Users.Requests;
using SimpleBlog.Application.DTOs.Users.Responses;
using SimpleBlog.Application.Exceptions;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Data.Interfaces;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Utils;

namespace SimpleBlog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task CreateAsync(CreateUserRequest createUserRequest)
        {
            User? existingUser = await _userRepository.GetByEmailAsync(createUserRequest.Email);
            if (existingUser != null) throw new BadRequestHttpException("Esse e-mail já está cadastrado. Tente novamente com outro e-mail.");

            User newUser = new User(
                createUserRequest.Name,
                createUserRequest.Email,
                PasswordUtils.HashPassword(createUserRequest.Password)
            );

            Guid? CreatedUserId = await _userRepository.CreateAsync(newUser);
            if (CreatedUserId == null) throw new InternalServerErrorHttpException("Ocorreu um erro ao tentar criar o usuário. Tente novamente em alguns minutos.");
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest authenticateRequest)
        {
            User? existingUser = await _userRepository.GetByEmailAsync(authenticateRequest.Email);
            if (existingUser == null) throw new BadRequestHttpException("Usuário ou senha inválidos.");

            bool isCorrectPassword = PasswordUtils.VerifyPassword(authenticateRequest.Password, existingUser.Password);
            if (!isCorrectPassword) throw new BadRequestHttpException("Usuário ou senha inválidos.");

            existingUser.Password = string.Empty;

            string token = _jwtService.GenerateJwtToken(existingUser);

            return new AuthenticateResponse(existingUser, token);
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            User? existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null) throw new NotFoundHttpException($"Usuário não encontrado!");

            return existingUser;
        }
    }
}
