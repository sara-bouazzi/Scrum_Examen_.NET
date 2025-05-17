using System;
using System.Collections.Generic;
using System.Linq;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    internal class TacheService : Service<Tache>, ITacheService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TacheService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override IEnumerable<Tache> GetAll()
        {
            // SANS Include() → lazy loading prendra le relai
            return base.GetAll();
        }

        public int dureeMoy(DateTime dd, DateTime df)
        {
            var taches = GetAll()
                .Where(t => t.DateDebut != null && t.DateFin != null && t.DateFin < DateTime.Now)
                .ToList();

            if (!taches.Any()) return 0;

            return (int)taches.Average(t => (t.DateFin - t.DateDebut).TotalDays);
        }

        public int nombredetache(string matricule)
        {
            return GetAll()
                .Count(t => t.MyMembre != null &&
                            t.MyMembre.Matricule.ToString() == matricule &&
                            t.DateFin < DateTime.Now);
        }

        public IList<Tache> tacheprojet()
        {
            return GetAll()
                .OrderBy(t => t.MySprint?.MyProjet?.Titre)
                .ToList();
        }
    }
}
