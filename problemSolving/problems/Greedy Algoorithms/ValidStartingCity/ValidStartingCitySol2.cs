using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ValidStartingCity
{
    class ValidStartingCitySol2
    {
        // O(n) time | O(1) space - where n is the number of cities
        public int ValidStartingCity(int[] distances, int[] fuel, int mpg)
        {
            int numberOfCities = distances.Length;
            int milesRemaining = 0;
            int indexOfStartingCityCandidate = 0;
            int milesRemainingAtStartingCityCandidate = 0;
            for (int cityIdx = 1; cityIdx < numberOfCities; cityIdx++)
            {
                int distanceFromPreviousCity = distances[cityIdx - 1];
                int fuelFromPreviousCity = fuel[cityIdx - 1];
                milesRemaining += fuelFromPreviousCity * mpg - distanceFromPreviousCity;
                if (milesRemaining < milesRemainingAtStartingCityCandidate)
                {
                    milesRemainingAtStartingCityCandidate = milesRemaining;
                    indexOfStartingCityCandidate = cityIdx;
                }
            }
            return indexOfStartingCityCandidate;
        }
    }
}
