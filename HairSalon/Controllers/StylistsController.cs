using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private readonly HairSalonContext _db;
        public StylistsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Stylist> stylistsModel = _db.Stylists.ToList();
            return View(stylistsModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Stylist selectedStylist = _db.Stylists.Include(stylist => stylist.Clients).FirstOrDefault( stylist => stylist.StylistId == id);
            return View(selectedStylist);
        }

        public ActionResult Edit(int id)
        {
            Stylist selectedStylist = _db.Stylists.FirstOrDefault( stylist => stylist.StylistId == id);
            return View(selectedStylist);
        }

        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
            _db.Stylists.Update(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Stylist selectedStylist = _db.Stylists.FirstOrDefault( stylist => stylist.StylistId == id);
            return View(selectedStylist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            Stylist selectedStylist = _db.Stylists.FirstOrDefault( stylist => stylist.StylistId == id);
            _db.Stylists.Remove(selectedStylist);
            _db.SaveChanges();
            return RedirectToAction("Index");        
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

