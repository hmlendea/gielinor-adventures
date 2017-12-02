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
        List<Mob> mobs;
        List<Prayer> prayers;
        List<Spell> spells;
        List<Tile> tiles;

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
        /// Gets the mob count.
        /// </summary>
        /// <value>The mob count.</value>
        public int MobCount => mobs.Count;

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
        /// Gets the tiles count.
        /// </summary>
        /// <value>The tiles count.</value>
        public int TileCount => tiles.Count;

        public int HighestLoadedPicture { get; private set; }

        /// <summary>
        /// Loads the entities in memory.
        /// </summary>
        public void LoadContent()
        {
            string animationsPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "animations.xml");
            string elevationPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "elevations.xml");
            string itemPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "items.xml");
            string mobPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "mobs.xml");
            string prayerPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "prayers.xml");
            string spellPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "spells.xml");
            string tilePath = Path.Combine(ApplicationPaths.EntitiesDirectory, "tiles.xml");

            AnimationRepository animationRepository = new AnimationRepository(animationsPath);
            ElevationRepository elevationRepository = new ElevationRepository(elevationPath);
            ItemRepository itemRepository = new ItemRepository(itemPath);
            MobRepository mobRepository = new MobRepository(mobPath);
            PrayerRepository prayerRepository = new PrayerRepository(prayerPath);
            SpellRepository spellRepository = new SpellRepository(spellPath);
            TileRepository tileRepository = new TileRepository(tilePath);

            animations = animationRepository.GetAll().ToDomainModels().ToList();
            elevations = elevationRepository.GetAll().ToDomainModels().ToList();
            items = itemRepository.GetAll().ToDomainModels().ToList();
            mobs = mobRepository.GetAll().ToDomainModels().ToList();
            prayers = prayerRepository.GetAll().ToDomainModels().ToList();
            spells = spellRepository.GetAll().ToDomainModels().ToList();
            tiles = tileRepository.GetAll().ToDomainModels().ToList();
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
        /// <param name="id">Identifier.</param>
        public Item GetItem(string id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }


        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="index">Index.</param>
        public Item GetItem(int index)
        {
            if (index < 0 || index >= ItemCount)
            {
                return null;
            }

            return items[index];
        }

        /// <summary>
        /// Gets the mob.
        /// </summary>
        /// <returns>The mob.</returns>
        /// <param name="index">Identifier.</param>
        public Mob GetMob(int index)
        {
            if (index < 0 || index >= MobCount)
            {
                return null;
            }

            return mobs[index];
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
    }
}
