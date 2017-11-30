using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.DataAccess.Exceptions;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Spell repository implementation.
    /// </summary>
    public class SpellRepository
    {
        readonly XmlDatabase<SpellEntity> xmlDatabase;
        List<SpellEntity> spellEntities;
        bool loadedEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public SpellRepository(string fileName)
        {
            xmlDatabase = new XmlDatabase<SpellEntity>(fileName);
            spellEntities = new List<SpellEntity>();
        }

        public void ApplyChanges()
        {
            try
            {
                xmlDatabase.SaveEntities(spellEntities);
            }
            catch
            {
                // TODO: Better exception message
                throw new IOException("Cannot save the changes");
            }
        }

        /// <summary>
        /// Adds the specified spell.
        /// </summary>
        /// <param name="spellEntity">Spell.</param>
        public void Add(SpellEntity spellEntity)
        {
            LoadEntitiesIfNeeded();

            spellEntities.Add(spellEntity);
        }

        /// <summary>
        /// Get the spell with the specified identifier.
        /// </summary>
        /// <returns>The spell.</returns>
        /// <param name="id">Identifier.</param>
        public SpellEntity Get(string id)
        {
            LoadEntitiesIfNeeded();

            SpellEntity spellEntity = spellEntities.FirstOrDefault(x => x.Id == id);

            if (spellEntity == null)
            {
                throw new EntityNotFoundException(id, nameof(SpellEntity).Replace("Entity", ""));
            }

            return spellEntity;
        }

        /// <summary>
        /// Gets all the spells.
        /// </summary>
        /// <returns>The spells</returns>
        public IEnumerable<SpellEntity> GetAll()
        {
            LoadEntitiesIfNeeded();

            return spellEntities;
        }

        /// <summary>
        /// Updates the specified spell.
        /// </summary>
        /// <param name="spellEntity">Spell.</param>
        public void Update(SpellEntity spellEntity)
        {
            LoadEntitiesIfNeeded();

            SpellEntity spellEntityToUpdate = spellEntities.FirstOrDefault(x => x.Id == spellEntity.Id);

            if (spellEntityToUpdate == null)
            {
                throw new EntityNotFoundException(spellEntity.Id, nameof(SpellEntity).Replace("Entity", ""));
            }

            spellEntityToUpdate.Name = spellEntity.Name;
            spellEntityToUpdate.Description = spellEntity.Description;
            spellEntityToUpdate.RequiredLevel = spellEntity.RequiredLevel;
            spellEntityToUpdate.Type = spellEntity.Type;
            spellEntityToUpdate.RuneCount = spellEntity.RuneCount;
            spellEntityToUpdate.RequiredRunesIds = spellEntity.RequiredRunesIds;
            spellEntityToUpdate.RequiredRunesCounts = spellEntity.RequiredRunesCounts;
            spellEntityToUpdate.ExperienceGain = spellEntity.ExperienceGain;

            xmlDatabase.SaveEntities(spellEntities);
        }

        /// <summary>
        /// Removes the spell with the specified identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Remove(string id)
        {
            LoadEntitiesIfNeeded();

            spellEntities.RemoveAll(x => x.Id == id);

            try
            {
                xmlDatabase.SaveEntities(spellEntities);
            }
            catch
            {
                throw new DuplicateEntityException(id, nameof(SpellEntity).Replace("Entity", ""));
            }
        }

        void LoadEntitiesIfNeeded()
        {
            if (loadedEntities)
            {
                return;
            }

            spellEntities = xmlDatabase.LoadEntities().ToList();
            loadedEntities = true;
        }
    }
}
