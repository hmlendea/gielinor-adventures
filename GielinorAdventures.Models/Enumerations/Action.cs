namespace GielinorAdventures.Models.Enumerations
{
    /// <summary>
    /// Player actions.
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// Idle.
        /// </summary>
        Idle,

        /// <summary>
        /// Walking.
        /// </summary>
        Walking,

        /// <summary>
        /// Attacking an NPC.
        /// </summary>
        Attacking,

        /// <summary>
        /// In combat with an NPC.
        /// </summary>
        FightingMelee,

        /// <summary>
        /// In ranged combat with an NPC.
        /// </summary>
        FightingRanged,

        /// <summary>
        /// Talking with an NPC.
        /// </summary>
        TalkingWithNpc,

        /// <summary>
        /// Dropping an item.
        /// </summary>
        DroppingItem,

        /// <summary>
        /// Picking up an item.
        /// </summary>
        TakingItem,

        /// <summary>
        /// Using an item on a ground item.
        /// </summary>
        UsingItemOnGroundItem,

        /// <summary>
        /// Using an item on an NPC.
        /// </summary>
        UsingItemOnNpc,

        /// <summary>
        /// Using an item on a world object.
        /// </summary>
        UsingItemOnObject,

        /// <summary>
        /// Using an item on a wall object.
        /// </summary>
        UsingItemOnWallObject,

        /// <summary>
        /// Using a world object.
        /// </summary>
        UsingObject,

        /// <summary>
        /// Using a wall object.
        /// </summary>
        UsingWallObject,

        /// <summary>
        /// Casting a spell on an NPC.
        /// </summary>
        CastingSpellOnNpc,

        /// <summary>
        /// Casting a spell on a ground item.
        /// </summary>
        CastingSpellOnGroundItem
    }
}
