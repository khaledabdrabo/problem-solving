using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ValidStartingCity
{
    class ValidStartingCitySo1l
    {
        // O(n^2) time | O(1) space - where n is the number of cities
        public int ValidStartingCity(int[] distances, int[] fuel, int mpg)
        {
            int numberOfCities = distances.Length;
            for (int startCityIdx = 0; startCityIdx < numberOfCities; startCityIdx++)
            {
                int milesRemaining = 0;
                for (int currentCityIdx = startCityIdx;
                currentCityIdx < startCityIdx + numberOfCities; currentCityIdx++)
                {
                    if (milesRemaining < 0)
                    {
                        continue;
                    }
                    int currentCityIdxRotated = currentCityIdx % numberOfCities;
                    int fuelFromCurrentCity = fuel[currentCityIdxRotated];
                    int distanceToNextCity = distances[currentCityIdxRotated];
                    milesRemaining += fuelFromCurrentCity * mpg - distanceToNextCity;
                }
                if (milesRemaining >= 0)
                {
                    return startCityIdx;
                }
            }
            // This line should never be reached if the inputs are correct.
            return -1;
        }

    }
}
