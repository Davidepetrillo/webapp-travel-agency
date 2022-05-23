namespace TravelAgencyWebApp.Models.Utils
{
    public static class TripData
    {
        private static List<Trip> trips;

        public static List<Trip> GetTrips()
        {
            if (TripData.trips != null)
            {
                return TripData.trips;
            }

            List<Trip> nuovaListaTrips = new List<Trip>();
            for(int i =0; i<9; i++)
            {
                Trip trip = new Trip(i, $"https://picsum.photos/id/{i}/300/200", $"Titolo viaggio {i}", "Lorem ipsum is simply dummy text of the printing and typesetting", "Lunghezza", "Prezzo");
                nuovaListaTrips.Add(trip);
            }

            TripData.trips = nuovaListaTrips;
            return TripData.trips;
        }
    }
}
