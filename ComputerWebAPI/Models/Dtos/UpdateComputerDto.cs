namespace ComputerWebAPI.Models.Dtos
{
    public class UpdateComputerDto
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Display { get; set; }
        public int Memory { get; set; }
        public int OsId { get; set; }
    }
}
