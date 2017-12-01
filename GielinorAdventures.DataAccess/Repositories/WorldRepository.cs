using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using TiledSharp;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// World repository implementation.
    /// </summary>
    public class WorldRepository
    {
        readonly string worldsDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldRepository"/> class.
        /// </summary>
        /// <param name="worldsDirectory">File name.</param>
        public WorldRepository(string worldsDirectory)
        {
            this.worldsDirectory = worldsDirectory;
        }

        /// <summary>
        /// Adds the specified world.
        /// </summary>
        /// <param name="worldEntity">World.</param>
        public void Add(WorldEntity worldEntity)
        {
            // TODO: Implement this
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the world with the specified identifier.
        /// </summary>
        /// <returns>The world.</returns>
        /// <param name="id">Identifier.</param>
        public WorldEntity Get(string id)
        {
            WorldEntity worldEntity;
            string worldFile = Path.Combine(worldsDirectory, $"{id}.xml");

            worldEntity = new WorldEntity { Id = id };
            // TODO: Also load Name and Description

            //worldEntity.Tiles = LoadWorldTiles(id);
            worldEntity.Layers = LoadWorldLayers(id);

            return worldEntity;
        }

        /// <summary>
        /// Gets all the worlds.
        /// </summary>
        /// <returns>The worlds</returns>
        public IEnumerable<WorldEntity> GetAll()
        {
            ConcurrentBag<WorldEntity> worldEntities = new ConcurrentBag<WorldEntity>();

            Parallel.ForEach(Directory.GetDirectories(worldsDirectory),
                             worldId => worldEntities.Add(Get(worldId)));

            return worldEntities;
        }

        /// <summary>
        /// Updates the specified world.
        /// </summary>
        /// <param name="worldEntity">World.</param>
        public void Update(WorldEntity worldEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the world with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            Directory.Delete(Path.Combine(worldsDirectory, id));
        }

        List<WorldLayerEntity> LoadWorldLayers(string worldId)
        {
            TmxMap tmxMap = new TmxMap(Path.Combine(worldsDirectory, $"{worldId}.tmx"));
            List<WorldLayerEntity> layers = new List<WorldLayerEntity>();

            foreach (TmxLayer tmxLayer in tmxMap.Layers)
            {
                WorldLayerEntity layer = ProcessTmxLayer(tmxMap, tmxLayer);

                layers.Add(layer);
            }

            return layers;
        }

        WorldLayerEntity ProcessTmxLayer(TmxMap tmxMap, TmxLayer tmxLayer)
        {
            string tilesetName = tmxLayer.Properties["tileset"];

            if (string.IsNullOrWhiteSpace(tilesetName) ||
                tmxMap.Tilesets.ToList().FindIndex(t => t.Name == tilesetName) < 0)
            {
                throw new InvalidEntityFieldException(nameof(WorldLayerEntity.Tileset), tmxLayer.Name, nameof(WorldLayerEntity));
            }

            TmxTileset tmxTileset = tmxMap.Tilesets[tilesetName];

            WorldLayerEntity layer = new WorldLayerEntity
            {
                Name = tmxLayer.Name,
                Tiles = new int[tmxMap.Width, tmxMap.Height],
                Tileset = tmxTileset.Name,
                Opacity = (float)tmxLayer.Opacity,
                Visible = tmxLayer.Visible
            };

            Parallel.ForEach(tmxLayer.Tiles, tile => layer.Tiles[tile.X, tile.Y] = Math.Max(-1, tile.Gid - tmxTileset.FirstGid));

            return layer;
        }
    }
}
