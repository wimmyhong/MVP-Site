using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Mvp.Feature.Forms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvp.Feature.Forms.Services
{
    public class FormService
    {
        private readonly MailboxAddress from = new MailboxAddress("Sitecore MVP website", "no-reply@sitecore.com");
        private readonly MailboxAddress to = new MailboxAddress("Sitecore MVP ", "mvp-program@sitecore.com");
        private IConfiguration Configuration;

        public FormService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void SendLicenseRequest(LicenseRequest licenseRequest)
        {
            var message = new MimeMessage();
            message.Subject = "License request";

            message.Body = new TextPart("html")
            {
                Text = @$"<p>A new license request has been made:<p>

                        <p><span style='font-weight: bold'>Requester details</span></p>
                        <p>Name: {licenseRequest.Name}<br />
                        Company: {licenseRequest.Company}<br />
                        Purpose: {licenseRequest.Purpose}<br />
                        Consent: {licenseRequest.Consent}</p>

                        <p><span style='font-weight: bold'>Products</span></p>
                        <p>Platform: {licenseRequest.IncludePlatform}<br />
                        Avtor: {licenseRequest.IncludeAvtor}<br />
                        Feydra: {licenseRequest.IncludeFeydra}<br />
                        TDS/Razl: {licenseRequest.IncludeTdsRazl}</p>
                        "
            };

            try
            {
                this.SendEmail(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void SendEmail(MimeMessage message)
        {
            message.From.Add(from);
            message.To.Add(to);

            using (var client = new SmtpClient())
            {
                client.Connect(Configuration["Smtp:Host"], Convert.ToInt32(Configuration["Smtp:Port"]), false);
                client.Authenticate(Configuration["Smtp:Username"], Configuration["Smtp:Password"]);
                
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
