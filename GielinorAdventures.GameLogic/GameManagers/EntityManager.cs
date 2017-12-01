using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.IO;
using GielinorAdventures.DataAccess.Repositories;
using GielinorAdventures.GameLogic.Mapping;
using GielinorAdventures.Models;
using GielinorAdventures.Settings;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public class EntityManager
    {
        List<Animation> animations;
        List<Elevation> elevations;
        List<Item> items;
        List<Npc> npcs;
        List<Prayer> prayers;
        List<Spell> spells;
        List<GameTexture> textures;
        List<Tile> tiles;
        List<WallObject> wallObjects;
        List<WorldObject> worldObjects;

        string[] modelName = new string[5000];

        /// <summary>
        /// Gets the animations count.
        /// </summary>
        /// <value>The animations count.</value>
        public int AnimationCount => animations.Count;

        /// <summary>
        /// Gets the elevations count.
        /// </summary>
        /// <value>The elevations count.</value>
        public int ElevationCount => elevations.Count;

        /// <summary>
        /// Gets the items count.
        /// </summary>
        /// <value>The items count.</value>
        public int ItemCount => items.Count;

        /// <summary>
        /// Gets the npc count.
        /// </summary>
        /// <value>The npc count.</value>
        public int NpcCount => npcs.Count;

        /// <summary>
        /// Gets the object models count.
        /// </summary>
        /// <value>The object models count.</value>
        public int ObjectModelCount { get; private set; }

        /// <summary>
        /// Gets the prayers count.
        /// </summary>
        /// <value>The prayers count.</value>
        public int PrayerCount => prayers.Count;

        /// <summary>
        /// Gets the spells count.
        /// </summary>
        /// <value>The spells count.</value>
        public int SpellCount => spells.Count;

        /// <summary>
        /// Gets or sets the spell projectile count.
        /// </summary>
        /// <value>The spell projectile count.</value>
        public int SpellProjectileCount { get; private set; }

        /// <summary>
        /// Gets the textures count.
        /// </summary>
        /// <value>The textures count.</value>
        public int TextureCount => textures.Count;

        /// <summary>
        /// Gets the tiles count.
        /// </summary>
        /// <value>The tiles count.</value>
        public int TileCount => tiles.Count;

        /// <summary>
        /// Gets the wall objects count.
        /// </summary>
        /// <value>The wall objects count.</value>
        public int WallObjectCount => wallObjects.Count;

        /// <summary>
        /// Gets the world objects count.
        /// </summary>
        /// <value>The world objects count.</value>
        public int WorldObjectCount => worldObjects.Count;

        public int HighestLoadedPicture { get; private set; }

        /// <summary>
        /// Loads the entities in memory.
        /// </summary>
        public void LoadContent()
        {
            string animationsPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "animations.xml");
            string elevationPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "elevations.xml");
            string itemPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "items.xml");
            string npcPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "npcs.xml");
            string prayerPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "prayers.xml");
            string spellPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "spells.xml");
            string texturePath = Path.Combine(ApplicationPaths.EntitiesDirectory, "textures.xml");
            string tilePath = Path.Combine(ApplicationPaths.EntitiesDirectory, "tiles.xml");
            string wallObjectPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "wall_objects.xml");
            string worldObjectPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "world_objects.xml");

            AnimationRepository animationRepository = new AnimationRepository(animationsPath);
            ElevationRepository elevationRepository = new ElevationRepository(elevationPath);
            ItemRepository itemRepository = new ItemRepository(itemPath);
            NpcRepository npcRepository = new NpcRepository(npcPath);
            PrayerRepository prayerRepository = new PrayerRepository(prayerPath);
            SpellRepository spellRepository = new SpellRepository(spellPath);
            GameTextureRepository textureRepository = new GameTextureRepository(texturePath);
            TileRepository tileRepository = new TileRepository(tilePath);
            WallObjectRepository wallObjectRepository = new WallObjectRepository(wallObjectPath);
            WorldObjectRepository worldObjectRepository = new WorldObjectRepository(worldObjectPath);

            animations = animationRepository.GetAll().ToDomainModels().ToList();
            elevations = elevationRepository.GetAll().ToDomainModels().ToList();
            items = itemRepository.GetAll().ToDomainModels().ToList();
            npcs = npcRepository.GetAll().ToDomainModels().ToList();
            prayers = prayerRepository.GetAll().ToDomainModels().ToList();
            spells = spellRepository.GetAll().ToDomainModels().ToList();
            textures = textureRepository.GetAll().ToDomainModels().ToList();
            tiles = tileRepository.GetAll().ToDomainModels().ToList();
            wallObjects = wallObjectRepository.GetAll().ToDomainModels().ToList();
            worldObjects = worldObjectRepository.GetAll().ToDomainModels().ToList();

            foreach (WorldObject worldObject in worldObjects)
            {
                worldObject.ModelId = GetModelIndex(worldObject.ObjectModel);
            }
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="index">Identifier.</param>
        public Animation GetAnimation(int index)
        {
            if (index < 0 || index >= AnimationCount)
            {
                return null;
            }

            return animations[index];
        }

        /// <summary>
        /// Gets the elevation.
        /// </summary>
        /// <returns>The elevation.</returns>
        /// <param name="index">Identifier.</param>
        public Elevation GetElevation(int index)
        {
            if (index < 0 || index >= ElevationCount)
            {
                return null;
            }

            return elevations[index];
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="index">Identifier.</param>
        public Item GetItem(int index)
        {
            if (index < 0 || index >= ItemCount)
            {
                return null;
            }

            return items[index];
        }

        public int GetModelIndex(string model)
        {
            if (model.ToLower().Equals("na"))
            {
                return 0;
            }

            for (int i = 0; i < ObjectModelCount; i++)
            {
                if (modelName[i].ToLower().Equals(model))
                {
                    return i;
                }
            }

            modelName[ObjectModelCount] = model;
            ObjectModelCount += 1;

            return ObjectModelCount - 1;
        }

        /// <summary>
        /// Gets the npc.
        /// </summary>
        /// <returns>The npc.</returns>
        /// <param name="index">Identifier.</param>
        public Npc GetNpc(int index)
        {
            if (index < 0 || index >= NpcCount)
            {
                return null;
            }

            return npcs[index];
        }

        public string GetObjectModelName(int index)
        {
            return modelName[index];
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns>The player.</returns>
        public Player GetPlayer()
        {
            XmlManager<PlayerEntity> xml = new XmlManager<PlayerEntity>();
            string path = Path.Combine(ApplicationPaths.UserDataDirectory, "Player.xml");

            PlayerEntity playerEntity = xml.Read(path);
            return playerEntity.ToDomainModel();
        }

        /// <summary>
        /// Gets the prayer.
        /// </summary>
        /// <returns>The prayer.</returns>
        /// <param name="index">Identifier.</param>
        public Prayer GetPrayer(int index)
        {
            if (index < 0 || index >= PrayerCount)
            {
                return null;
            }

            return prayers[index];
        }

        /// <summary>
        /// Gets the spell.
        /// </summary>
        /// <returns>The spell.</returns>
        /// <param name="index">Identifier.</param>
        public Spell GetSpell(int index)
        {
            if (index < 0 || index >= SpellCount)
            {
                return null;
            }

            return spells[index];
        }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <returns>The texture.</returns>
        /// <param name="index">Identifier.</param>
        public GameTexture GetTexture(int index)
        {
            if (index < 0 || index >= TextureCount)
            {
                return null;
            }

            return textures[index];
        }

        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <returns>The tile.</returns>
        /// <param name="index">Identifier.</param>
        public Tile GetTile(int index)
        {
            if (index < 0 || index >= TileCount)
            {
                return null;
            }

            return tiles[index];
        }

        /// <summary>
        /// Gets the wall object.
        /// </summary>
        /// <returns>The wall object.</returns>
        /// <param name="index">Identifier.</param>
        public WallObject GetWallObject(int index)
        {
            if (index < 0 || index >= WallObjectCount)
            {
                return null;
            }

            return wallObjects[index];
        }

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        /// <param name="id">Identifier.</param>
        public World GetWorld(string id)
        {
            WorldRepository worldRepository = new WorldRepository(ApplicationPaths.WorldsDirectory);

            WorldEntity worldEntity = worldRepository.Get(id);

            return worldEntity.ToDomainModel();
        }

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="index">Index.</param>
        public WorldObject GetWorldObject(int index)
        {
            if (index < 0 || index >= WorldObjectCount)
            {
                return null;
            }

            return worldObjects[index];
        }

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="id">Identifier.</param>
        public WorldObject GetWorldObject(string id)
        {
            return worldObjects.FirstOrDefault(x => x.Id == id);
        }
    }
}
