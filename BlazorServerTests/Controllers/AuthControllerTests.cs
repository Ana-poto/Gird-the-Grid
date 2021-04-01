﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WebApplication1.Services;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers.Tests
{
    [TestClass()]
    public class AuthControllerTests
    {
        private readonly UserService _userService;
        private readonly User user = new User();


        [TestMethod()]
        public async Task RegisterTestAsync()
        {
            var result = await new AuthController(_userService).Register(user);
            Assert.AreEqual(typeof(Task<IActionResult>), result.GetType());
        }

        [TestMethod()]
        public async Task LoginTestAsync()
        {
            var result = await new AuthController(_userService).Login(user);
            Assert.AreEqual(typeof(Task<IActionResult>), result.GetType());
        }
    }
}