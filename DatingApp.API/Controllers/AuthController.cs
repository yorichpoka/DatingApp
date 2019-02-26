using DatingApp.API.Models.Data;
using DatingApp.API.Models.Entity;
using DatingApp.API.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Models.Dtos;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using DatingApp.API.Models.Interface;

namespace DatingApp.API.Controllers
{
    // http://localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region  Attributes
        private readonly IAuthRepository _Repo;
        private readonly IConfiguration _Config;
        #endregion

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this._Repo = repo;
            this._Config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await this._Repo.UserExist(userForRegisterDto.Username))
                return BadRequest("Username already exist.");

            var userToCreate = new User {
                Username = userForRegisterDto.Username
            };

            var createdUser = await this._Repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userForRepo = await this._Repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if(userForRepo == null)
                return Unauthorized();

            var claims = new []
            {
                new Claim(ClaimTypes.NameIdentifier, userForRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userForRepo.Username)
            };

            var key =   new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(
                                this._Config.GetSection("AppSettings:Token").Value
                            )
                        );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return 
                Ok(new {
                    token = tokenHandler.WriteToken(token)
                });
        }

    }
}