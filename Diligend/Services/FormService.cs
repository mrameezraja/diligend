using Diligend.Data;
using Diligend.Data.Entities;
using Diligend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diligend.Services
{
    public class FormService : IFormService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public FormService(ApplicationDbContext dbContext,
            UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<RegistrationFormVM> GetAsync(Guid id)
        {
            var form = await _dbContext.RegistrationForms.FirstOrDefaultAsync(_ => _.Id == id);

            return Build(form);
        }

        public async Task<RegistrationFormVM> GetAsync(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);

            var id = Guid.Parse(user.Id);

            var form = await _dbContext.RegistrationForms.FirstOrDefaultAsync(_ => _.StudentId == id);

            return Build(form);
        }

        private RegistrationFormVM Build(RegistrationForm form)
        {
            return new RegistrationFormVM
            {
                Id = form.Id,
                FirstName = form.FirstName,
                FirstNameComments = form.FirstNameComments,
                FirstNameScore = form.FirstNameScore,
                LastName = form.LastName,
                LastNameComments = form.LastNameComments,
                LastNameScore = form.LastNameScore,
                Age = form.Age,
                AgeComments = form.AgeComments,
                AgeScore = form.AgeScore,
                SchoolName = form.SchoolName,
                SchoolNameComments = form.SchoolNameComments,
                SchoolNameScore = form.SchoolNameScore
            };
        }

        public async Task CreateOrUpdateAsync(RegistrationFormVM formVM, string username)
        {
            var user = await _userManager.FindByEmailAsync(username);

            var id = Guid.Parse(user.Id);

            var form = await _dbContext.RegistrationForms.FirstOrDefaultAsync(_ => _.StudentId == id);

            if (form == null)
            {
                form = new RegistrationForm
                {
                    Id = Guid.NewGuid(),
                    StudentId = id,
                    FirstName = formVM.FirstName,
                    LastName = formVM.LastName,
                    Age = formVM.Age,
                    SchoolName = formVM.SchoolName,
                    IsApproved = false,
                    CreationTime = DateTime.Now
                };

                await _dbContext.RegistrationForms.AddAsync(form);

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                form.FirstName = formVM.FirstName;
                form.LastName = formVM.LastName;
                form.Age = formVM.Age;
                form.SchoolName = formVM.SchoolName;

                _dbContext.RegistrationForms.Update(form);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(RegistrationFormVM formVM)
        {
            var form = await _dbContext.RegistrationForms.FirstOrDefaultAsync(_ => _.Id == formVM.Id);

            if(form != null)
            {
                form.FirstName = formVM.FirstName;
                form.FirstNameComments = formVM.FirstNameComments;
                form.FirstNameScore = formVM.FirstNameScore;

                form.LastName = formVM.LastName;
                form.LastNameComments = formVM.LastNameComments;
                form.LastNameScore = formVM.LastNameScore;

                form.Age = formVM.Age;
                form.AgeComments = formVM.AgeComments;
                form.AgeScore = formVM.AgeScore;

                form.SchoolName = formVM.SchoolName;
                form.SchoolNameComments = formVM.SchoolNameComments;
                form.SchoolNameScore = formVM.SchoolNameScore;

                _dbContext.RegistrationForms.Update(form);

                await _dbContext.SaveChangesAsync();
            }           
        }

        public async Task<List<RegistrationForm>> GetSubmissionsAsync()
        {
            var forms = await _dbContext.RegistrationForms.AsNoTracking().ToListAsync();

            return forms;
        }

        public async Task<List<College>> GetColleges()
        {
            var colleges = await _dbContext.Colleges.AsNoTracking().ToListAsync();

            return colleges;
        }
    }
}
