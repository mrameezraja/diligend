using Diligend.Data.Entities;
using Diligend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diligend.Services
{
    public interface IFormService
    {
        Task<List<RegistrationForm>> GetSubmissionsAsync();
        Task CreateOrUpdateAsync(RegistrationFormVM formVM, string username);
        Task<RegistrationFormVM> GetAsync(Guid id);
        Task<RegistrationFormVM> GetAsync(string username);
        Task UpdateAsync(RegistrationFormVM formVM);
        Task<List<College>> GetColleges();
    }
}
