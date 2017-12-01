namespace GielinorAdventures.GameLogic.GameManagers
{
    using GielinorAdventures.Models;

    public interface IGameManager
    {
        /// <summary>
        /// Loads the content.
        /// </summary>
        void LoadContent();

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns>The player.</returns>
        Player GetPlayer();

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        World GetWorld();
    }
}
