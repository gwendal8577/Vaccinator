using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccinator.Models
{
    public class Personne
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Sexe { get; set; }

        public DateTime DateNaissance { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Injection> Injections { get; set; }
    }
}
