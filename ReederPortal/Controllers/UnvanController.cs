using Microsoft.AspNetCore.Mvc;
using ReederPortal.Models;

namespace ReederPortal.Controllers
{
    public class UnvanController : Controller
    {
        private readonly Context _context;

        public UnvanController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var unvanList = _context.Unvans.ToList();
            return View(unvanList);
        }

        [HttpGet]
        public IActionResult YeniUnvan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniUnvan(Unvan b)
        {
            _context.Unvans.Add(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UnvanSil(int id)
        {
            var un = _context.Unvans.Find(id);
            _context.Unvans.Remove(un);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UnvanGetir(int id)
        {
            var unvan = _context.Unvans.Find(id);
            return View("UnvanGetir", unvan);
        }

        public IActionResult UnvanGuncelle(Unvan d)
        {
            var unvan = _context.Unvans.Find(d.UnvanID);
            if (unvan != null)
            {
                unvan.UnvanAd = d.UnvanAd;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult UnvanDetay(int id)
        {
            var personels = _context.Personels.Where(x => x.UnvanID == id).ToList();
            var unvanAd = _context.Unvans.Where(x => x.UnvanID == id).Select(y => y.UnvanAd).FirstOrDefault();
            ViewBag.brmu = unvanAd;
            return View(personels);
        }
    }
}
