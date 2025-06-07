using MimeKit;
using MS.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Controllers;

public class MailController : Controller
{
    [HttpGet]
    public IActionResult SendMail()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendMail(MailRequestViewModel requestvm)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop Katalog", "fatmazehraseren@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", requestvm.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = requestvm.MailContent;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = requestvm.Subject;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Connect("smtp.gmail.com", 587, false);
        smtpClient.Authenticate("fatmazehraseren@gmail.com", "lrarucaygulndcnf");
        smtpClient.Send(mimeMessage);
        smtpClient.Disconnect(true);
        return View();
    }
}
