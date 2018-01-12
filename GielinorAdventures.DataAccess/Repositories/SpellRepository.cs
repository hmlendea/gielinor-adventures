using System.Linq;

using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using GielinorAdventures.DataAccess.DataObjects;

namespace GielinorAdventures.DataAccess.Repositories
{
    /// <summary>
    /// Spell repository implementation.
    /// </summary>
    public class SpellRepository : XmlRepository<SpellEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpellRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public SpellRepository(string fileName) : base(fileName)
        {

        }
        
        /// <summary>
        /// Updates the specified spell.
        /// </summary>
        /// <param name="spellEntity">Spell.</param>
        public override void Update(SpellEntity spellEntity)
        {
            LoadEntitiesIfNeeded();

            SpellEntity spellEntityToUpdate = Entities.FirstOrDefault(x => x.Id == spellEntity.Id);

            if (spellEntityToUpdate == null)
            {
                throw new EntityNotFoundException(spellEntity.Id, nameof(SpellEntity));
            }

            spellEntityToUpdate.Name = spellEntity.Name;
            spellEntityToUpdate.Description = spellEntity.Description;
            spellEntityToUpdate.RequiredLevel = spellEntity.RequiredLevel;
            spellEntityToUpdate.Type = spellEntity.Type;
            spellEntityToUpdate.RuneCount = spellEntity.RuneCount;
            spellEntityToUpdate.RequiredRunesIds = spellEntity.RequiredRunesIds;
            spellEntityToUpdate.RequiredRunesCounts = spellEntity.RequiredRunesCounts;
            spellEntityToUpdate.ExperienceGain = spellEntity.ExperienceGain;

            XmlFile.SaveEntities(Entities);
        }
    }
}
