using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Session.Models;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginusingsessionContext _context;

        public HomeController(LoginusingsessionContext context)
        {
            this._context = context;         
        }

        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserEmail") != null)
            {
                return RedirectToAction("DashBoard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserTbl user)
        {
            var myuser = _context.UserTbls.Where(x => x.UserEmail == user.UserEmail && x.UserPassword == user.UserPassword).FirstOrDefault();
            if(myuser != null)
            {
                HttpContext.Session.SetString("UserEmail", myuser.UserEmail);
                return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.error = "Login Failed............";
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserTbl user)
        {
            if (ModelState.IsValid)
            {
                _context.UserTbls.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
            
        }


        public IActionResult LogOut()
        {
            if(HttpContext.Session.GetString("UserEmail") != null)
            {
                HttpContext.Session.Remove("UserEmail");
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                ViewBag.session = HttpContext.Session.GetString("UserEmail").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }



        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult AboutUs()
        {
       
           
            return View();
        }
       

        
    }
}
