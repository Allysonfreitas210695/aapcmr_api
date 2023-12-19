using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aapcmr.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailDestino, string subject, string body);
    }
}