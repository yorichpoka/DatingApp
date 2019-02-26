using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Models.Dtos;
using DatingApp.API.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DatingApp.API.Controllers
{
    // http://localhost:5000/api/users
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region  Attributes
        private readonly IDatingRepository _Repo;
        private readonly IMapper _Mapper;
        #endregion

        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            this._Mapper = mapper;
            this._Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await this._Repo.GetUsers();
            var userToReturn = this._Mapper.Map<IEnumerable<UserForListDto>>(users);

            return
                Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await this._Repo.GetUser(id);
            var userToReturn = this._Mapper.Map<UserForDetailedDto>(user);

            return
                Ok(userToReturn);
        }
    }
}