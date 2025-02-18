using LudoKing.Models;
using Microsoft.AspNetCore.Mvc;

namespace LudoKing.Controllers
{
    public class AdminController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("AdminLogin");
            }
            return View();
        }
        public IActionResult index1()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("AdminLogin");
            }
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(string email, string password)
        {
            var data = _context.adminlogin.FirstOrDefault(x => x.email == email && x.password == password);

            if(data != null)
            {
                HttpContext.Session.SetString("user", email);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Email or Password is Incorrect";
                return RedirectToAction("AdminLogin");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin");
        }
        public IActionResult Games()
        {
            var data = _context.game.ToList();
            return View(data);
        }
        public IActionResult DeleteGame(int id)
        {
            var data = _context.game.Find(id);

            _context.game.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Games");
        }
        public IActionResult User()
        {
            var data = _context.registration.ToList();
            return View(data);
        }
        public IActionResult DeleteUser(int id)
        {
            var data = _context.registration.Find(id);

            _context.registration.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("User");
        }
        public IActionResult Wallet()
        {
            var data = _context.wallet.ToList();
            return View(data);
        }
        public IActionResult DeleteWallet(int id)
        {
            var data = _context.wallet.Find(id);

            _context.wallet.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Wallet");
        }
        public IActionResult AdminIncome()
        {
            var data = _context.adminincome.ToList();
            return View(data);
        }
        public IActionResult DeleteAdminIncome(int id)
        {
            var data = _context.adminincome.Find(id);

            _context.adminincome.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("AdminIncome");
        }
        public IActionResult PanaltyIncome()
        {
            var data = _context.panaltyincome.ToList();
            return View(data);
        }
        public IActionResult DeletePanaltyIncome(int id)
        {
            var data = _context.panaltyincome.Find(id);

            _context.panaltyincome.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("PanaltyIncome");
        }
        public IActionResult AppSetting()
        {
            var data = _context.appsetting.ToList();
            return View(data);
        }
        public IActionResult DeleteAppSetting(int id)
        {
            var data = _context.appsetting.Find(id);

            _context.appsetting.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("AppSetting");
        }
        public IActionResult Slider()
        {
            var data = _context.slider.ToList();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddSlider(slider s,IFormFile? pic)
        {
            if(pic != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "slider");
                string filename = pic.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await pic.CopyToAsync(stream);
                s.pic = filename;
            }
            s.datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            s.status = "True";

            _context.slider.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Slider","Admin");
        }
        public IActionResult DeleteSlider(int id)
        {
            var data = _context.slider.Find(id);

            _context.slider.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Slider");
        }
        public IActionResult ContactUs()
        {
            var data = _context.contactus.ToList();
            return View(data);
        }
        public IActionResult DeleteContactUs(int id)
        {
            var data = _context.contactus.Find(id);

            _context.contactus.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("ContactUs");
        }
        public IActionResult Withdraw()
        {
            var data = _context.withdraw.ToList();
            return View(data);
        }
        public IActionResult DeleteWithdraw(int id)
        {
            var data = _context.withdraw.Find(id);

            _context.withdraw.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Withdraw");
        }
        public IActionResult Deposit()
        {
            var data = _context.deposited.ToList();
            return View(data);
        }
        public IActionResult DeleteDeposit(int id)
        {
            var data = _context.deposited.Find(id);

            _context.deposited.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Deposit");
        }
        public IActionResult PaymentHistory()
        {
            var data = _context.paymenthistory.ToList();
            return View(data);
        }
        public IActionResult DeletePaymentHistory(int id)
        {
            var data = _context.paymenthistory.Find(id);

            _context.paymenthistory.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("PaymentHistory");
        }
        public IActionResult GameDetail()
        {
            var data = _context.gamedetail.ToList();
            return View(data);
        }
    }
}
