using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        // Modificador 'virtual' permite o lazy loading da propriedade
        // JsonIgnore faz com que não apareça essa propriedade no objeto json criado
        // isso evita que um loop infinito ocorra ao chamar um endereço que possui um cinema que possui um endereço que...
        // É preciso manter essa propriedade para que exista a relação entre chaves em AppDbContext, método 'OnModelCreating'
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
