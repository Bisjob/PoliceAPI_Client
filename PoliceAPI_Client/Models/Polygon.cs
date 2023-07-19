using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceAPI_Client.Models
{
    public class Polygon
    {
        public virtual IEnumerable<Coordinate> Coordinates { get; set; }

        public Polygon() { }
        public Polygon(IEnumerable<Coordinate> coordinates) :this()
        { 
            Coordinates = coordinates;
        }

        public override string ToString()
            => string.Join(':', Coordinates.Select(c => string.Format(CultureInfo.InvariantCulture, "{0},{1}", c.Latitude, c.Longitude)));
    }
}
