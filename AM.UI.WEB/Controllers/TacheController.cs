using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static AM.ApplicationCore.Domain.Tache;
using AM.Infrastructure;

namespace AM.UI.WEB.Controllers
{
    public class TacheController : Controller
    {
        private readonly IService<Tache> tacheservice;
        private readonly IUnitOfWork unitOfWork;

        public TacheController(IService<Tache> tacheservice, IUnitOfWork unitOfWork)
        {
            this.tacheservice = tacheservice;
            this.unitOfWork = unitOfWork;
        }

        // GET: TacheController
        public ActionResult Index()
        {
            return View(tacheservice.GetAll()
                .Where(h => h.Etat == EtatTache.Ouverte)
                .OrderBy(h => h.Titre));
        }

        // GET: TacheController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TacheController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tache tacheSarra)
        {
            try
            {
                tacheservice.Add(tacheSarra);
                tacheservice.Commit(); // important si tu utilises UnitOfWork.Save()
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(tacheSarra);
            }
        }

        public ActionResult Details(int id) => View();

        public ActionResult Edit(int id) => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) => RedirectToAction(nameof(Index));

        public ActionResult Delete(int id) => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) => RedirectToAction(nameof(Index));
    }
}
