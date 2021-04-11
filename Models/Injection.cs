using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccinator.Models
{
    public class Injection
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Marque { get; set; }

        public int NumeroLot { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateRappel { get; set; }

        [Required]
        [Display(Name = "Vaccin")]
        public virtual Vaccin Vaccin { get; set; }

        [Required]
        [Display(Name = "Personne")]
        public virtual Personne Personne { get; set; }
    }
}
