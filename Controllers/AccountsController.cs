﻿using Microsoft.AspNetCore.Mvc;
using VOB.Data.Context;
using VOB.Models;
using VOB.Repositories;

namespace VOB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAccountRepo _accountRepo;

        public AccountsController(DataContext context,
                                  IAccountRepo accountRepo)
        {
            _context = context;
            _accountRepo = accountRepo;
        }

        [HttpPost("CreateRolesBase")]
        public async Task<IActionResult> CreateRolesBase(string? code)
        {
            if (code == null)
            {
                return BadRequest();
            }

            if (code.Equals("Abc@123"))
            {
                var roles = new List<string>() { "Admin", "Owner", "User" };

                foreach (var role in roles)
                {
                    await _accountRepo.CreateRolesAsync(role);
                }
            }

            return Ok();
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await _accountRepo.SignUp(signUpModel);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            return CreatedAtAction("SignUp", signUpModel.Email);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<SignInRs>> SignIn(SignInModel signInModel)
        {
            var result = await _accountRepo.SignIn(signInModel.Email, signInModel.Password);

            if (result == null)
            {
                return Unauthorized();
            }

            if (result.User == null)
            {
                return ValidationProblem(result.Token, null, 401, "Unauthorized");
            }

            return result;
        }
    }
}
