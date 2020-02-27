using System;
using System.Linq;

namespace PartyThyme
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PlantContext();
            var newPlant = new Plant();
            var isRunning = true;

            while (isRunning)
            {
            Console.Clear();
            Console.WriteLine("         It's PARTY THYME!");
            Console.WriteLine("***************************************");
            Console.WriteLine("     What would you like to do?");
            Console.WriteLine("----------------------------------------"); 
            Console.WriteLine("(VIEW), (PLANT), (REMOVE), or (WATER)?");
            Console.WriteLine("     Or would you like to (QUIT)?");
            Console.WriteLine("***************************************");
            var main = Console.ReadLine().ToUpper();
            if (main != "VIEW" && main != "PLANT" && main != "REMOVE" && main != "WATER")
            {
            }
            if (main == "VIEW")
            {
                Console.Clear();
                Console.WriteLine("**************************************************");
                Console.WriteLine("What would you like to view?");
                Console.WriteLine("--------------------------------------------------"); 
                Console.WriteLine("(ALL) plants, plant (LOCATION), or (NOT) watered?");
                Console.WriteLine("**************************************************");
                var view = Console.ReadLine().ToUpper();
                // view all plants
                if (view == "ALL")
                {
                    var allPlants = db.Plants.OrderBy(plant => plant.LocatedPlanted);
                    Console.WriteLine("\n***************************************");
                    foreach (var plant in allPlants)
                    {
                        Console.WriteLine($"({plant.Id}): {plant.Species} is located in {plant.LocatedPlanted}.");
                    }
                    Console.WriteLine("***************************************");
                    Console.WriteLine("\n\nPress Enter to return to the main menu.");
                    view = Console.ReadLine();
                }
                // view plants by location summary
                else if (view == "LOCATION")
                {
                    Console.WriteLine("\n***************************************");
                    foreach (var plant in db.Plants.Distinct())
                    {
                        Console.WriteLine($"{plant.LocatedPlanted}");
                    }
                    Console.WriteLine("\n***************************************");
                    Console.WriteLine("What location would you like to view?");
                    var userLocation = Console.ReadLine();
                    var summary = db.Plants.Any(plant => plant.LocatedPlanted == userLocation);
                    while (!summary)
                    {
                        Console.WriteLine("Location is not found. Try again.");
                        userLocation = Console.ReadLine();
                        summary = db.Plants.Any(plant => plant.LocatedPlanted == userLocation);
                    }
                    Console.WriteLine("\n***************************************");
                    var location = db.Plants.Where(plant => plant.LocatedPlanted == userLocation);
                    foreach (var plant in location)
                    {
                        Console.Write($"{plant.Species} is in {plant.LocatedPlanted}.\n");
                    }
                    Console.WriteLine("***************************************");
                    Console.WriteLine("\nPress Enter to return to the main menu");
                    view = Console.ReadLine();
                    summary = false;
                }
                // view plants by plants that haven't been watered today
                else if (view == "NOT")
                {
                    Console.WriteLine("Here are the plants that have no been watered:");
                    Console.Clear();
                    Console.WriteLine("These are the plants that have not been watered today:");
                    var viewWatered = db.Plants.Where(plant => plant.LastWateredDate < DateTime.Today);
                    foreach (var plant in viewWatered)
                    {
                        Console.WriteLine($"{plant.Species} was watered on {plant.LastWateredDate}.");
                    }
                    Console.WriteLine("Press Enter to return to the main menu");
                    view = Console.ReadLine();
                }
            }
            // add plants to the database
            else if (main == "PLANT")
            {
                Console.WriteLine("\n***************************************");
                Console.WriteLine($"What kind of species is it?");
                newPlant.Species = Console.ReadLine();
                Console.WriteLine($"Where was {newPlant.Species} planted?");
                newPlant.LocatedPlanted = Console.ReadLine();
                Console.WriteLine($"How many hours of light does the {newPlant.Species} need a day?");
                newPlant.LightNeeded = double.Parse(Console.ReadLine());
                Console.WriteLine($"How much water does the {newPlant.Species} need?");
                newPlant.WaterNeeded = Console.ReadLine();
                newPlant.LastWateredDate = DateTime.Now;
                newPlant.PlantedDate = DateTime.Now;

                db.Plants.Add(newPlant);
                db.SaveChanges();
            }
            // remove plants from database by id
            else if (main == "REMOVE")
            {
                // displays plants by id, name, and location
                var allPlants = db.Plants.OrderBy(plant => plant.LocatedPlanted);
                Console.WriteLine("\n***************************************");
                    foreach (var plant in allPlants)
                    {
                        Console.WriteLine($"{plant.Species} is located in {plant.LocatedPlanted} ({plant.Id}).");
                    }
                Console.WriteLine("***************************************");
                Console.WriteLine("Please enter the ID # of the plant you'd like to remove?");
                var remove = int.Parse(Console.ReadLine());
                var plantToRemove = db.Plants.FirstOrDefault(plant => plant.Id == remove);
                if (plantToRemove != null)
                {
                    db.Plants.Remove(plantToRemove);
                    db.SaveChanges();
                }
            }
            // choose what plants need to be watered
            else if (main == "WATER")
            {
                Console.Clear();
                var allWatered = db.Plants.OrderBy(plant => plant.LastWateredDate);
                foreach (var watered in allWatered)
                {
                    Console.WriteLine($"ID:({watered.Id}) {watered.Species} was last watered on {watered.LastWateredDate}");
                }
                Console.WriteLine("Please choose the ID number of the plant you'd like to water.");
                var userInput = int.Parse(Console.ReadLine());
                var plantToWater = db.Plants.FirstOrDefault(plant => plant.Id == userInput);
                if (plantToWater == null)
                {
                    Console.WriteLine("That is not a valid ID. Please choose a valid ID number.");
                    userInput = int.Parse(Console.ReadLine());
                }
                if (plantToWater != null)
                {
                    plantToWater.LastWateredDate = DateTime.Now;
                    db.SaveChanges();
                }
            }
            if (main == "QUIT")
            {
                isRunning = false;
            }
            }
        }
    }
}
