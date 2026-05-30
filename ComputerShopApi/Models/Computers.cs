using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopApi.Models
{
    public class Computers
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public double Display { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
