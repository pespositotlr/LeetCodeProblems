using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems
{
    public class UndergroundSystem
    {
        List<CustomerTrip> CheckinCheckoutSchedule;

        public UndergroundSystem()
        {
            CheckinCheckoutSchedule = new List<CustomerTrip>();
        }

        private class CustomerTrip
        {
            public int CustomerId;
            public string CheckInStation;
            public string CheckOutStation;
            public int CheckInTime;
            public int? CheckOutTime;
        }

        /*
         A customer with id card equal to id, gets in the station stationName at time t.
         A customer can only be checked into one place at a time.
         */
        public void CheckIn(int id, string stationName, int t)
        {
            //if (IsInvalidID(id) || IsInvalidTime(t) || IsInvalidStationName(stationName))
            //    return;

            CustomerTrip trip = new CustomerTrip();
            trip.CheckInStation = stationName;
            trip.CustomerId = id;
            trip.CheckInTime = t;

            CheckinCheckoutSchedule.Add(trip);
        }

        // A customer with id card equal to id, gets out from the station stationName at time t.
        public void CheckOut(int id, string stationName, int t)
        {
            //if (IsInvalidID(id) || IsInvalidTime(t) || IsInvalidStationName(stationName))
            //    return;

            //Check if this is a possible place to check out
            if (!CheckinCheckoutSchedule.Any(x => x.CustomerId == id))
                return;

            var tripToCheckOut = CheckinCheckoutSchedule.FirstOrDefault(x => x.CustomerId == id && !x.CheckOutTime.HasValue);
            tripToCheckOut.CheckOutStation = stationName;
            tripToCheckOut.CheckOutTime = t;
        }

        /* 
         *  Returns the average time to travel between the startStation and the endStation.
         *  The average time is computed from all the previous traveling from startStation to endStation that happened directly.
         *  Call to getAverageTime is always valid.   
         */
        public double GetAverageTime(string startStation, string endStation)
        {
            var tripsToTheseStations = CheckinCheckoutSchedule.Where(x => x.CheckInStation == startStation && x.CheckOutStation == endStation).ToList();

            return tripsToTheseStations.Average(x => (int)x.CheckOutTime - x.CheckInTime);
        }

        private bool IsInvalidID(int id)
        {
            var result = (id < 1) ? true : false;
            return result;
        }
        private bool IsInvalidTime(int t)
        {
            var result = (t > 1000000) ? true : false;
            return result;
        }
        private bool IsInvalidStationName(string stationName)
        {
            var result = (stationName.Length < 1 || stationName.Length > 10) ? true : false;
            return result;
        }
    }
}
