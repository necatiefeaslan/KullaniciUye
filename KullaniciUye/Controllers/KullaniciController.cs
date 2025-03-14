using Microsoft.AspNetCore.Mvc;
using KullaniciUye.Data;
using KullaniciUye.Models;
using System.Linq;

namespace KullaniciUye.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KullaniciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kullanici
        public IActionResult Index()
        {

         var kullanicilar = _context.Kullanicilar.ToList();
            return View(kullanicilar);
        }

        // GET: Kullanici/Details/5
        public IActionResult Details(int id)
        {
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                
                _context.Kullanicilar.Add(kullanici);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public IActionResult Edit(int id)
        {
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Kullanici kullanici)
        {
           var guncellenecekKullanici = _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
            if (guncellenecekKullanici != null)
            {
                guncellenecekKullanici.Ad = kullanici.Ad;
                guncellenecekKullanici.Soyad = kullanici.Soyad;
                guncellenecekKullanici.Email = kullanici.Email;
                guncellenecekKullanici.Sifre = kullanici.Sifre;
                _context.SaveChanges();
               
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Kullanici/Delete/5
        public IActionResult Delete(int id)
        {
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
