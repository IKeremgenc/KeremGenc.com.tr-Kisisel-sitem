using KeremCvTemplate.Entites.Dtos.EmailDtos;
using KeremCvTemplate.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.service.Abstract
{
    public interface IMailService
    {
        IResult Send(EmailSendDto emailSendDto);
        IResult SendContactEmail(EmailSendDto emailSendDto);
    }
}
