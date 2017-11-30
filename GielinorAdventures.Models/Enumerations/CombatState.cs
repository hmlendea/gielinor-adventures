namespace GielinorAdventures.Models
{
    /// <summary>
    /// Combat states.
    /// </summary>
    public enum CombatState
    {
        /// <summary>
        /// Error. The player is attackable.
        /// </summary>
        Error,

        /// <summary>
        /// The player is running. It is not attackable.
        /// </summary>
        Running,

        /// <summary>
        /// The player is waiting. It is attackable.
        /// </summary>
        Waiting,

        /// <summary>
        /// The player just won. It is attackable.
        /// </summary>
        Won,

        /// <summary>
        /// The player just lost. It is attackable.
        /// </summary>
        Lost
    }
}
