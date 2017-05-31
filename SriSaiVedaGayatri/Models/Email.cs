using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SriSaiVedaGayatri.Models
{
    public class Email
    {
        public string fromEmail { get; set; }
        public string toEmail { get; set; }
        public string mailSubject { get; set; }
        public string mailMessage { get; set; }
    }
}