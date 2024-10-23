using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Entities
{
    public class Cata
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public List<string> GuestList { get; set; } = new List<string>();

        public ICollection<Wine> Wines { get; set; } = new List<Wine>();
    }
}