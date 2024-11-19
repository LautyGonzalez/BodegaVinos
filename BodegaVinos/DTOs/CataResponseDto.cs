namespace BodegaVinos.DTOs
{
    public class CataResponseDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public List<string> GuestList { get; set; } = new List<string>();
        public List<WineResponseDto> Wines { get; set; } = new List<WineResponseDto>();
    }
}
