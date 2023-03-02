using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppMail.Models;
using WebAppMail.Repository;
using WebAppMail.Services;

namespace WebAppMail.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class MailsController : Controller
    {
        private IMailRepository<Mail> RepositoryMail { get; set; }
        private IMailService MailService { get; set; }
        private readonly ILogger<MailsController> _logger;
        public MailsController(ILogger<MailsController> logger, IMailRepository<Mail> repositoryMail, IMailService mailService)
        {
            _logger = logger;
            RepositoryMail = repositoryMail;
            MailService = mailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mail>> Index()
        {
            return View(RepositoryMail.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Mail>> Index(int id)
        {
            var mails = RepositoryMail.Get(id);
            //return Ok(mails);
            return View(mails);
        }
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Mail>> Send(Letter letter)
        {
            try
            {
                var mail = await MailService.SendEmailAsync(letter);
                RepositoryMail.Create(mail);
                Ok(mail);
                return RedirectToAction("Index");
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.ToProblemDetails());
            //}
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public IActionResult Cancel()
        {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
