namespace GielinorAdventures.Models
{
    public class WorldTile
    {
        public byte Elevation { get; set; }

        public byte Texture { get; set; }

        public byte OverlayTextureId { get; set; }

        public byte RoofTexture { get; set; }

        public byte HorizontalWallId { get; set; }

        public byte VerticalWallId { get; set; }

        public byte DiagonalWallId { get; set; }
    }
}
