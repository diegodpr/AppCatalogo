using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Models
{
    public class Categoria
    {

        
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string ImagemUrl { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        

    }
}
