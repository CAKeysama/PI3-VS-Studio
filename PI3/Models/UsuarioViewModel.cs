using System.ComponentModel.DataAnnotations;

namespace PI3.Models
{
    public class UsuarioViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [MinLength(3, ErrorMessage = "O mínimo de caracteres requerido é 3")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(14, ErrorMessage = "O mínimo de caracteres requerido é 14")]
        public string TELEFONE { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(8, ErrorMessage = "O mínimo de caracteres requerido é 8")]
        public string SENHA { get; set; }
    }
}
