using GielinorAdventures.Models.Enumerations;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.Models
{
    public class MapMarker
    {
        public MapMarkerType Type { get; set; }

        public Point2D Location { get; set; }
    }
}
