using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using smtp.checker.webapp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace smtp.checker.webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.log = _context.SendEmailLogs.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Send(EmailConfiguration configuration)
        {
            var result = new ResultSendEMail
            {
                Status = true,
                StatusMessage="Configuration OK."
            };
            using (var client = new SmtpClient(configuration.Host, configuration.Port))
            {
                try
                {
                    var mail = new MailMessage(configuration.EmailFrom, configuration.EmailTo, "Test SMTP", $"<p>SMTP <b>{configuration.Host}</b> with port <b>{configuration.Port}</b> is OK.</p>");
                    mail.IsBodyHtml = configuration.IsBodyHtml;


                    client.Credentials = new NetworkCredential(configuration.UserName, configuration.Password);
                    client.EnableSsl = configuration.EnableSsl;
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    result.Status = false;  
                    result.StatusMessage = ex.Message;
                }
                finally
                {
                    client.Dispose();
                }

                _context.SendEmailLogs.Add(new SendEmailLog
                {
                    EmailFrom = configuration.EmailFrom,
                    EmailTo = configuration.EmailTo,
                    EnableSsl = configuration.EnableSsl,
                    Host = configuration.Host,
                    IsBodyHtml = configuration.IsBodyHtml,
                    Password = configuration.Password,
                    Port = configuration.Port,
                    Status = result.Status,
                    StatusMessage = result.StatusMessage 
                });
                _context.SaveChanges();
                return View(result);
            }
        }
    }
}
