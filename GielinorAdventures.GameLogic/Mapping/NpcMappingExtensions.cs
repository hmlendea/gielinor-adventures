using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Npc mapping extensions for converting between entities and domain models.
    /// </summary>
    static class NpcMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="npcEntity">Npc entity.</param>
        internal static Npc ToDomainModel(this NpcEntity npcEntity)
        {
            Npc npc = new Npc
            {
                Id = npcEntity.Id,
                Name = npcEntity.Name,
                Description = npcEntity.Description,
                Command = npcEntity.Command,
                Sprites = npcEntity.Sprites,
                Appearance = new Appearance
                {
                    HairColour = npcEntity.HairColour,
                    TopColour = npcEntity.TopColour,
                    TrousersColour = npcEntity.TrousersColour,
                    SkinColour = npcEntity.SkinColour
                },
                Camera1 = npcEntity.Camera1,
                Camera2 = npcEntity.Camera2,
                WalkModel = npcEntity.WalkModel,
                CombatModel = npcEntity.CombatModel,
                CombatSprite = npcEntity.CombatSprite,
                HealthLevel = npcEntity.HealthLevel,
                AttackLevel = npcEntity.AttackLevel,
                DefenceLevel = npcEntity.DefenceLevel,
                StrengthLevel = npcEntity.StrengthLevel,
                RespawnTime = npcEntity.RespawnTime,
                IsAttackable = npcEntity.IsAttackable,
                IsAggressive = npcEntity.IsAggressive,
                Drops = npcEntity.Drops?.ToDomainModels().ToArray()
            };

            return npc;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="npc">Npc.</param>
        internal static NpcEntity ToEntity(this Npc npc)
        {
            NpcEntity npcEntity = new NpcEntity
            {
                Id = npc.Id,
                Name = npc.Name,
                Description = npc.Description,
                Command = npc.Command,
                Sprites = npc.Sprites,
                HairColour = npc.Appearance.HairColour,
                TopColour = npc.Appearance.TopColour,
                TrousersColour = npc.Appearance.TrousersColour,
                SkinColour = npc.Appearance.SkinColour,
                Camera1 = npc.Camera1,
                Camera2 = npc.Camera2,
                WalkModel = npc.WalkModel,
                CombatModel = npc.CombatModel,
                CombatSprite = npc.CombatSprite,
                HealthLevel = npc.HealthLevel,
                AttackLevel = npc.AttackLevel,
                DefenceLevel = npc.DefenceLevel,
                StrengthLevel = npc.StrengthLevel,
                RespawnTime = npc.RespawnTime,
                IsAttackable = npc.IsAttackable,
                IsAggressive = npc.IsAggressive,
                Drops = npc.Drops?.ToEntities().ToArray()
            };

            return npcEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="npcEntities">Npc entities.</param>
        internal static IEnumerable<Npc> ToDomainModels(this IEnumerable<NpcEntity> npcEntities)
        {
            IEnumerable<Npc> npcs = npcEntities.Select(npcEntity => npcEntity.ToDomainModel());

            return npcs;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="npcs">Npcs.</param>
        internal static IEnumerable<NpcEntity> ToEntities(this IEnumerable<Npc> npcs)
        {
            IEnumerable<NpcEntity> npcEntities = npcs.Select(npc => npc.ToEntity());

            return npcEntities;
        }
    }
}
