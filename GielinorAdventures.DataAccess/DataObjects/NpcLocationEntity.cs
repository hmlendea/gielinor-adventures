﻿using NuciXNA.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.DataObjects
{
    public class NpcLocationEntity : EntityBase
    {
        public int InitialX { get; set; }

        public int InitialY { get; set; }

        public int MinX { get; set; }

        public int MinY { get; set; }

        public int MaxX { get; set; }

        public int MaxY { get; set; }
    }
}
