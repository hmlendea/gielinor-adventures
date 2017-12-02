using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GielinorAdventures.Models;

namespace GielinorAdventures.Gui.WorldMap
{
    /// <summary>
    /// Map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Gets or sets the layers.
        /// </summary>
        /// <value>The layers.</value>
        public List<Layer> Layers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        public Map()
        {
            Layers = new List<Layer>();
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="world">World.</param>
        public void LoadContent(World world)
        {
            foreach (WorldLayer worldLayer in world.Layers)
            {
                Layer layer = new Layer
                {
                    Tileset = worldLayer.Tileset,
                    Opacity = worldLayer.Opacity,
                    Visible = worldLayer.Visible
                };

                int cols = worldLayer.Tiles.GetLength(0);
                int rows = worldLayer.Tiles.GetLength(1);

                layer.TileMap = new int[cols, rows];

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        layer.TileMap[x, y] = worldLayer.Tiles[x, y].SpriteSheetFrame;
                    }
                }

                Layers.Add(layer);

                layer.LoadContent();
            }
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            Parallel.ForEach(Layers, l => l.UnloadContent());
        }

        /// <summary>
        /// Update the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {
            Parallel.ForEach(Layers, l => l.Update(gameTime));
        }

        /// <summary>
        /// Draw the content on the specified spriteBatch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        /// <param name="camera">Camera.</param>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            // The order in which the layers are drawn is very important
            Layers.Where(layer => layer.Visible)
                  .ToList()
                  .ForEach(layer => layer.Draw(spriteBatch, camera));
        }
    }
}
