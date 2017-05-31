using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SriSaiVedaGayatri.Models
{
    public class Astrology
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string TimeOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}