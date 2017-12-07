using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public interface IQuestManager
    {
        /// <summary>
        /// Loads the content.
        /// </summary>
        void LoadContent();

        /// <summary>
        /// Gets the quest.
        /// </summary>
        /// <returns>The quest.</returns>
        /// <param name="id">Identifier.</param>
        Quest GetQuest(string id);

        /// <summary>
        /// Sets the stage of a quest.
        /// </summary>
        /// <param name="id">Quest identifier.</param>
        /// <param name="stage">Stage.</param>
        void SetStage(string id, int stage);

        /// <summary>
        /// Gets the total quest points.
        /// </summary>
        /// <returns>Total quest points.</returns>
        int GetTotalQuestPoints();
    }
}
