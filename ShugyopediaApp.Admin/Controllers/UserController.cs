﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShugyopediaApp.Admin.Mvc;
using ShugyopediaApp.Data.Models;
using ShugyopediaApp.Services.Interfaces;
using ShugyopediaApp.Services.ServiceModels;
using ShugyopediaApp.Services.Services;
using System;
using System.Collections.Generic;

namespace ShugyopediaApp.Admin.Controllers
{
    public class UserController : ControllerBase<UserController>
    {
        private readonly IUserService _userService;
        public UserController(
            IUserService userService,
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<UserViewModel> users = _userService.GetUsers();
            return View(users);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(UserViewModel user)
        {
            try
            {
                _userService.AddUser(user, this.UserId);
                TempData["SuccessMessage"] = "Successfully Added";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error Adding: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RedirectEditUser(UserViewModel user)
        {
            UserViewModel editUserData = new UserViewModel();
            editUserData.Id = user.Id;
            editUserData.UserId = user.UserId;
            editUserData.Name = user.Name;
            editUserData.UserEmail = user.UserEmail;
            editUserData.Password = user.Password;
            return View("EditUser", editUserData);
        }
        [HttpPost]
        public IActionResult EditUser(UserViewModel user)
        {
            try
            {
                _userService.EditUser(user, this.UserId);
                TempData["SuccessMessage"] = "Successfully Edited";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error Editing: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteUser(User user)
		{
            try
            {
                _userService.DeleteUser(user.Id);
                TempData["SuccessMessage"] = "Successfully Deleted";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error Deleting: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
