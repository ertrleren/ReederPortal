using Microsoft.AspNetCore.Mvc;
using ReederPortal.Models;

namespace ReederPortal.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Birims.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniBirim() //Sayfa yüklendiği zaman burası çalışacak
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b) // Sayfada bir post işlemi gerçekleştiği zaman burası çalışacak
        {
            _context.Birims.Add(b);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimSil(int id)  //departman silme işlemi
        {
            var dep = _context.Birims.Find(id);  // departmanın dep'i  (Parametre olarak gönderdiğim id yi bul)
            _context.Birims.Remove(dep); // departmanların içerisinden dep 'ten gelen değeri sil (dep id ye göre gönderdiğimiz satırın tamamını tutuyor ve satırı siliyor )
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimGetir(int id)
        {
            var depart = _context.Birims.Find(id);    // Burda seçtiğimiz departmanın bilgilerini textbox a yazıyor
            return View("BirimGetir", depart);
        }

        public IActionResult BirimGuncelle(Birim d)
        {
            var dep = _context.Birims.Find(d.BirimID);      // d parametresi ile bir id gönderiyorum bu ifadeyle dep isminde değişken oluşuyor ve o değerin büütün satırını buluyor
            dep.BirimAd = d.BirimAd;                 // Daha sonra bu satıra parametreden gelen değer ile değiştiriyor.
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimDetay(int id)
        {
            var degerler = _context.Personels.Where(x => x.BirimID == id).ToList();
            var brmad = _context.Birims.Where(x => x.BirimID == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);
        }
    }
}
