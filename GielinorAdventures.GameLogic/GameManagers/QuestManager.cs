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
    public class QuestManager
    {
        List<Quest> quests;

        /// <summary>
        /// Gets the quests count.
        /// </summary>
        /// <value>The quests count.</value>
        public int QuestsCount => quests.Count;

        public int QuestPoints { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestManager"/> class.
        /// </summary>
        public QuestManager()
        {
            LoadQuests();
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

        void LoadQuests()
        {
            string questRepositoryPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "quests.xml");
            QuestRepository questRepository = new QuestRepository(questRepositoryPath);

            quests = questRepository.GetAll().ToDomainModels().ToList();
        }
    }
}
