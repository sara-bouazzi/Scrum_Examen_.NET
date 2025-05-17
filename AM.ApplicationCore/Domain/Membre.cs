using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace AM.ApplicationCore.Domain
{
    public class Membre
    {
        [Key]
        public string Matricule { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public String Password { get; set; }
        public string Nom { get; set; }
        public String Prenom { get; set; }
        public virtual IList <Tache> Taches { get; set; }
    }
}
