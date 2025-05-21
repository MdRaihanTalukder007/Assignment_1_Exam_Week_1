using Assignment_1_Exam_Week_1.Data;
using Assignment_1_Exam_Week_1.Data.Entities;
using Assignment_1_Exam_Week_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1_Exam_Week_1.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService mailService;
        public RegistrationController(AppDbContext context, IEmailService mailService)
        {
            _context = context;
            this.mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Completed()
        {
            ViewBag.Message = "User Registered Successfully & Email Sended.";
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserDetail user)
        {
            if (ModelState.IsValid)
            {
                if (!user.Password.Equals(user.ConfirmPassword))
                {
                    ViewBag.ErrorMessage = "User Password and Confirm Password Not Matched!";
                    return View();
                }

                try
                {
                    // Save the user to the database
                    _context.UserDetails.Add(user);
                    _context.SaveChanges();

                    var emailSended = mailService.SendEmailAsync(user.Email, "Registration Compeleted", "Registration Compeleted");
                    return RedirectToAction("Completed");
                }
                catch (Exception ex) {
                    ViewBag.ErrorMessage = "Something Went Wrong! Please, Try Again Later.";
                    return View();
                }
            }
            return View();
        }
    }
}
