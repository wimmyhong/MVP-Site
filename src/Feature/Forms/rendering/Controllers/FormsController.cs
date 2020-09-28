using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Mvp.Feature.Forms.Models;
using Mvp.Feature.Forms.Services;
using System;

namespace Mvp.Feature.Forms.Controllers
{
    [Produces("application/json")]
    public class FormsController : Controller
    {
        private FormService FormService { get; set; }
        private readonly IWebHostEnvironment hostingEnvironment;
        private IConfiguration Configuration;

        public FormsController(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.hostingEnvironment = hostingEnvironment;
            Configuration = configuration;

            this.FormService = new FormService(configuration);

        }

        [HttpPost]
        public IActionResult RequestLicense(LicenseRequest licenseRequest)
        {
            try
            {
                FormService.SendLicenseRequest(licenseRequest);
            }
            catch {
                return StatusCode(500);
            }

            return Ok(new { message = "License request succesfully submitted" });
        }

    }
}