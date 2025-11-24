namespace ComputerWebAPI.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Display { get; set; }
        public int Memory { get; set; }
        public DateTime CreatedTime { get; set; }
        public int OsId { get; set; }

        public Os Os { get; set; }

    }
}
