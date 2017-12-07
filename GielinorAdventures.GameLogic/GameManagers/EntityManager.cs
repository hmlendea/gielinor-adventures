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
    public class EntityManager : IEntityManager
    {
        List<Item> items;
        List<Mob> mobs;
        List<Prayer> prayers;
        List<Spell> spells;
        
        /// <summary>
        /// Loads the entities in memory.
        /// </summary>
        public void LoadContent()
        {
            string itemPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "items.xml");
            string mobPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "mobs.xml");
            string prayerPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "prayers.xml");
            string spellPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "spells.xml");
            
            ItemRepository itemRepository = new ItemRepository(itemPath);
            MobRepository mobRepository = new MobRepository(mobPath);
            PrayerRepository prayerRepository = new PrayerRepository(prayerPath);
            SpellRepository spellRepository = new SpellRepository(spellPath);
            
            items = itemRepository.GetAll().ToDomainModels().ToList();
            mobs = mobRepository.GetAll().ToDomainModels().ToList();
            prayers = prayerRepository.GetAll().ToDomainModels().ToList();
            spells = spellRepository.GetAll().ToDomainModels().ToList();
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
        /// Gets the mob.
        /// </summary>
        /// <returns>The mob.</returns>
        /// <param name="id">Identifier.</param>
        public Mob GetMob(string id)
        {
            return mobs.FirstOrDefault(x => x.Id == id);
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
        /// <param name="id">Identifier.</param>
        public Prayer GetPrayer(string id)
        {
            return prayers.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the spell.
        /// </summary>
        /// <returns>The spell.</returns>
        /// <param name="id">Identifier.</param>
        public Spell GetSpell(string id)
        {
            return spells.FirstOrDefault(x => x.Id == id);
        }
    }
}
