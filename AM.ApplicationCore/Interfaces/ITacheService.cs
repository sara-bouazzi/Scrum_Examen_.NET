using System;
using System.Collections.Generic;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface ITacheService : IService<Tache>
    {
        int nombredetache(string matricule);
        int dureeMoy(DateTime dd, DateTime df);
        IList<Tache> tacheprojet();
    }
}
