using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Repositories;
using GielinorAdventures.GameLogic.Mapping;
using GielinorAdventures.Models;
using GielinorAdventures.Models.Enumerations;
using GielinorAdventures.Primitives;
using GielinorAdventures.Settings;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public class WorldManager : IWorldManager
    {
        World currentWorld;

        Terrain[,] terrainMap;
        WorldObject[,] worldObjectMap;

        List<MapMarker> mapMarkers;
        List<Terrain> terrains;
        List<WorldObject> worldObjects;

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            string terrainPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "terrains.xml");
            string worldObjectPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "world_objects.xml");

            TerrainRepository terrainRepository = new TerrainRepository(terrainPath);
            WorldObjectRepository worldObjectRepository = new WorldObjectRepository(worldObjectPath);

            terrains = terrainRepository.GetAll().ToDomainModels().ToList();
            worldObjects = worldObjectRepository.GetAll().ToDomainModels().ToList();
        }

        /// <summary>
        /// Loads the specified world.
        /// </summary>
        /// <param name="id">World identifier.</param>
        public void LoadWorld(string id)
        {
            WorldRepository worldRepository = new WorldRepository(ApplicationPaths.WorldsDirectory);
            WorldEntity worldEntity = worldRepository.Get(id);

            currentWorld = worldEntity.ToDomainModel();

            mapMarkers = new List<MapMarker>();
            terrainMap = new Terrain[currentWorld.Width, currentWorld.Height];
            worldObjectMap = new WorldObject[currentWorld.Width, currentWorld.Height];

            ProcessTileProperties();
            ProcessMapMarkers();
        }

        /// <summary>
        /// Gets the map markers.
        /// </summary>
        /// <returns>The map markers.</returns>
        public IEnumerable<MapMarker> GetMapMarkers()
        {
            return mapMarkers;
        }

        /// <summary>
        /// Gets the terrain at the specified location.
        /// </summary>
        /// <returns>The terrain.</returns>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Terrain GetTerrain(int x, int y)
        {
            return terrainMap[x, y];
        }

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        public World GetWorld()
        => currentWorld;

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="id">Identifier.</param>
        public WorldObject GetWorldObject(string id)
        {
            return worldObjects.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the world object at the specified location.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public WorldObject GetWorldObject(int x, int y)
        {
            return worldObjectMap[x, y];
        }

        void AddMapMarker(int x, int y, MapMarkerType type)
        {
            MapMarker mapMarker = new MapMarker
            {
                Type = type,
                Location = new Point2D(x, y)
            };

            mapMarkers.Add(mapMarker);
        }

        Terrain GetTerrain(string id)
        {
            return terrains.FirstOrDefault(x => x.Id == id);
        }

        void ProcessTileProperties()
        {
            for (int y = 0; y < currentWorld.Height; y++)
            {
                for (int x = 0; x < currentWorld.Width; x++)
                {
                    string objectId = string.Empty;
                    string terrainId = string.Empty;

                    foreach (WorldLayer layer in currentWorld.Layers)
                    {
                        if (!string.IsNullOrWhiteSpace(layer.Tiles[x, y].ObjectId))
                        {
                            objectId = layer.Tiles[x, y].ObjectId;
                        }

                        if (!string.IsNullOrWhiteSpace(layer.Tiles[x, y].TerrainId))
                        {
                            terrainId = layer.Tiles[x, y].TerrainId;
                        }
                    }

                    terrainMap[x, y] = GetTerrain(terrainId);
                    worldObjectMap[x, y] = GetWorldObject(objectId);
                }
            }
        }

        void ProcessMapMarkers()
        {
            for (int y = 0; y < currentWorld.Height; y++)
            {
                for (int x = 0; x < currentWorld.Width; x++)
                {
                    WorldObject worldObject = GetWorldObject(x, y);

                    if (worldObject == null)
                    {
                        continue;
                    }

                    MapMarkerType type = MapMarkerType.None;

                    switch (worldObject.Type)
                    {
                        case WorldObjectType.Anvil:
                            type = MapMarkerType.Anvil;
                            break;

                        case WorldObjectType.Cooking:
                            type = MapMarkerType.CookingStation;
                            break;

                        case WorldObjectType.WaterSource:
                            type = MapMarkerType.WaterSource;
                            break;
                    }

                    if (type != MapMarkerType.None &&
                        CheckMarkerPlacement(x, y, 16, type))
                    {
                        AddMapMarker(x, y, type);
                    }
                }
            }
        }

        bool CheckMarkerPlacement(int x, int y, int radius, MapMarkerType type)
        {
            return mapMarkers
                .Where(marker => marker.Type == type)
                .All(marker => Math.Abs(marker.Location.X - x) >= radius ||
                               Math.Abs(marker.Location.Y - y) >= radius);
        }
    }
}
