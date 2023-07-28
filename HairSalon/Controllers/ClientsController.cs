using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;
        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "First_Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index", "Stylists");
        }

        public ActionResult Details(int id)
        {
            Client selectedClient = _db.Clients.Include(client => client.Stylist).FirstOrDefault(client => client.ClientId == id);
            return View(selectedClient);
        }

        public ActionResult Edit(int id)
        {
            Client selectedClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "First_Name");
            return View(selectedClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Clients.Update(client);
            _db.SaveChanges();
            return RedirectToAction("Index", "Stylists");
        }
    }
}