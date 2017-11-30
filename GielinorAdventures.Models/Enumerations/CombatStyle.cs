namespace GielinorAdventures.Models.Enumerations
{
    /// <summary>
    /// Combat style.
    /// </summary>
    public enum CombatStyle
    {
        /// <summary>
        /// The controlled style. +1 Attack, Strength, Defence.
        /// </summary>
        Controlled = 0,

        /// <summary>
        /// The aggressive style. +3 Stength.
        /// </summary>
        Aggressive = 1,

        /// <summary>
        /// The accurate style. +3 Attack.
        /// </summary>
        Accurate = 2,

        /// <summary>
        /// The defensive style. +3 Defence.
        /// </summary>
        Defensive = 3
    }
}
