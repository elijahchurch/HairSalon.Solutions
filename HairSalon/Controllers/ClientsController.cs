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
            Client selectedClient = _db.Clients.Include(client => client.Stylist).FirstOrDefault(Client => Client.ClientId == id);
            return View(selectedClient);
        }
    }
}