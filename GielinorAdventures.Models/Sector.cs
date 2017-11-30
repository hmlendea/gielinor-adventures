using GielinorAdventures.Primitives;

namespace GielinorAdventures.Models
{
    public class Sector
    {
        public static readonly Size2D Size = new Size2D(48, 48);

        WorldTile[] tiles;

        public Sector()
        {
            tiles = new WorldTile[Size.Width * Size.Height];

            for (int i = 0; i < Size.Area; i++)
            {
                tiles[i] = new WorldTile();
            }
        }

        public void SetTile(int x, int y, WorldTile tile)
        {
            SetTile(x * Size.Width + y, tile);
        }

        public void SetTile(int index, WorldTile tile)
        {
            tiles[index] = tile;
        }

        public WorldTile GetTile(int x, int y)
        {
            return GetTile(x * Size.Width + y);
        }

        public WorldTile GetTile(int index)
        {
            return tiles[index];
        }
    }
}
