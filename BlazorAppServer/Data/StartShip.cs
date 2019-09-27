using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppServer.Data
{
    public class StartShip
    {
        [Required]
        [StringLength(16, ErrorMessage ="Identifier too long (16 charactor limit.)")]
        public string Identifier { get; set; }

        public string Description { get; set; }

        [Required]
        public string Classification { get; set; }

        [Range(1, 100000, ErrorMessage ="Accomodation invalid (1-100000)")]
        public int MaximumAccomodation { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "This form disallows unapproved ships.")]
        public bool IsValidateDesign { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; } = DateTime.Now;
    }
}
