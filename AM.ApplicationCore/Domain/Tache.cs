using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AM.ApplicationCore.Domain
{
    public class Tache
    {
        public enum EtatTache
        {
            Ouverte,
            ENCOURS,
            Fermee
        }
        public string Titre { get; set; }
        public EtatTache Etat { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public virtual Sprint MySprint { get; set; }
        public virtual Membre MyMembre { get; set; }
        public int SprintKey { get; set; }
        public String MembreKey { get; set; }

    }
}
