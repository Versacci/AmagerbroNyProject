using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NyAmagerbroProj.Models
{
    public class AmagerbroClothesStore
    {
        //Model for Amagerbro clothes

        [Key]
        public int ID { get; set; }

        [Required]
        public string Navn { get; set; }

        [Required]
        public string Addresse { get; set; }

        [Required]
        public string Åbningstider { get; set; }

        [Required]
        public string telefon { get; set; }
    }
}