using GielinorAdventures.Models;

namespace GielinorAdventures.GameLogic.GameManagers
{
    public interface IEntityManager
    {
        /// <summary>
        /// Loads the content.
        /// </summary>
        void LoadContent();
        
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="id">Identifier.</param>
        Item GetItem(string id);
        
        /// <summary>
        /// Gets the mob.
        /// </summary>
        /// <returns>The mob.</returns>
        /// <param name="id">Identifier.</param>
        Mob GetMob(string id);

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns>The player.</returns>
        Player GetPlayer();

        /// <summary>
        /// Gets the prayer.
        /// </summary>
        /// <returns>The prayer.</returns>
        /// <param name="id">Identifier.</param>
        Prayer GetPrayer(string id);

        /// <summary>
        /// Gets the spell.
        /// </summary>
        /// <returns>The spell.</returns>
        /// <param name="id">Identifier.</param>
        Spell GetSpell(string id);
    }
}
