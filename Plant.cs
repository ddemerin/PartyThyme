using System;

namespace PartyThyme
{
    public class Plant
    {
        //  Id - primary key
        public int Id { get; set; }
        // Species - The type of plant
        public string Species { get; set; }
        // LocatedPlanted - where is the plant plated
        public string LocatedPlanted { get; set; }
        // PlantedDate - When was the plant planted
        public DateTime PlantedDate { get; set; }
        // LastWateredDate - When was the last time a plant was water
        public DateTime LastWateredDate { get; set; }
        // LightNeeded - How much sunlight is needed
        public double LightNeeded { get; set; }
        // WaterNeeded - how much water is needed
        public string WaterNeeded { get; set; }
    }
}