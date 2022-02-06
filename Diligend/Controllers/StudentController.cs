using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diligend.Models;
using Diligend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diligend.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        private readonly IFormService _formService;
        public StudentController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<IActionResult> Colleges()
        {
            var colleges = await _formService.GetColleges();

            return View(colleges);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var form = await _formService.GetAsync(User.Identity.Name);

            if(form == null)
            {
                form = new RegistrationFormVM();
            }

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegistrationFormVM formVM)
        {
            await _formService.CreateOrUpdateAsync(formVM, User.Identity.Name);

            return View(formVM);
        }
    }
}