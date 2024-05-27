using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReederPortal.Models;

namespace ReederPortal.Controllers
{
    public class PersonelimController : Controller  
    {
        private readonly Context _context;

        public PersonelimController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Personels.Include(x => x.Birim)
                                              .Include(x => x.Unvan)
                                              .Include(x => x.Seviye)
                                              .ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniPersonel()
        {
            ViewBag.dgr = new SelectList(_context.Birims.ToList(), "BirimID", "BirimAd");
            ViewBag.dgru = new SelectList(_context.Unvans.ToList(), "UnvanID", "UnvanAd");
            ViewBag.dgrs = new SelectList(_context.Seviyes.ToList(), "SeviyeID", "SeviyeAd");
            return View();
        }

        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            _context.Personels.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id)
        {
            var per = _context.Personels.Find(id);
            _context.Personels.Remove(per);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PersonelGetir(int id)
        {
            var personel = _context.Personels.Include(x => x.Birim)
                                              .Include(x => x.Unvan)
                                              .Include(x => x.Seviye)
                                              .FirstOrDefault(x => x.PersonelID == id);

            if (personel != null)
            {
                var birimler = _context.Birims.Select(b => new SelectListItem
                {
                    Text = b.BirimAd,
                    Value = b.BirimID.ToString(),
                    Selected = (personel.BirimID != null && b.BirimID == personel.BirimID)
                }).ToList();

                var unvanlar = _context.Unvans.Select(b => new SelectListItem
                {
                    Text = b.UnvanAd,
                    Value = b.UnvanID.ToString(),
                    Selected = (personel.UnvanID != null && b.UnvanID == personel.UnvanID)
                }).ToList();

                var seviyeler = _context.Seviyes.Select(b => new SelectListItem
                {
                    Text = b.SeviyeAd,
                    Value = b.SeviyeID.ToString(),
                    Selected = (personel.SeviyeID != null && b.SeviyeID == personel.SeviyeID)
                }).ToList();

                ViewBag.Birimler = birimler;
                ViewBag.Unvanlar = unvanlar;
                ViewBag.Seviyeler = seviyeler;
            }

            return View(personel);
        }

        [HttpPost]
        public IActionResult PersonelGuncelle(Personel p)
        {
            var per = _context.Personels.Find(p.PersonelID);
            if (per == null)
            {
                ViewBag.ErrorMessage = "Personel bulunamadı!";
                return View("Error");
            }

            // Diğer özellikleri güncelle
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            per.DogumYer = p.DogumYer;
            per.DogumTarih = p.DogumTarih;
            per.Cinsiyet = p.Cinsiyet;
            per.SurucuBelgesi = p.SurucuBelgesi;
            per.MedeniDurum = p.MedeniDurum;
            per.EsCalismaDurum = p.EsCalismaDurum;
            per.CocukSayisi = p.CocukSayisi;
            per.SigaraKullanimi = p.SigaraKullanimi;
            per.Hobi = p.Hobi;
            per.Mezuniyet = p.Mezuniyet;
            per.IseBaslamaTarih = p.IseBaslamaTarih;
            per.Fotograf = p.Fotograf;

            // BirimID'yi güncelle
            if (p.Birim != null && p.Birim.BirimID != 0)
            {
                var yeniBirim = _context.Birims.FirstOrDefault(x => x.BirimID == p.Birim.BirimID);
                if (yeniBirim != null)
                {
                    per.BirimID = yeniBirim.BirimID;
                }
                else
                {
                    ViewBag.ErrorMessage = "Birim bulunamadı!";
                    return View("Error");
                }
            }

            // UnvanID'yi güncelle
            if (p.Unvan != null && p.Unvan.UnvanID != 0)
            {
                var yeniUnvan = _context.Unvans.FirstOrDefault(x => x.UnvanID == p.Unvan.UnvanID);
                if (yeniUnvan != null)
                {
                    per.UnvanID = yeniUnvan.UnvanID;
                }
                else
                {
                    ViewBag.ErrorMessage = "Unvan bulunamadı!";
                    return View("Error");
                }
            }

            

            // SeviyeID'yi güncelle
            if (p.Seviye != null && p.Seviye.SeviyeID != 0)
            {
                var yeniSeviye = _context.Seviyes.FirstOrDefault(x => x.SeviyeID == p.Seviye.SeviyeID);
                if (yeniSeviye != null)
                {
                    per.SeviyeID = yeniSeviye.SeviyeID;
                }
                else
                {
                    ViewBag.ErrorMessage = "Seviye bulunamadı!";
                    return View("Error");
                }
            }
            per.Email = p.Email;
            per.Sifre = p.Sifre;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
