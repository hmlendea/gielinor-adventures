using NuciXNA.Primitives;

using GielinorAdventures.Models.Enumerations;

namespace GielinorAdventures.Models
{
    public class MapMarker
    {
        public MapMarkerType Type { get; set; }

        public Point2D Location { get; set; }
    }
}
