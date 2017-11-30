using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Spell mapping extensions for converting between entities and domain models.
    /// </summary>
    static class SpellMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="spellEntity">Spell entity.</param>
        internal static Spell ToDomainModel(this SpellEntity spellEntity)
        {
            Spell spell = new Spell
            {
                Id = spellEntity.Id,
                Name = spellEntity.Name,
                Description = spellEntity.Description,
                RequiredLevel = spellEntity.RequiredLevel,
                Type = spellEntity.Type,
                RuneCount = spellEntity.RuneCount,
                RequiredRunesIds = spellEntity.RequiredRunesIds,
                RequiredRunesCounts = spellEntity.RequiredRunesCounts,
                ExperienceGain = spellEntity.ExperienceGain
            };

            return spell;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="spell">Spell.</param>
        internal static SpellEntity ToEntity(this Spell spell)
        {
            SpellEntity spellEntity = new SpellEntity
            {
                Id = spell.Id,
                Name = spell.Name,
                Description = spell.Description,
                RequiredLevel = spell.RequiredLevel,
                Type = spell.Type,
                RuneCount = spell.RuneCount,
                RequiredRunesIds = spell.RequiredRunesIds,
                RequiredRunesCounts = spell.RequiredRunesCounts,
                ExperienceGain = spell.ExperienceGain
            };

            return spellEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="spellEntities">Spell entities.</param>
        internal static IEnumerable<Spell> ToDomainModels(this IEnumerable<SpellEntity> spellEntities)
        {
            IEnumerable<Spell> spells = spellEntities.Select(spellEntity => spellEntity.ToDomainModel());

            return spells;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="spells">Spells.</param>
        internal static IEnumerable<SpellEntity> ToEntities(this IEnumerable<Spell> spells)
        {
            IEnumerable<SpellEntity> spellEntities = spells.Select(spell => spell.ToEntity());

            return spellEntities;
        }
    }
}
