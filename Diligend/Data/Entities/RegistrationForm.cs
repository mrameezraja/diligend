using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diligend.Data.Entities
{
    public class RegistrationForm
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string FirstNameComments { get; set; }
        public string FirstNameScore { get; set; }
        public string LastName { get; set; }
        public string LastNameComments { get; set; }
        public string LastNameScore { get; set; }
        public int Age { get; set; }
        public string AgeComments { get; set; }
        public string AgeScore { get; set; }
        public string SchoolName { get; set; }
        public string SchoolNameComments { get; set; }
        public string SchoolNameScore { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
    }
}
