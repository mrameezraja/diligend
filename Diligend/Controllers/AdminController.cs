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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IFormService _formService;
        public AdminController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            var forms = await _formService.GetSubmissionsAsync();

            return View(forms);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var form = await _formService.GetAsync(id);

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegistrationFormVM form)
        {
            await _formService.UpdateAsync(form);

            return RedirectToAction("Index");
        }
    }
}