using NuciXNA.Primitives;

using GielinorAdventures.Models.Enumerations;

namespace GielinorAdventures.Models
{
    public class GameObjectLocation
    {
        public Point2D Location { get; set; }

        public int Direction { get; set; }

        public GameObjectType Type { get; set; }
    }
}
