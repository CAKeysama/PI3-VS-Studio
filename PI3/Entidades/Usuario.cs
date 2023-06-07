using System.ComponentModel.DataAnnotations;

namespace PI3.Entidades
{
    public class Usuario
    {
        
        public int Id { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string SENHA { get; set; }
    }
}
