namespace BodegaVinos.DTOs
{
    public class CataCreateDto
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public List<string> GuestList { get; set; } = new List<string>();
        public List<int> WineIds { get; set; } = new List<int>();
    }
}
