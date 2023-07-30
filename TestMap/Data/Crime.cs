using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMap.Data
{
    [Serializable]
    public class Coordinates
    {
        /// <summary>  </summary>
        /// 
        public float Latitude { get; set; }

        /// <summary>  </summary>
        public float Longitude { get; set; }

        public Coordinates()
        {

        }

        public Coordinates(float latitude, float longitude)
            : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
    public class Crime
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public Coordinates Coordinates { get; set; }

        public DateTime Date { get; set; }
    }
}
