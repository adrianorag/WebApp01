using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp01.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        public String UltimoNome { get; set; }
        [Required]
        public int Telefone { get; set; }
        public String Email { get; set; }
    }
}