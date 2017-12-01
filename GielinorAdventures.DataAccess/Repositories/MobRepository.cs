using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Mob repository implementation.
    /// </summary>
    public class MobRepository
    {
        readonly XmlDatabase<MobEntity> xmlDatabase;
        List<MobEntity> mobEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public MobRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<MobEntity>(fileName);
            mobEntities = new List<MobEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(mobEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified mob.
        /// </summary>
        /// <param name="mobEntity">Mob.</param>
        public void Add(MobEntity mobEntity)
        {
            LoadEntitiesIfNeeded();

            mobEntities.Add(mobEntity);
        }

        /// <summary>
        /// Get the mob with the specified identifier.
        /// </summary>
        /// <returns>The mob.</returns>
        /// <param name="id">Identifier.</param>
        public MobEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            MobEntity mobEntity = mobEntities.FirstOrDefault(x => x.Id == id);

            if (mobEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(MobEntity).Replace("Entity", ""));
            }

            return mobEntity;
        }

        /// <summary>
        /// Gets all the mobs.
        /// </summary>
        /// <returns>The mobs</returns>
        public IEnumerable<MobEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return mobEntities;
        }

        /// <summary>
        /// Updates the specified mob.
        /// </summary>
        /// <param name="mobEntity">Mob.</param>
        public void Update(MobEntity mobEntity)
        {
            LoadEntitiesIfNeeded();

            MobEntity mobEntityToUpdate = mobEntities.FirstOrDefault(x => x.Id == mobEntity.Id);

            if (mobEntityToUpdate == null)
            {
                throw new EntityNotFoundException(mobEntity.Id, nameof(MobEntity).Replace("Entity", ""));
            }

            mobEntityToUpdate.Name = mobEntity.Name;
            mobEntityToUpdate.Description = mobEntity.Description;
            mobEntityToUpdate.Command = mobEntity.Command;

            mobEntityToUpdate.IsAttackable = mobEntity.IsAttackable;
            mobEntityToUpdate.IsAggressive = mobEntity.IsAggressive;

            mobEntityToUpdate.RespawnTime = mobEntity.RespawnTime;
            mobEntityToUpdate.CombatStyle = mobEntity.CombatStyle;
            mobEntityToUpdate.Drops = mobEntity.Drops;

            mobEntityToUpdate.AttackLevel = mobEntity.AttackLevel;
            mobEntityToUpdate.HitpointsLevel = mobEntity.HitpointsLevel;
            mobEntityToUpdate.StrengthLevel = mobEntity.StrengthLevel;
            mobEntityToUpdate.DefenceLevel = mobEntity.DefenceLevel;
            mobEntityToUpdate.RangedLevel = mobEntity.RangedLevel;
            mobEntityToUpdate.MagicLevel = mobEntity.MagicLevel;

            xmlDatabase.SaveEntities(mobEntities);
        }

        /// <summary>
        /// Removes the mob with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            mobEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(mobEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(MobEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            mobEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
