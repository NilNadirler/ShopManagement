using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(UserForRegisterDto userForLoginDto)
        {
            return View();
        }
    }
}
