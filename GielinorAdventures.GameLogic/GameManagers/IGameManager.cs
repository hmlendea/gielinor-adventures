namespace GielinorAdventures.GameLogic.GameManagers
{
    using GielinorAdventures.Models;

    public interface IGameManager
    {
        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <returns>The world.</returns>
        World GetWorld();
    }
}
