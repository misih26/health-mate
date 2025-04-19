using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entity;

namespace health_mate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserLogic UserLogic;
        public UserController(UserLogic UserLogic)
        {
            this.UserLogic = UserLogic;
        }

        [HttpPost("Login")]
        public TokenDTO Get([FromBody] LoginDTO loginDTO)
        {
            return UserLogic.GetUserByNameAndPassword(loginDTO.Username, loginDTO.Password);
        }


        [HttpGet]
        public List<UserDTO> GetUsers()
        {
            return UserLogic.GetAllUsers();
        }

        [HttpGet("{id}")]
        public UserDTO GetUser(string id)
        {
            return UserLogic.GetById(id);
        }

        [HttpPost]
        public SuccessDTO AddUser([FromBody] CustomerCreationDTO userDTO)
        {
            return UserLogic.AddUser(userDTO);
        }

        [HttpPut]
        [Authorize(Roles = "customer,admin")]
        public SuccessDTO UpdateUser(PasswordModificationDTO passwordModificationDTO)
        {
            return UserLogic.ModifyUser(passwordModificationDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public SuccessDTO DeleteUser(string id)
        {
            return UserLogic.RemoveUser(id);
        }


    }
}
