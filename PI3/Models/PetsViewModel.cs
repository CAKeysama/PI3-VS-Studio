using PI3.Entidades;

namespace PI3.Models
{
    public class PetsViewModel
    {
        public PetsViewModel() 
        {
            ListaPets = new List<Pets>();
        }
      public List<Pets> ListaPets { get; set; }
      public Usuario Usuario { get; set; }

    }
}
