using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReederPortal.Models;
using ReederPortal.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ReederPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly Context _context;

        public AccountController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var personel = await _context.Personels
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Sifre == model.Sifre);

                if (personel != null)
                {
                    // Giriş başarılı, session veya cookie işlemleri burada yapılabilir
                    HttpContext.Session.SetString("Email", personel.Email);
                    return RedirectToAction("Index", "Personelim");
                }

                ModelState.AddModelError("", "Girdiğiniz şifre eksik veya hatalı. " +
                    "Kontrol edip tekrar deneyin.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Kullanıcı çıkışı işlemleri burada yapılabilir
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Login");
        }
    }
}
