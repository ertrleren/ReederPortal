using Microsoft.AspNetCore.Mvc;
using ReederPortal.Models;

namespace ReederPortal.Controllers
{
    public class SeviyeController : Controller
    {
        private readonly Context _context;

        public SeviyeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerlerS = _context.Seviyes.Select(s => new
            {
                SeviyeID = s.SeviyeID,
                SeviyeAd = s.SeviyeAd ?? "Belirtilmemiş", // Null kontrolü ve varsayılan değer atama

            }).ToList();

            var seviyeList = degerlerS.Select(s => new Seviye
            {
                SeviyeID = s.SeviyeID,
                SeviyeAd = s.SeviyeAd,

            }).ToList();

            return View(seviyeList);
        }


        [HttpGet]
        public IActionResult YeniSeviye() //Sayfa yüklendiği zaman burası çalışacak
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniSeviye(Seviye b) // Sayfada bir post işlemi gerçekleştiği zaman burası çalışacak
        {
            _context.Seviyes.Add(b);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult SeviyeSil(int id)  //departman silme işlemi
        {
            var sev = _context.Seviyes.Find(id);  // departmanın dep'i  (Parametre olarak gönderdiğim id yi bul)
            _context.Seviyes.Remove(sev); // departmanların içerisinden dep 'ten gelen değeri sil (dep id ye göre gönderdiğimiz satırın tamamını tutuyor ve satırı siliyor )
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SeviyeGetir(int id)
        {
            var seviyeler = _context.Seviyes.Find(id);    // Burda seçtiğimiz departmanın bilgilerini textbox a yazıyor
            return View("SeviyeGetir", seviyeler);
        }

        public IActionResult SeviyeGuncelle(Seviye d)
        {
            var seviye = _context.Seviyes.Find(d.SeviyeID);
            if (seviye != null)
            {
                seviye.SeviyeAd = d.SeviyeAd;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult SeviyeDetay(int id)
        {
            var degerlerU = _context.Personels.Where(x => x.UnvanID == id).ToList();
            var unvad = _context.Unvans.Where(x => x.UnvanID == id).Select(y => y.UnvanAd).FirstOrDefault();
            ViewBag.brmu = unvad;
            return View(degerlerU);
        }
    }
}
