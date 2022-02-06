using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diligend.Data.Entities
{
    public class CollegeForm
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CollegeId { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public College College { get; set; }
    }
}
