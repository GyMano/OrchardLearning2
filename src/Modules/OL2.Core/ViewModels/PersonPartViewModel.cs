using OL2.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL2.Core.ViewModels
{
    internal class PersonPartViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Handedness Handedness { get; set; }
        [Required]
        public DateTime? BirthDateUtc { get; set; }
    }
}
