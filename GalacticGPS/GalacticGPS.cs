namespace GalacticGPS
{
    using System;

    public static class GalacticGPS
    {
        public static void Main()
        {
            // 37.235, -115.811111, earth #Area 51
            // 51.525888 30.746430 Earth #Chernobyl Nuclear Power Plant

            while (true)
            {
                try
                {
                    Console.WriteLine("Write a coordinates in format Latitude, Longitude, Planet (eg. earth):");
                    string[] userInput = Console.ReadLine()
                        .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (userInput.Length != 3)
                    {
                        throw new ArgumentException("Wrong input, please try again");
                    }

                    var latitude = double.Parse(userInput[0]);
                    var longitude = double.Parse(userInput[1]);
                    var planet = (Planet)Enum.Parse(typeof(Planet), userInput[2], true);

                    var userCoordnates = new Location(latitude, longitude, planet);
                    Console.WriteLine(userCoordnates);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
        }
    }
}
