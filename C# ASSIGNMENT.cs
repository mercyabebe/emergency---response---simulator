using System;
using System.Collections.Generic;

namespace EmergencyResponseSimulation
{
    // Abstract class EmergencyUnit
    abstract class EmergencyUnit
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public EmergencyUnit(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public abstract bool CanHandle(string incidentType);
        public abstract void RespondToIncident(Incident incident, int difficulty);
    }

    // Police class
    class Police : EmergencyUnit
    {
        public Police(string name, int speed) : base(name, speed) { }

        public override bool CanHandle(string incidentType)
        {
            return incidentType == "Crime";
        }

        public override void RespondToIncident(Incident incident, int difficulty)
        {
            Console.WriteLine($"{Name} is handling crime at {incident.Location}.");
            int responseTime = difficulty * 2 / Speed; // Speed affects response time
            Console.WriteLine($"Response time: {responseTime} minutes.");
        }
    }

    // Firefighter class
    class Firefighter : EmergencyUnit
    {
        public Firefighter(string name, int speed) : base(name, speed) { }

        public override bool CanHandle(string incidentType)
        {
            return incidentType == "Fire";
        }

        public override void RespondToIncident(Incident incident, int difficulty)
        {
            Console.WriteLine($"{Name} is extinguishing fire at {incident.Location}.");
            int responseTime = difficulty * 2 / Speed; // Speed affects response time
            Console.WriteLine($"Response time: {responseTime} minutes.");
        }
    }

    // Ambulance class
    class Ambulance : EmergencyUnit
    {
        public Ambulance(string name, int speed) : base(name, speed) { }

        public override bool CanHandle(string incidentType)
        {
            return incidentType == "Medical";
        }

        public override void RespondToIncident(Incident incident, int difficulty)
        {
            Console.WriteLine($"{Name} is treating patients at {incident.Location}.");
            int responseTime = difficulty * 2 / Speed; // Speed affects response time
            Console.WriteLine($"Response time: {responseTime} minutes.");
        }
    }

    // Search and Rescue class (New)
    class SearchAndRescue : EmergencyUnit
    {
        public SearchAndRescue(string name, int speed) : base(name, speed) { }

        public override bool CanHandle(string incidentType)
        {
            return incidentType == "Earthquake" || incidentType == "Flood";
        }

        public override void RespondToIncident(Incident incident, int difficulty)
        {
            Console.WriteLine($"{Name} is rescuing people at {incident.Location}.");
            int responseTime = difficulty * 2 / Speed; // Speed affects response time
            Console.WriteLine($"Response time: {responseTime} minutes.");
        }
    }

    // Incident class
    class Incident
    {
        public string Type { get; set; }
        public string Location { get; set; }
        public int Difficulty { get; set; } // Difficulty of handling the incident

        public Incident(string type, string location, int difficulty)
        {
            Type = type;
            Location = location;
            Difficulty = difficulty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize emergency units
            List<EmergencyUnit> units = new List<EmergencyUnit>
            {
                new Police("Police Unit 1", 100),
                new Firefighter("Firefighter Unit 1", 80),
                new Ambulance("Ambulance Unit 1", 90),
                new SearchAndRescue("Rescue Unit 1", 70) // New unit
            };

            // Possible incident types and locations
            string[] incidentTypes = { "Fire", "Crime", "Medical", "Earthquake", "Flood" };
            string[] locations = { "City Hall", "Downtown", "Mall", "Park", "School" };

            Random random = new Random();
            int score = 0;

            for (int turn = 1; turn <= 5; turn++)
            {
                Console.WriteLine($"\n--- Turn {turn} ---");

                // Ask the user for the incident type (instead of random selection)
                Console.WriteLine("Select an incident type:");
                for (int i = 0; i < incidentTypes.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {incidentTypes[i]}");
                }

                int incidentTypeChoice = int.Parse(Console.ReadLine()) - 1;
                if (incidentTypeChoice < 0 || incidentTypeChoice >= incidentTypes.Length)
                {
                    Console.WriteLine("Invalid incident type selected.");
                    continue;
                }

                string selectedIncidentType = incidentTypes[incidentTypeChoice];

                // Select a random location and difficulty
                string randomLocation = locations[random.Next(locations.Length)];
                int randomDifficulty = random.Next(1, 6); // Difficulty from 1 to 5

                Incident newIncident = new Incident(selectedIncidentType, randomLocation, randomDifficulty);

                Console.WriteLine($"Incident: {newIncident.Type} at {newIncident.Location} (Difficulty {newIncident.Difficulty})");

                // Show available units
                Console.WriteLine("\nAvailable units:");
                for (int i = 0; i < units.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {units[i].Name}");
                }

                // Ask user whether they want to manually select a unit or use automatic selection
                Console.WriteLine("\nDo you want to (M)anually select a unit or (A)utomatically select one? (M/A)");
                string selectionChoice = Console.ReadLine().ToUpper();

                EmergencyUnit selectedUnit = null;

                if (selectionChoice == "M")
                {
                    // Manual selection
                    Console.WriteLine("\nSelect a unit by number:");
                    int selectedUnitIndex = int.Parse(Console.ReadLine()) - 1;

                    if (selectedUnitIndex >= 0 && selectedUnitIndex < units.Count)
                    {
                        selectedUnit = units[selectedUnitIndex];
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                        continue;
                    }
                }
                else if (selectionChoice == "A")
                {
                    // Automatic selection: find the first available unit
                    selectedUnit = units.Find(unit => unit.CanHandle(newIncident.Type));
                    if (selectedUnit == null)
                    {
                        Console.WriteLine("No unit available to handle this incident.");
                        score -= 5;
                        Console.WriteLine("-5 points");
                        Console.WriteLine($"Current Score: {score}");
                        continue;
                    }
                    Console.WriteLine($"Automatically selected: {selectedUnit.Name}");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter M or A.");
                    continue;
                }

                // Respond to the incident
                if (selectedUnit.CanHandle(newIncident.Type))
                {
                    selectedUnit.RespondToIncident(newIncident, newIncident.Difficulty);
                    int points = 10 * newIncident.Difficulty;
                    score += points;
                    Console.WriteLine($"+{points} points");
                }
                else
                {
                    Console.WriteLine("Selected unit cannot handle this incident.");
                    score -= 5;
                    Console.WriteLine("-5 points");
                }

                Console.WriteLine($"Current Score: {score}");
            }

            Console.WriteLine($"\nSimulation ended. Final Score: {score}");
        }
    }
}








