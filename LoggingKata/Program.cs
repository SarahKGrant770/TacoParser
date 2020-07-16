using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Globalization;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            //below holds our variables
            ITrackable locA = null;
            ITrackable locB = null;
            ITrackable p1 = null;
            ITrackable p2 = null;

            // Create a `double` variable to store the distance
            double distance = 0;
            double maxDistance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            //locA = locations[i];
            for (int i = 0; i < locations.Length; i++ )
            {
                locA = locations[i];
                    GeoCoordinate CordA = new GeoCoordinate();
                    CordA.Latitude = locA.Location.Latitude;
                    CordA.Longitude = locA.Location.Longitude;
                    for (int j = i; j < locations.Length; j++)
                    {
                        locB = locations[j];
                        GeoCoordinate CordB = new GeoCoordinate();
                        CordB.Latitude = locB.Location.Latitude;
                        CordB.Longitude = locB.Location.Longitude;
                        distance = CordA.GetDistanceTo(CordB);
                        if (distance > maxDistance)
                        {
                         p1 = locA;
                         p2 = locB;
                         maxDistance = distance;
                        }
                    }
                
            }
            logger.LogInfo("Determinig greatest distance!");

            double inMiles = 0.000621371 * maxDistance;
            logger.LogInfo("Converting answer to miles....");

            Console.WriteLine($"{p1.Name} + is + {Math.Floor(inMiles)} +  miles from  + {p2.Name}");



            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



            // Create a `double` variable to store the distance





        }
    }
}
