using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DTOs.CarDTOs
{
    public class CarTestDto
    {
        public int Id { get; set;}
        public int BrandId { get; set; }
        [JsonIgnore]
        public Brand? Brand { get; set; }
        public int ColorId { get; set; }
        [JsonIgnore]
        public Color? Color { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<CarImage>? CarImages { get; set; }
    }
}
