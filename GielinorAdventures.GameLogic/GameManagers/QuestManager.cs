using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using GielinorAdventures.DataAccess.Repositories;
using GielinorAdventures.GameLogic.Mapping;
using GielinorAdventures.Models;
using GielinorAdventures.Settings;

namespace GielinorAdventures.GameLogic.GameManagers
{
    /// <summary>
    /// Quest manager.
    /// </summary>
    public class QuestManager : IQuestManager
    {
        List<Quest> quests;
        
        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            string questRepositoryPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "quests.xml");
            QuestRepository questRepository = new QuestRepository(questRepositoryPath);

            quests = questRepository.GetAll().ToDomainModels().ToList();
        }

        /// <summary>
        /// Gets the quest.
        /// </summary>
        /// <returns>The quest.</returns>
        /// <param name="id">Identifier.</param>
        public Quest GetQuest(string id)
        {
            return quests.FirstOrDefault(quest => quest.Id == id);
        }

        /// <summary>
        /// Sets the stage of a quest.
        /// </summary>
        /// <param name="id">Quest identifier.</param>
        /// <param name="stage">Stage.</param>
        public void SetStage(string id, int stage)
        {
            Quest quest = GetQuest(id);

            quest.Stage = stage;
        }

        /// <summary>
        /// Gets the total quest points.
        /// </summary>
        /// <returns>Total quest points.</returns>
        public int GetTotalQuestPoints()
        {
            throw new NotImplementedException();
        }
    }
}
