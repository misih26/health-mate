using Model.Entity;
using Model;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Model.DTO;
using Logic.Mappers;
using BCrypt.Net;

namespace Logic
{
    public class UserLogic
    {
        public const string SECRET_KEY = "Th1SiSMySuP3rSecr3TKey!W1Th4dvancedD1fFicult1?!!!";
        private UserRepository UserRepository { get; set; }
        private UserMapper UserMapper { get; set; }

        public UserLogic(UserRepository userRepository, UserMapper userMapper)
        {
            UserRepository = userRepository;
            UserMapper = userMapper;
        }

        public List<UserDTO> GetAllUsers() 
        { 
            return UserMapper.Map(UserRepository.GetAllUsers()); 
        }

        public UserDTO GetById(string id)
        {
            return UserMapper.Map(UserRepository.GetUserById(id));
        }

        public SuccessDTO RemoveUser(string userId)
        {
            UserRepository.DeleteUser(userId);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

        public SuccessDTO ModifyUser(PasswordModificationDTO passwordModification)
        {
            User user = UserRepository.GetUserById(passwordModification.Id);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordModification.Password);

            UserRepository.ModifyUser(user);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

        public SuccessDTO AddUser(CustomerCreationDTO customerCreationDTO)
        {
            User user = new User(customerCreationDTO.Username, BCrypt.Net.BCrypt.HashPassword(customerCreationDTO.Password), "customer");

            UserRepository.SaveUser(user);

            SuccessDTO SuccessDTO = new SuccessDTO();
            SuccessDTO.Success = true;

            return SuccessDTO;
        }

        public TokenDTO GetUserByNameAndPassword(string userName, string password)
        {
            User user = UserRepository.GetUserByNameAndPassword(userName, password);

            if (user == null)
            {
                return null;
            } else {
                return new TokenDTO() { Jwt = GenerateJwtToken(user) };
            }
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY)); // Replace with your key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: "your-issuer", // Replace with your issuer
                audience: "your-audience", // Replace with your audience
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
