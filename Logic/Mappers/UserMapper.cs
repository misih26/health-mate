using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Mappers
{
    public class UserMapper
    {
        public UserDTO Map(User user)
        {
            UserDTO userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            userDTO.Role = user.Role;

            return userDTO;
        }

        public List<UserDTO> Map(List<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (User user in  users)
            {
                userDTOs.Add(Map(user));
            }

            return userDTOs;
        }
    }
}
