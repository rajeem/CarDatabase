using System;

namespace CarDatabase.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public double EngineSizeInCC { get; set; }
        public bool IsElectric { get; set; }
    }
}
