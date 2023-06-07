using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PI3.Entidades
{
    public class Pets
    {
       
        public int Id { get; set; }
        public string NOME { get; set; }
        public string RACA { get; set; }
        public decimal PESO { get; set; }
        public DateTime DATANASCIMENTO { get; set; }
        public string DESCRICAO { get; set; }
        public string CaminhoImagem { get; set; }
        public int UsuarioId { get; set; }
        public Usuario USUARIO { get; set; }
    }
}
