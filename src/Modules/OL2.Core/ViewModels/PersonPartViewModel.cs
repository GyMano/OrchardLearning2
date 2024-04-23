using Microsoft.AspNetCore.Mvc.ModelBinding;
using OL2.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL2.Core.ViewModels
{
    public class PersonPartViewModel
    {
        public string? Name { get; set; }
        public Handedness Handedness { get; set; }
        public DateTime? BirthDateUtc { get; set; }

        
    }
}
