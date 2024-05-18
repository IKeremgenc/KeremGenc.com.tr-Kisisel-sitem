using KeremCvTemplate.Entites.Concrete;
using KeremCvTemplate.Entites.Dtos.EmailDtos;
using Microsoft.Extensions.Options;
using KeremCvTemplate.service.Abstract;
using KeremCvTemplate.Shared.Utilities.Results.Abstract;
using KeremCvTemplate.Shared.Utilities.Results.ComplexTypes;
using KeremCvTemplate.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.service.Concrete
{
    public class MailManager : IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress(emailSendDto.Email) },
          

                IsBodyHtml = true,
                Body = emailSendDto.Message
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new Result(ResultStatus.Success, $"E-Postanız başarıyla gönderilmiştir.");
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            // Anlık zamanı almak için DateTime.Now kullanılıyor
            DateTime currentDateTime = DateTime.Now;

            string emailBody = $"Gönderen Kişi: {emailSendDto.Name},<br/>" +
                               $"Gönderen E-Posta Adresi: {emailSendDto.Email},<br/>" +
                               $"Konu: {emailSendDto.Phone},<br/>" +
                               $"Tarih: {currentDateTime.ToString("dd/MM/yyyy HH:mm")},<br/>" +  // Tarih ve saat
                               $"{emailSendDto.Message}";

            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress("ismailkeremgenc@gmail.com") },
                Subject = "KeremGenc.Com.tr",
                IsBodyHtml = true,
                Body = emailBody
            };

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new Result(ResultStatus.Success, "E-Postanız başarıyla gönderilmiştir.");
        }

    }
}
