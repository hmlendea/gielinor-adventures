using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Quest mapping extensions for converting between entities and domain models.
    /// </summary>
    static class QuestMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="questEntity">Quest entity.</param>
        internal static Quest ToDomainModel(this QuestEntity questEntity)
        {
            Quest quest = new Quest
            {
                Id = questEntity.Id,
                Name = questEntity.Name,
            };

            return quest;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="quest">Quest.</param>
        internal static QuestEntity ToEntity(this Quest quest)
        {
            QuestEntity questEntity = new QuestEntity
            {
                Id = quest.Id,
                Name = quest.Name
            };

            return questEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="questEntities">Quest entities.</param>
        internal static IEnumerable<Quest> ToDomainModels(this IEnumerable<QuestEntity> questEntities)
        {
            IEnumerable<Quest> quests = questEntities.Select(questEntity => questEntity.ToDomainModel());

            return quests;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="quests">Quests.</param>
        internal static IEnumerable<QuestEntity> ToEntities(this IEnumerable<Quest> quests)
        {
            IEnumerable<QuestEntity> questEntities = quests.Select(quest => quest.ToEntity());

            return questEntities;
        }
    }
}
