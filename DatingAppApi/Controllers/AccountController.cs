using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingAppApi.Data;
using DatingAppApi.DTOs;
using DatingAppApi.Entities;
using DatingAppApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingAppApi.Controllers
{    
    public class AccountController : BaseApiController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly DataContext _context;       

        public AccountController(IAccountRepository accountRepository, DataContext context)
        {
            _accountRepository = accountRepository;
            _context = context;           
        }
       
       [HttpPost("register")]
       public async Task<IActionResult> Register(RegisterDTO registerDTO) 
       {
        if(await _accountRepository.UserExists(registerDTO.Username))
        {
            return BadRequest("Username Taken!!");
        }
          
          var user = await _accountRepository.RegisterUser(registerDTO.Username, registerDTO.Password);

          return Ok(user);
       }       

       [HttpPost("login")]
       public async Task<IActionResult> Login(LoginDTO loginDTO)
       {
           var user = await _accountRepository.Login(loginDTO);
            if(user ==  null) return Unauthorized("Invalid credentials.");

            return Ok(user);
       }
       }
    }
