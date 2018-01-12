using NuciXNA.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.DataObjects
{
    public class ItemLocationEntity : EntityBase
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Amount { get; set; }

        public int RespawnTime { get; set; }
    }
}
