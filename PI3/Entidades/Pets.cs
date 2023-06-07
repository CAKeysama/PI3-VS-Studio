using System.ComponentModel.DataAnnotations;

namespace PI3.Entidades
{
    public class Pets
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string RACA { get; set; }
        public string PESO { get; set; }
        public DateTime DATANASCIMENTO { get; set; }
        public string DESCRICAO { get; set; }
        public int IDUSUARIO { get; set; }
        public Usuario USUARIO { get; set; }
    }
}
