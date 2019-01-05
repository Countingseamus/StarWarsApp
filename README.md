# StarWarsApp Description
A Specific Program that runs Starship calculations based on user input and data from Star Wars API. 
Informs User, given their specified input distance, how many resupply stops are required for each Starship

# Requirements
- A console Application
- The application will take string input from user. Input should represent a distance in mega lights (MGLT).
- User wants to know for all SW star ships , to cover a given distance, how many stops for resupply are required.
- The output should be a collection of all the star ships and the total amount of stops required to make the distance between the planets.
- Documentation, Tests and Instructions on application.

# API
Base url: https://swapi.co/
Endpoint to retrieve all starships: starships
Absolute url: https://swapi.co/starships

# Planning
Needed:
1. Knowledge of data schema
2. Means for user to enter input and see output.
3. IDE for development and desired programming language.
4. Knowledge of calculation inputs and logic.

Decided:
1. Consulted API documentation here https://swapi.co/documentation#starships
2. Console Application provided means for user to enter input and see output.
3. Visual Studio 2017 and C# deemed appropriate given basic requirements.
4. Inputs should be Distance to be travelled (input by user), time ship can travel without stopping for resupply (in Starship Consumables) 
in days (common denominator), and speed of ship (MGLT). 
First step was to work out how many days each ship can travel without stopping for resupply. See parserUtility.ParseNumberOfDays()
Second step was to figure out how long it would take ship to travel the inputted distance without needing to stop. See starshipLogisticsCalculator.CalculateETAWithoutResupply()
Third and final step was to divide result of second step (journeyTimeWithoutStops) by result of first step (daysBeforeResupply). If 
result of first step was 0 then assumed no stops needed as there was renewable resources on ship. See starshipLogisticsCalculator.CalculateNumberOfStops()

# Design & Implementation
Clean code and SOLID principles are important to me and hope that my implementation reflects that.
I especially focused on the SRP which lead to the code being a little longer than it needed to be for this basic application 
but at the same time I think this principle is extremely important so is always worth it in the long run.
This allows for code to be extensible, maintainnable and allows for segments to be re-usable.
Where possible I also followed a Test Driven Approach to ensure I got a working application.
I commented my code to give reviewer an idea of how it worked and also why it was done.

Divided the Application into:
1. Program Runner - LogisticsProgram.cs
Decided that a LogisticsProgram class should be responsible for activation and termination of application. 
It would also read in user input and set up HTTP client needed to make API request (admit this can be done better).

2. Controllers - StarshipApiController.cs
The StarshipApiController class was then in charge of getting the Starships from the API. 

i. First it needed to obtain the call to starships and deserialize the result (GetStarshipsApiResult()). 
This method would handle any errors from this call, potentially the service being down or serialization error.

ii. Then it provided a call to get starships from this result (GetStarships()).

3. Models - StarshipsApiResult.cs, Starship.cs
Data Transfer Objects that provide the mapping for JSON data returned from API call. 
Consultation of Star Wars API documentation allowed me to create these with correct properties and types.
No business logic was to be used within these so that they could be fully re-usable.

4. Utilities - ParserValidationUtility.cs, StarshipLogisticsCalculator.cs
i. I decided to create a class, ParserValidationUtility, for handling all Pasring needed and validation for this. It would
- Parse and Validate User Input IsUserInputValid(). Assumed that user should enter a postive whole number and deemed that integer 
would allow big enough values for this purpose.
- Validate Starship Consumables first to see if they contained valid number (not negative and numeric) and time period (day/week/month/year). 
Asummed that there was always going to be only 1 number and time period present. Need to modify this if that changes. See IsConsumablesValid()
- Parse and to work out how many days each ship can travel without stopping for resupply. See ParseNumberOfDays()
- Validate Speed of Starship (positive and numeric). See IsSpeedValid()

ii. Decided to create StarshipLogisticsCalculator class to handle all calculation logic. See step 4 under "Decided"

5. Unit Tests
Unit tested the Controllers and Utilities that contained the logic.
Did not unit test Models as there is no logic to test or the LogisticsProgram as it required user input and private methods.
Used MSTest and Moq.

Notes:
Avoided static methods as I prefer to follow a OOP approach and even do static methods would be fine for this basic program I decided against them for better practice.

Improvements:
HTTPClient could be implemented better for greater abstraction or at least unit testability.
Dependency Injection & abstraction to avoid newing up so many objects and provide greater flexibility in future and testability.

