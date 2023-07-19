namespace PoliceAPI_Client.Models
{
    public class Coordinate
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Coordinate() { }
        public Coordinate(float latitude, float longitude) :this()
        {  
            Latitude = latitude; 
            Longitude = longitude;
        }
    }
}
