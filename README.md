Name Mihret Abebe
DBU 1501367
# Project Name: Emergency Response Simulation
Project Description:
The Emergency Response Simulation project is a console-based application designed to simulate the response of different emergency units (Police, Firefighters, Ambulance, and Search and Rescue) to various incidents such as fire, crime, medical emergencies, earthquakes, and floods. Each emergency unit has a specific type of incident it can handle, and the user must either manually or automatically select a unit to respond to an incident. The simulation tracks the response time and assigns points based on how efficiently the incident is handled, with the goal of maximizing the score.

Features:
Emergency Units: Includes Police, Firefighters, Ambulance, and Search and Rescue units, each specialized in handling different incident types.

Incident Management: The simulation randomly selects incidents with varying difficulty and locations, and the user can select units to respond to them.

Scoring System: Points are awarded based on the unit’s response to incidents. Incorrect unit selection or failure to respond properly results in penalties.

Manual and Automatic Unit Selection: Users can choose to select a unit manually or let the system select the best unit automatically.

Turn-based Gameplay: The simulation runs for 5 turns, with each turn presenting a new incident.

Setup Instructions
Clone the repository or download the code to your local machine.

Open the project in your preferred C# IDE (e.g., Visual Studio, Visual Studio Code).

Build the project:

If using Visual Studio, click on "Build" in the menu.

If using Visual Studio Code, ensure you have the .NET SDK installed and run dotnet build from the terminal.

Run the program:

In Visual Studio, click on "Start" or press F5 to run the program.

In Visual Studio Code, run the command dotnet run from the terminal.

OOP Concepts Applied
Abstraction:

The abstract class EmergencyUnit is used to define the core properties and methods that all emergency units share. It defines the general structure for handling incidents, while allowing each unit type to implement its own specific behavior.

Encapsulation:

Each class encapsulates its relevant data and functionality. For instance, the EmergencyUnit class encapsulates the Name and Speed properties, along with the logic for responding to incidents.

Inheritance:

The Police, Firefighter, Ambulance, and SearchAndRescue classes all inherit from EmergencyUnit. This allows these classes to reuse the core logic from the base class while providing their own specific implementation for handling incidents.

Polymorphism:

The CanHandle and RespondToIncident methods are overridden in each subclass, allowing different types of emergency units to implement these methods differently based on their capabilities.

Class Diagram
Below is a text-based representation of the class structure:

pgsql
Copy
Edit
                +-----------------+
                |  EmergencyUnit  |  <---- Abstract class
                +-----------------+
                | - Name          |
                | - Speed         |
                +-----------------+
                | + CanHandle()   |
                | + RespondToIncident() |
                +-----------------+
                        ^
                        |
        --------------------------------------------
       |                   |                   |                |
+-----------+      +--------------+      +----------+     +----------------+
|  Police   |      |  Firefighter |      | Ambulance|     | SearchAndRescue |
+-----------+      +--------------+      +----------+     +----------------+
| + CanHandle()|    | + CanHandle()|    | + CanHandle()|  | + CanHandle()    |
| + RespondToIncident()| | RespondToIncident() | | RespondToIncident() | | RespondToIncident() |
+-----------+      +--------------+      +----------+     +----------------+
Game Flow
Start Simulation: The program starts by initializing a list of emergency units (Police, Firefighter, Ambulance, and Search and Rescue).

Select Incident Type: The user is prompted to choose an incident type (Fire, Crime, Medical, Earthquake, or Flood).

Random Location and Difficulty: A random location and difficulty level (1-5) are chosen for the incident.

Unit Selection: The user can choose to select a unit manually or let the system automatically choose the appropriate unit based on the incident type.

Incident Response: The selected unit responds to the incident, and the system calculates the response time based on the unit's speed and the incident's difficulty. Points are awarded or deducted depending on whether the unit can handle the incident.

Repeat: The simulation proceeds for a total of 5 turns, each with a new incident.

End Simulation: The game ends after 5 turns, and the final score is displayed.

emergency---response---simulator
