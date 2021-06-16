using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Models
{
    public class Contribuinte
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Required, MaxLength(30)]
        public string Telefone { get; set; }

    }
}
