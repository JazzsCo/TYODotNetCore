using Microsoft.AspNetCore.Mvc;
using TYODotNetCore.MvcAtmApp.Models;

namespace TYODotNetCore.MvcAtmApp.Controllers
{
    public class AtmController : Controller
    {
        private readonly AppDbContext _context = new AppDbContext();

        [ActionName("Index")]
        public IActionResult AtmIndex()
        {
            List<AtmModel> lst = _context.Atms.ToList();

            return View("AtmIndex", lst);
        }

        [ActionName("View")]
        public IActionResult AtmView(int id)
        {
            AtmModel? item = _context.Atms.FirstOrDefault(x => x.AtmId == id);

            if (item is null)
            {
                return Redirect("/Atm");
            }

            return View("AtmView", item);
        }

        [ActionName("Create")]
        public IActionResult AtmCreate()
        {
            return View("AtmCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult AtmCreate(AtmModel atm)
        {
            _context.Atms.Add(atm);
            _context.SaveChanges();

            return Redirect("/Atm");
        }

        [ActionName("Update")]
        public IActionResult AtmUpdate(int id)
        {
            AtmModel? item = _context.Atms.FirstOrDefault(x => x.AtmId == id);

            if (item is null)
            {
                return Redirect("/Atm");
            }

            return View("AtmUpdate", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult AtmUpdate(int id, AtmModel atm)
        {
            AtmModel? item = _context.Atms.FirstOrDefault(x => x.AtmId == id);

            if (item is null)
            {
                return Redirect("/Atm");
            }

            item.UserName = atm.UserName;
            item.Password = atm.Password;
            item.CardNumber = atm.CardNumber;
            item.Balance = atm.Balance;

            _context.SaveChanges();

            return Redirect("/Atm");
        }

        [ActionName("Delete")]
        public IActionResult AtmDelete(int id)
        {
            AtmModel? item = _context.Atms.FirstOrDefault(x => x.AtmId == id);

            if (item is null)
            {
                return Redirect("/Atm");
            }

            _context.Atms.Remove(item);
            _context.SaveChanges();

            return Redirect("/Atm");
        }
    }
}
